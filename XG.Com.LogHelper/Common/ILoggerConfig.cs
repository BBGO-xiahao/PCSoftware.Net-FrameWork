using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XG.Com.LogHelper
{
    public interface ILoggerConfig
    {
        void Write(LogInfo logInfo);
    }
}
