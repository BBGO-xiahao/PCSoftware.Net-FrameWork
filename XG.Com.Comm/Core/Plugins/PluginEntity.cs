using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XG.Comm.Core
{
    internal class PluginEntity
    {
       public Method Method;
       public IPlugin Plugin;

        public PluginEntity(Method method, IPlugin plugin)
        {
            this.Method = method;
            this.Plugin = plugin;
        }
    }
}
