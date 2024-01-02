//------------------------------------------------------------------------------
//  此代码版权（除特别声明或在XREF结尾的命名空间的代码）归作者本人若汝棋茗所有
//  源代码使用协议遵循本仓库的开源协议及附加协议，若本仓库没有设置，则按MIT开源协议授权
//  CSDN博客：https://blog.csdn.net/qq_40374647
//  哔哩哔哩视频：https://space.bilibili.com/94253567
//  Gitee源代码仓库：https://gitee.com/RRQM_Home
//  Github源代码仓库：https://github.com/RRQM
//  API首页：http://rrqm_home.gitee.io/touchsocket/
//  交流QQ群：234762506
//  感谢您的下载和使用
//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
using System;
using System.IO;
using System.Text;
using XG.Com.Core;

namespace XG.Com.LogHelper
{
    /// <summary>
    /// 文件日志记录器
    /// <para>会在指定目录下，生成logs文件夹，然后按[yyyy-MM-dd].log的形式，每日生成日志</para>
    /// </summary>
    public class LogUtil : ILog
    {
        #region 标准的单例

        /*写双重判断的原因如下
        在极低的几率下，通过if(instance == NULL)的线程才会有进入锁定临界区的可能性，这种几率还是比较低的，
        不会阻塞太多的线程，但为了防止一个线程进入临界区创建实例，另外的线程也进去临界区创建实例，
        又加上了一道防御if(instance == NULL)，这样就确保不会重复创建了。
        */
        private static LogUtil instance = null;

        private static readonly object Lock_instance = new object();



        public static LogUtil GetInstance()
        {
            if (instance == null)
            {
                lock (Lock_instance)
                {
                    if (instance == null)
                    {
                        instance = new LogUtil();
                    }
                }
            }
            return instance;
        }

        #endregion
        private readonly object m_lock = new object();
        private readonly string m_rootPath;


        private FileStorageWriter m_writer;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="rootPath">日志根目录</param>
        public LogUtil(string rootPath = "Log")
        {
            if (rootPath is null)
            {
                throw new ArgumentNullException(nameof(rootPath));
            }
            this.m_rootPath = rootPath;
        }


        /// <summary>
        /// 最大日志尺寸
        /// </summary>
        public int MaxSize { get; set; } = 1024 * 1024;


        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="source"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Log(object message = null, Exception exception = null, LogType logLevel = LogType.ExpectionLog)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            stringBuilder.Append("  ");
            if (message==null)
            {
                stringBuilder.Append(message.ToString());

            }

            if (exception != null)
            {
                stringBuilder.Append(" | ");
                stringBuilder.Append($"【异常消息】：{exception.Message}");
                stringBuilder.Append($"【堆栈】：{(exception == null ? "未知" : exception.StackTrace)}");
            }
            stringBuilder.AppendLine();

            this.Print(logLevel, stringBuilder.ToString());
        }

        private void Print(LogType logLevel, string logString)
        {
            try
            {
                lock (this.m_lock)
                {
                    if (this.m_writer == null || this.m_writer.DisposedValue)
                    {
                        var dir = Path.Combine(this.m_rootPath);
                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }
                        var count = 0;
                        string path = null;
                        while (true)
                        {
                            path = Path.Combine(dir, $"{logLevel}_{DateTime.Now.ToString("[yyyy-MM-dd]")}#{count:0000}.log");
                            if (!File.Exists(path))
                            {
                                this.m_writer = FilePool.GetWriter(path);
                                this.m_writer.FileStorage.AccessTimeout = TimeSpan.MaxValue;
                                break;
                            }
                            count++;
                        }
                    }
                    this.m_writer.Write(Encoding.UTF8.GetBytes(logString));
                    this.m_writer.FileStorage.Flush();
                    if (this.m_writer.FileStorage.Length > this.MaxSize)
                    {
                        //this.m_writer.FileStorage.Flush();
                        this.m_writer.SafeDispose();
                        this.m_writer = null;
                    }
                    this.m_writer.SafeDispose();
                }
            }
            catch
            {
                this.m_writer.SafeDispose();
                this.m_writer = null;
            }
        }
    }
}