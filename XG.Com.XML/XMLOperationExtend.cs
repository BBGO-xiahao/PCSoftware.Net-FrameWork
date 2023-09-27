using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XG.Com.XML
{
    public class XMLOperationExtend
    {
        #region 标准单例

        private static XMLOperationExtend instance = null;

        private static readonly object Lock_instance = new object();

        public static XMLOperationExtend GetInstance()
        {
            if (instance == null)
            {
                lock (Lock_instance)
                {
                    if (instance == null)
                    {
                        instance = new XMLOperationExtend();
                    }
                }
            }
            return instance;
        }
        #endregion


        public void SaveListToXml<T>(List<T> list, string fileName)
        {
            // 创建XmlSerializer对象
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>), new XmlRootAttribute($"ArrayOf{typeof(T).Name}"));

            // 使用StreamWriter来保存XML数据
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                // 调用Serialize方法将List<T>对象保存为XML文件
                serializer.Serialize(writer, list);
            }
        }

        // 从XML文件中读取List<T>对象
        public List<T> LoadListFromXml<T>(string fileName)
        {
            // 创建XmlSerializer对象
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>), new XmlRootAttribute($"ArrayOf{typeof(T).Name}"));

            // 使用StreamReader读取XML数据
            using (StreamReader reader = new StreamReader(fileName))
            {
                // 调用Deserialize方法将XML数据转换为List<T>对象
                List<T> list = (List<T>)serializer.Deserialize(reader);
                return list;
            }
        }
    }
}
