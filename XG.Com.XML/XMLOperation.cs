using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XG.Com.XML
{
    public class XMLOperation
    {
        #region 标准单例

        private static XMLOperation instance = null;

        private static readonly object Lock_instance = new object();

        public static XMLOperation GetInstance()
        {
            if (instance == null)
            {
                lock (Lock_instance)
                {
                    if (instance == null)
                    {
                        instance = new XMLOperation();
                    }
                }
            }
            return instance;
        }
        #endregion

        //XML序列化的要求如下：
        //对象必须具有无参数的公共构造函数，以便在反序列化时能够实例化对象。
        //对象的属性和字段必须是公共的，以便能够被序列化和反序列化。
        //对象的属性和字段必须是可序列化的类型，即基本数据类型（如整数、字符串、布尔值等）、数组、集合、字典、自定义类等。
        //对象的属性和字段可以使用特性（如[XmlAttribute]、[XmlElement] 等）来指定在序列化时的XML元素名称和顺序。
        //对象的属性和字段可以使用特性（如[XmlIgnore]）来指定在序列化时忽略某些成员。
        //对象可以实现接口（如IXmlSerializable）来自定义序列化和反序列化的过程。

        private string file_name = "./Config/";

        public object xMLOperation = null;

        /// <summary>
        /// 文件化XML序列化
        /// </summary>

        public void XmlSave()
        {
            string filePath = $"./Config/{this.GetType().Name}.xml";
            FileStream fs = null;
            try
            {
                fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                XmlSerializer serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(fs, this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null) fs.Close();
            }
        }

        /// <summary>
        /// 文件化XML序列化
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="filename">文件路径</param>
        public void XmlSave(object obj, string filePath)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(fs, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null) fs.Close();
            }
        }

        /// <summary>
        /// 文件化XML序列化
        /// </summary>
        /// <param name="obj">对象</param>
        public void XmlSave(object obj)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream($"{file_name}{obj.GetType().Name}.xml", FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(fs, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null) fs.Close();
            }
        }
        public object XmlLoad()
        {
            FileStream fs = null;
            try
            {
                string filePath = $"./Config/{this.GetType().Name}.xml";
                fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                XmlSerializer serializer = new XmlSerializer(this.GetType());

                return serializer.Deserialize(fs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null) fs.Close();
            }
        }

        public object XmlLoad(string filename)
        {
            FileStream fs = null;
            try
            {
                string filePath = filename;
                fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                XmlSerializer serializer = new XmlSerializer(this.GetType());

                return serializer.Deserialize(fs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null) fs.Close();
            }
        }
        /// <summary>
        /// 文件化XML反序列化
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="filename">文件路径</param>
        public object XmlLoad(Type type, string filename)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                XmlSerializer serializer = new XmlSerializer(type);
                return serializer.Deserialize(fs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null) fs.Close();
            }
        }
        /// <summary>
        /// 文件化XML反序列化
        /// </summary>
        /// <param name="type">对象类型</param>
        public object XmlLoad(Type type)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream($"{file_name}{type.Name}.xml", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                fs.Position = 0;
                XmlSerializer serializer = new XmlSerializer(type);
                return serializer.Deserialize(fs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null) fs.Close();
            }
        }

        /// <summary>
        /// xml初始化
        /// </summary>
        /// <param name="type"></param>
        public object XmlInit(object objectClass)
        {
            try
            {
                if (Directory.Exists(file_name) == false) { Directory.CreateDirectory(file_name); }
                if (File.Exists($"{file_name}{objectClass.GetType().Name}.xml"))
                {
                    return XmlLoad(objectClass.GetType());
                }
                else
                {
                    XmlSave(objectClass);
                    return objectClass;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



    }
}
