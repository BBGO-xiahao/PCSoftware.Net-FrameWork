using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XG.Com.LogHelper
{
    /// <summary>
    /// 默认实现的logger 
    /// </summary>
    public class FileLog: BaseLogHelper
    {
        #region 标准的单例

        /*写双重判断的原因如下
        在极低的几率下，通过if(instance == NULL)的线程才会有进入锁定临界区的可能性，这种几率还是比较低的，
        不会阻塞太多的线程，但为了防止一个线程进入临界区创建实例，另外的线程也进去临界区创建实例，
        又加上了一道防御if(instance == NULL)，这样就确保不会重复创建了。
        */
        private static FileLog instance = null;

        private static readonly object Lock_instance = new object();

        public static FileLog GetInstance()
        {
            if (instance == null)
            {
                lock (Lock_instance)
                {
                    if (instance == null)
                    {
                        instance = new FileLog();
                    }
                }
            }
            return instance;
        }

        #endregion
       

        FileLog()
        {
            base.config = new FileLogConfig();
            Task.Factory.StartNew( base.WriteTask);
        }
        private string  Log(object message = null, Exception exception = null)
        {
            var stringBuilder = new StringBuilder();
          
            if (message != null)
            {
                stringBuilder.Append(message.ToString());
            }

            if (exception != null)
            {
                stringBuilder.Append(" | ");
                stringBuilder.Append($"【异常消息】：{exception.Message}");
                stringBuilder.Append($"【堆栈】：{(exception == null ? "未知" : exception.StackTrace)}");
            }
          
            return stringBuilder.ToString();
        }
        
        public void ExpectionLog(object message = null, Exception exception = null)
        {
            Log(Log(message, exception), LogType.ExpectionLog);
        }
        public void DebugLog(object message = null, Exception exception = null)
        {
           
                Log(Log(message, exception), LogType.DebugLog);
            

        }
        public void SySLog(object message = null, Exception exception = null)
        {
            Log(Log(message, exception), LogType.SySLog);
        }
        public void CommLog(object message = null, Exception exception = null)
        {
            Log(Log(message, exception), LogType.CommLog);
        }
        public void ProcessLog(object message = null, Exception exception = null)
        {
            Log(Log(message, exception), LogType.ProcessLog);
        }
    }
}
