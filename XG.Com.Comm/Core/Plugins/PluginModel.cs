using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XG.Comm.Core
{
    internal class PluginModel
    {
        public List<Func<object, PluginEventArgs, Task>> Funcs = new List<Func<object, PluginEventArgs, Task>>();
     
        public List<PluginEntity> PluginEntities = new List<PluginEntity>();
    }
}
