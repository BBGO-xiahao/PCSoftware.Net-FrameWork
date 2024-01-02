using Modbus.Device;
using Modbus.Message;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XG.Com.LogHelper;

namespace BMS.Comm
{
    public class SerialPortManageModBus
    {
        #region 标准的单例

        /*写双重判断的原因如下
        在极低的几率下，通过if(instance == NULL)的线程才会有进入锁定临界区的可能性，这种几率还是比较低的，
        不会阻塞太多的线程，但为了防止一个线程进入临界区创建实例，另外的线程也进去临界区创建实例，
        又加上了一道防御if(instance == NULL)，这样就确保不会重复创建了。
        */
        private static SerialPortManageModBus instance = null;

        private static readonly object Lock_instance = new object();

        public static SerialPortManageModBus GetInstance()
        {
            if (instance == null)
            {
                lock (Lock_instance)
                {
                    if (instance == null)
                    {
                        instance = new SerialPortManageModBus();
                    }
                }
            }
            return instance;
        }


        #endregion
        // 创建SerialPort对象，配置串口参数
        SerialPort serialPort = null;
        IModbusSerialMaster modbusMaster = null;

        public void SetTimeOut(int ms)
        {
            modbusMaster.Transport.ReadTimeout = ms;
        }

        public void CreatSerial(string comNum, int baudRate)
        {
            try
            {
                serialPort = new SerialPort(comNum, baudRate, Parity.None, 8, StopBits.One);
                // 打开串口
                serialPort.Open();
                // 创建Modbus主站对象
                modbusMaster = ModbusSerialMaster.CreateRtu(serialPort);
                // 设置Modbus主站的读取超时时间
                modbusMaster.Transport.ReadTimeout = 1000;
            }
            catch (Exception ex)
            {
                serialPort?.Close();
                serialPort?.Dispose();
                throw (ex);
            }
        }

        private byte salveIdConfig = 1;
        private byte salveIdReal = 1;
        private byte salveIdHistory = 1;


        public bool IsRealtime = false;

        public int DeceiveCount = 15;
        public List<byte> DeceiveIds = new List<byte>();
        public byte SalveIdConfig { get => salveIdConfig; set => salveIdConfig = value; }
        public byte SalveIdReal { get => salveIdReal; set => salveIdReal = value; }
        public byte SalveIdHistory { get => salveIdHistory; set => salveIdHistory = value; }

        public void CloseSerial()
        {
            try
            {
                serialPort?.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //finally
            //{
            //    // 关闭串口
            //    serialPort.Close();
            //}

        }

        public Dictionary<ushort, ushort> ModBusRead(ushort startAddress, ushort numRegisters, byte salve = 1)
        {
            try
            {

                Dictionary<ushort, ushort> keyValuePairs = new Dictionary<ushort, ushort>();
                // 发送Modbus读取命令，并接收响应报文
                ushort[] data = modbusMaster?.ReadHoldingRegisters(salve, startAddress, numRegisters);
                FileLog.GetInstance().SySLog($"读回：设备ID:{salve}   开始地址:{startAddress.ToString("X4")}   读取位数:{numRegisters} => 值:{string.Join(" ", data)}");

                if (data != null)
                {
                    for (int i = 0; i < data.Length; i++)
                    {
                        keyValuePairs.Add(Convert.ToUInt16(startAddress + i), data[i]);
                    }
                    return keyValuePairs;
                }
                return null;
            }
            catch (Exception ex)
            {

                FileLog.GetInstance().SySLog("通讯超时:" + ex.ToString());
                return null;
            }

        }

        public void WriteSingleRegister(ushort registerAddress, ushort value, byte salveId = 1)
        {
            try
            {
                // 发送Modbus写入命令
                modbusMaster?.WriteSingleRegister(salveId, registerAddress, value);
                FileLog.GetInstance().SySLog($"单写：设备ID:{salveId}   寄存器地址:{registerAddress.ToString("X4")}   值:{value}");
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show(ex.Message);
                FileLog.GetInstance().SySLog("通讯超时:" + ex.ToString());
            }

        }

        public void WriteMultipleRegisters(ushort startAddress, ushort[] values, byte salveId = 1)
        {
            try
            {
                // 发送Modbus写入命令
                modbusMaster?.WriteMultipleRegisters(salveId, startAddress, values);
                FileLog.GetInstance().SySLog($"单写：设备ID:{salveId}   开始地址:{startAddress.ToString("X4")}   值:{string.Join(" ", values)}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"写入失败设备ID:{salveId}" + ex.Message);

                FileLog.GetInstance().SySLog("通讯超时:" + ex.ToString());
            }
        }


        public Action<int, ItemReadItems> RealtimeDataSend = null;
        public Action<int, ItemReadItems> RealtimeDataSendSingal = null;

        public Action<int, string> RealtimeDataSendConfig = null;

       



        public void ModBusReadReal(ushort startAddress, ushort numRegisters, byte[] salveIds)
        {
            Task.Run(() =>
            {

                while (IsRealtime)
                {
                    foreach (byte salveid in salveIds)
                    {
                        try
                        {
                            Dictionary<ushort, ushort> keyValuePairs = new Dictionary<ushort, ushort>();
                            // 发送Modbus读取命令，并接收响应报文
                            ushort[] data = modbusMaster?.ReadHoldingRegisters(salveid, startAddress, numRegisters);
                            FileLog.GetInstance().SySLog($"读回：设备ID:{salveid}   开始地址:{startAddress.ToString("X4")}   读取位数:{numRegisters} => 值:{string.Join(" ", data)}");

                            if (data != null)
                            {
                                for (int i = 0; i < data.Length; i++)
                                {
                                    keyValuePairs.Add(Convert.ToUInt16(startAddress + i), data[i]);
                                }
                                //var mmmo = DataAnalyze.GetInstance().RealDataAnalyz(keyValuePairs);
                                RealtimeDataSend?.Invoke((int)salveid, DataAnalyze.GetInstance().RealDataAnalyz(keyValuePairs));

                                if (salveid == salveIdReal)
                                {
                                    RealtimeDataSendSingal?.Invoke((int)salveid, DataAnalyze.GetInstance().RealDataAnalyz(keyValuePairs));
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            //IsRealtime = false;
                            FileLog.GetInstance().SySLog("通讯超时:" + ex.ToString());

                        }
                        Thread.Sleep(1000);
                    }
                }
            });


        }

    }


}
