using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XG.Com.UI
{
    public class UIManager
    {
        private static UIManager instance = null;
        private static readonly object LockObject = new object();
        private UIManager() { }

        public static UIManager GetInstance()
        {
            //双重锁定
            if (instance == null)//只有为null需要实例化处理时才进行加锁，提高性能避免不必要的等待
            {
                lock (LockObject)
                {
                    if (instance == null)//避免其他线程等待锁释放期间有线程已经实例化，从而造成多个实例
                        instance = new UIManager();
                }
            }
            return instance;
        }

        public Action<string, string> UIShowINPanel = null;
        public Action<int> UIShowFirst = null;
        public bool IsDesignMode()
        {
            bool returnFlag = false;

#if DEBUG
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                returnFlag = true;
            }
            else if (Process.GetCurrentProcess().ProcessName == "devenv")
            {
                returnFlag = true;
            }
#endif

            return returnFlag;
        }

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

    }
}
