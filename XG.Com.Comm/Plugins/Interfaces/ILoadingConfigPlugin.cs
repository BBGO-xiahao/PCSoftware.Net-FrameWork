using System.Threading.Tasks;
using XG.Comm.Core;

namespace XG.Com.Comm
{
    /// <summary>
    /// 当正在配置Config时触发。
    /// </summary>
    public interface ILoadingConfigPlugin<in TSender> : IPlugin
    {
        /// <summary>
        /// 当载入配置时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        Task OnLoadingConfig(TSender sender, ConfigEventArgs e);
    }

    /// <summary>
    /// ILoadingConfigPlugin
    /// </summary>
    public interface ILoadingConfigPlugin : ILoadingConfigPlugin<object>
    {

    }
}
