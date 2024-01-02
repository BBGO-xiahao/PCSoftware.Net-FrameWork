using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
using System.Windows.Forms;
=======
>>>>>>> 47918044a81170e4fe7c9b34c2884e25f3dfd583

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
<<<<<<< HEAD
        public ContainerControl ReflectionUI(string dllPath, string objectName, Type type)
        {
            Assembly assembly = Assembly.LoadFrom(dllPath);

            // 获取UserControl的类型
            Type[] userControlType = assembly.GetTypes();
            foreach (Type t in userControlType)
            {
                if (t.IsSubclassOf(type) && t.Name == objectName)
                {
                    // 创建UserControl实例
                    return (ContainerControl)Activator.CreateInstance(t);
                }
            }
            // 将UserControl添加到窗体中
            return null;
        }
        #endregion


=======
        #endregion

       
>>>>>>> 47918044a81170e4fe7c9b34c2884e25f3dfd583
    }
}
