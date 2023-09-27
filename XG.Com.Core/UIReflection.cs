using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XG.Com.Core
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

        public ContainerControl ReflectionUI(string dllPath, string objectName, Type type)
        {
            Assembly assembly = Assembly.LoadFrom(dllPath);

            // 获取UserControl的类型
            Type[] userControlType = assembly.GetTypes();
            foreach (Type t in userControlType)
            {
                if (t.IsSubclassOf(type)&& t.Name== objectName)
                {
                    // 创建UserControl实例
                    return (ContainerControl)Activator.CreateInstance(t);
                }
            }



            // 将UserControl添加到窗体中
            return null;
        }

    }
}
