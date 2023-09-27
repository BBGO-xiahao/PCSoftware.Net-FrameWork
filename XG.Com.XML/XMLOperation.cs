using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XG.Com.XML
{
    public   class XMLOperation
    {
        private string file_name = "./Config/";

        public object xMLOperation = null;



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
        public object  XmlInit(object objectClass)
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
