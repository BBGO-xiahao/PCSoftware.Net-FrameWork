using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XG.Com.LogHelper;

namespace XG.Comm.SerialPort
{
    public class SerialPortManage
    {
        #region 标准的单例

        /*写双重判断的原因如下
        在极低的几率下，通过if(instance == NULL)的线程才会有进入锁定临界区的可能性，这种几率还是比较低的，
        不会阻塞太多的线程，但为了防止一个线程进入临界区创建实例，另外的线程也进去临界区创建实例，
        又加上了一道防御if(instance == NULL)，这样就确保不会重复创建了。
        */
        private static SerialPortManage instance = null;

        private static readonly object Lock_instance = new object();

        public static SerialPortManage GetInstance()
        {
            if (instance == null)
            {
                lock (Lock_instance)
                {
                    if (instance == null)
                    {
                        instance = new SerialPortManage();
                    }
                }
            }
            return instance;
        }


        #endregion
       
    }


}
