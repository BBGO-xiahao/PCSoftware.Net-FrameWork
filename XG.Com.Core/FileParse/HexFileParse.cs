using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParse
{
    public class HexFileParse 
    {
        public int startAddress = 0;//解析的起始地址
        public int endAddress = 0;//解析的终止地址
        public int dataLength = 0;//字节总长度=endAddress-startAddress+1

        public string startExtendedAddress = "0000";//第一个扩展地址
        public string endExtendedAddress = "0000";//最后一个扩展地址
        public bool isFirstExtendedAddress = true;//是否是第一次检测到“0x04”

        public string startDataAddress = "0000";//第一个数据地址【对应startExtendedAddress】
        public string endDataAddress = "0000";//最后一个数据地址【对应endExtendedAddress】
        public bool isFirstDataAddress = true;//是否是第一次检测到“0x00”

        public string lastDataLength = "00";//最后一行的数据长度
        public byte[] Parse(string filePath)
        {
            try
            {
                //【01】获取hex文件的起始和终止地址(Lowest_Address和Highest_Address) ，并获取其字节长度(dataLength)
                GetAddress(filePath);

                //【02】填充数组内容
                //（情形1：所有地址内容都在hex文件中；情形2:在hex文件中有些地址内容缺失，需要填充默认值“0x00”或“0xFF”）
                return FillData(filePath, dataLength);

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void GetAddress(string hexPath)
        {
            FileStream fsRead = new FileStream(hexPath, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader HexReader = new StreamReader(fsRead); //读取数据流

            while (true)
            {
                string currentLineData = HexReader.ReadLine(); //读取Hex中一行
                if (currentLineData == null) { break; } //读取完毕，退出
                if (currentLineData.Substring(0, 1) == ":") //判断首字符是”:”
                {
                    if (currentLineData.Substring(1, 8) == "00000001")
                    {
                        if (endExtendedAddress == "0000")
                        {
                            endAddress = Convert2Hex(startExtendedAddress + endDataAddress) + Convert2Hex(lastDataLength) - 1;//获得终止地址
                            dataLength = endAddress - startAddress + 1;
                        }
                        else
                        {
                            endAddress = Convert2Hex(endExtendedAddress + endDataAddress) + Convert2Hex(lastDataLength) - 1;//获得终止地址
                            dataLength = endAddress - startAddress + 1;
                        }

                        break;
                    } //文件结束标识

                    string type = currentLineData.Substring(7, 2);

                    switch (type)
                    {
                        case "04":
                            if (isFirstExtendedAddress)
                            {
                                startExtendedAddress = currentLineData.Substring(9, 4);
                                isFirstExtendedAddress = false;
                            }
                            else
                            {
                                endExtendedAddress = currentLineData.Substring(9, 4);
                            }
                            break;
                        case "00":
                            if (isFirstDataAddress)
                            {
                                startDataAddress = currentLineData.Substring(3, 4);
                                startAddress = Convert2Hex(startExtendedAddress + startDataAddress);//获得起始地址
                                isFirstDataAddress = false;
                            }
                            else
                            {
                                endDataAddress = currentLineData.Substring(3, 4);
                                lastDataLength = currentLineData.Substring(1, 2);//为了获取最后一行的字节长度
                            }
                            break;
                        default:
                            break;

                    }

                }
            }

            HexReader.Close();
            fsRead.Close();
        }

        /// <summary>
        /// 【第3步】将数组写到bin文件
        /// </summary>
        /// <param name="binPath">新建bin文件的路径</param>
        /// <param name="buffer">写入的字节数组</param>
        /// <param name="startIndex">开始索引</param>
        /// <param name="length">写入的字节长度</param>
        private void WritetoBinFile(string binPath, byte[] buffer, int startIndex, int length)
        {
            FileStream fsWrite = new FileStream(binPath, FileMode.Create, FileAccess.Write);//如果已存在相同文件名的文件,则删掉之前的，创建新的文件！！！
            fsWrite.Write(buffer, startIndex, length);
            fsWrite.Close();
        }

        /// <summary>
        ///【第2步】填充数组内容
        /// </summary>
        /// <param name="hexPath">hex文件路径</param>
        /// <param name="buffer">填充的字节数组</param>
        private byte[] FillData(string hexPath, int bufferLength)
        {
            byte[] buffer = new byte[bufferLength];

            int lastLine_EndAddress_Real = startAddress;//上一行结束的真实地址【扩展地址+数据地址】,初始值为hex文件的起始地址
            int currentLine_StartAddress_Real = 0;//下一行开始的真实地址【扩展地址+数据地址】

            string currentExtendedAddress = "0000";//当前扩展地址
            string currentLineDataAddress = "0000";//当前数据地址

            int current_BufferIndex = 0;

            FileStream fsRead = new FileStream(hexPath, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader HexReader = new StreamReader(fsRead); //读取数据流


            while (true)
            {
                string currentLineData = HexReader.ReadLine(); //读取Hex中一行
                if (currentLineData == null) { break; } //读取完毕，退出
                if (currentLineData.Substring(0, 1) == ":") //判断首字符是”:”
                {
                    //文件结束标识
                    if (currentLineData.Substring(1, 8) == "00000001")
                    {
                        break;
                    }

                    string type = currentLineData.Substring(7, 2);//读取当前行的类型

                    switch (type)
                    {
                        case "04":
                            currentExtendedAddress = currentLineData.Substring(9, 4);
                            break;
                        case "00":
                            currentLineDataAddress = currentLineData.Substring(3, 4);//当前数据地址

                            currentLine_StartAddress_Real = Convert2Hex(currentExtendedAddress + currentLineDataAddress);//实际开始地址值

                            //如果这一次的起始地址不等于上一次结束的下一个地址，则填充"0x00"
                            if (currentLine_StartAddress_Real != lastLine_EndAddress_Real)
                            {
                                for (int i = 0; i < currentLine_StartAddress_Real - lastLine_EndAddress_Real; i++) // 补空位置
                                {
                                    byte value = byte.Parse("00", NumberStyles.HexNumber);
                                    buffer[current_BufferIndex] = value;
                                    current_BufferIndex++;
                                }
                            }

                            int currentLine_DataLength = Convert2Hex(currentLineData.Substring(1, 2));//获取当前行的数据长度

                            for (int i = 0; i < currentLine_DataLength; i++)
                            {
                                byte value = byte.Parse(currentLineData.Substring(i * 2 + 9, 2), NumberStyles.HexNumber);
                                buffer[current_BufferIndex] = value;
                                current_BufferIndex++;
                            }

                            lastLine_EndAddress_Real = currentLine_StartAddress_Real + currentLine_DataLength;

                            break;
                        default:
                            break;

                    }



                }
            }

            //关闭Stream和文件
            HexReader.Close();
            fsRead.Close();

            //hex文件最后没有的byte填充“00”
            if (buffer.Length > current_BufferIndex)
            {
                for (int i = 0; i < buffer.Length - current_BufferIndex; i++)
                {
                    byte value = byte.Parse("FF", NumberStyles.HexNumber);
                    buffer[current_BufferIndex + i] = value;
                }
            }
            return buffer;
        }
        private int Convert2Hex(string content)
        {
            return Convert.ToInt32(content, 16);
        }
    }
}
