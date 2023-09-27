using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace XG.Com.XML
{
    public class InitXML
    {
        #region 标准单例

        private static InitXML instance = null;

        private static readonly object Lock_instance = new object();

        public static InitXML GetInstance()
        {
            if (instance == null)
            {
                lock (Lock_instance)
                {
                    if (instance == null)
                    {
                        instance = new InitXML();
                    }
                }
            }
            return instance;
        }
        #endregion
        public void XMLInit()
        {
            string path = "./"; // 替换为你的文件夹路径
            string[] dllFiles = Directory.GetFiles(path, "*.dll");
            foreach (string dllFile in dllFiles)
            {
                Assembly assembly = Assembly.LoadFile(Path.GetFullPath(dllFile));
                Type[] types = assembly.GetTypes();
                //Type ClsaaType = typeof(XMLOperation); // 替换为你的类型

                foreach (Type type in types)
                {
                    //Type ClsaaType = typeof(XMLOperation);
                    if (type.IsAssignableFrom(type) && !type.IsAbstract && !type.IsInterface && type.IsSubclassOf(typeof(XMLOperation)))
                    {
                        MethodInfo method = type.GetMethod("XmlInit");
                        // 创建实例
                        //object instance = Activator.CreateInstance(type);
                        //FieldInfo instanceField = type.GetField("instance", BindingFlags.NonPublic | BindingFlags.Static);
                        FieldInfo instanceField= type.GetField("instance", BindingFlags.NonPublic | BindingFlags.Static);
                        // 调用GetValue方法获取Singleton的实例
                        var  singleton = instanceField.GetValue(null);
                        // 获取方法
                        //MethodInfo method = type.GetMethod("XmlInit", new Type[] { });
                        //MethodInfo method = ClsaaType.GetMethod("XmlInit", BindingFlags.Instance);

                        // 判断方法是否存在并且可调用
                        if (method != null && method.IsPublic && !method.IsAbstract)
                        {
                            // 调用方法
                            instanceField.SetValue(singleton, method.Invoke(singleton, new object[] { singleton }));

                        }
                    }
                }
            }
        }
    }
}
