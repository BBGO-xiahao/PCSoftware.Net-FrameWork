using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XG.Com.LogHelper
{
    public class LogInfo
    {
        public DateTime AddTime { get; set; }
        public string log { get; set; }
        public string logType { get; set; }


    }
    public enum LogType
    {

        /// <summary>
        /// 异常
        /// </summary>
        ExpectionLog = 0,

        /// <summary>
        /// 调试
        /// </summary>
        DebugLog = 1,

        /// <summary>
        /// 系统
        /// </summary>
        SySLog = 2,

        /// <summary>
        /// 警告类日志输出
        /// </summary>
        CommLog = 3,

        /// <summary>
        /// 流程
        /// </summary>
        ProcessLog = 4,

    }
}
