using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XG.Com.LogHelper
{
    /*
     * 日志捕获异常不抛出是为了就算日志异常也不影响进程
     * 
     */

    /// <summary>
    /// 日志
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseLogHelper
    {
        private ConcurrentQueue<LogInfo> logQueue = new ConcurrentQueue<LogInfo>();
        public ILoggerConfig config = null;



        /// <summary>
        /// 开启写入任务
        /// 该任务从初始化后会一直进行
        /// </summary>
        public void WriteTask()
        {
            while (true)
            {
                Thread.Sleep(100);
                if (logQueue.Count>10000)
                {
                    logQueue = new ConcurrentQueue<LogInfo>();
                }
                if (!logQueue.IsEmpty)
                {
                    LogInfo logInfo = null;
                    while (logQueue.TryDequeue(out logInfo))
                    {
                        Write(logInfo);
                    }
                }

            }
        }


        /// <summary>
        /// 添加日志
        /// 先添加到队列，然后任务执行
        /// </summary>
        /// <param name="log"></param>
        /// <param name="logType"></param>
        protected void Log(string log, LogType logType = LogType.ExpectionLog)
        {
            Log(log, logType.ToString());
        }
        /// <summary>
        /// 添加日志
        /// 先添加到队列，然后任务执行
        /// </summary>
        /// <param name="log"></param>
        /// <param name="logType"></param>
        private void Log(string log, string logType)
        {
            var logInfo = new LogInfo { AddTime = DateTime.Now, log = log, logType = logType.ToString() };
            logQueue.Enqueue(logInfo);
        }
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="logInfo"></param>
        private void Write(LogInfo logInfo)
        {


            try
            {
                if (config != null)
                {
                    config.Write(logInfo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }


}
