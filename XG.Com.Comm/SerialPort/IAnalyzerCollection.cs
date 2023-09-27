using System.Collections;
using System.Collections.Generic;

namespace XG.Comm.SerialPort
{
    /// <summary>
    /// 数据解析方法类集合
    /// </summary>
    public interface IAnalyzerCollection : IEnumerable<IAnalyzer>, IEnumerable { }
}
