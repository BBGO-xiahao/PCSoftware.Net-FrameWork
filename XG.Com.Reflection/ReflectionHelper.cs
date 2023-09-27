using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XG.Com.Reflection
{
    public class ReflectionHelper
    {
        #region 标准单例

        private static ReflectionHelper instance = null;

        private static readonly object Lock_instance = new object();

        public static ReflectionHelper GetInstance()
        {
            if (instance == null)
            {
                lock (Lock_instance)
                {
                    if (instance == null)
                    {
                        instance = new ReflectionHelper();
                    }
                }
            }
            return instance;
        }
        #endregion

       
    }
}
