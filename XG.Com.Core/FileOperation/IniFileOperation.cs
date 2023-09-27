using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.UI
{
    public  class IniFileOperation
    {

        #region 标准的单例

        /*写双重判断的原因如下
        在极低的几率下，通过if(instance == NULL)的线程才会有进入锁定临界区的可能性，这种几率还是比较低的，
        不会阻塞太多的线程，但为了防止一个线程进入临界区创建实例，另外的线程也进去临界区创建实例，
        又加上了一道防御if(instance == NULL)，这样就确保不会重复创建了。
        */
        private static IniFileOperation instance = null;

        private static readonly object Lock_instance = new object();

        public static IniFileOperation GetInstance()
        {
            if (instance == null)
            {
                lock (Lock_instance)
                {
                    if (instance == null)
                    {
                        instance = new IniFileOperation();
                    }
                }
            }
            return instance;
        }

      

        #endregion
        public  Dictionary<string, Dictionary<string, string>> ReadIniFile(string filePath)
        {
            Dictionary<string, Dictionary<string, string>> iniData = new Dictionary<string, Dictionary<string, string>>();

            string currentSection = null;
            Dictionary<string, string> currentSectionData = null;

            foreach (string line in File.ReadLines(filePath))
            {
                string trimmedLine = line.Trim();

                if (IsSectionHeader(trimmedLine))
                {
                    currentSection = GetSectionName(trimmedLine);
                    currentSectionData = new Dictionary<string, string>();
                    iniData[currentSection] = currentSectionData;
                }
                else if (!string.IsNullOrEmpty(trimmedLine))
                {
                    KeyValuePair<string, string> keyValue = GetKeyValuePair(trimmedLine);
                    if (!string.IsNullOrEmpty(keyValue.Key))
                    {
                        currentSectionData[keyValue.Key] = keyValue.Value;
                    }
                }
            }

            return iniData;
        }

        public  void WriteIniFile(string filePath, Dictionary<string, Dictionary<string, string>> iniData)
        {
            string directoryPath = Path.GetDirectoryName(filePath);
            Directory.CreateDirectory(directoryPath);
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (KeyValuePair<string, Dictionary<string, string>> section in iniData)
                {
                    writer.WriteLine($"[{section.Key}]");

                    foreach (KeyValuePair<string, string> keyValue in section.Value)
                    {
                        writer.WriteLine($"{keyValue.Key}={keyValue.Value}");
                    }

                    writer.WriteLine();
                }
            }
        }

        private  bool IsSectionHeader(string line)
        {
            return line.StartsWith("[") && line.EndsWith("]");
        }

        private  string GetSectionName(string line)
        {
            return line.Substring(1, line.Length - 2);
        }

        private  KeyValuePair<string, string> GetKeyValuePair(string line)
        {
            int equalIndex = line.IndexOf('=');
            if (equalIndex >= 0)
            {
                string key = line.Substring(0, equalIndex).Trim();
                string value = line.Substring(equalIndex + 1).Trim();
                return new KeyValuePair<string, string>(key, value);
            }

            return default;
        }

    }
}
