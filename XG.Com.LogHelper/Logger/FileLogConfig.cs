using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace XG.Com.LogHelper
{
    public class FileLogConfig : ILoggerConfig
    {


        private string logDirPath = "./Log";


        public void Write(LogInfo logInfo)
        {


            var dirPath = Path.Combine(logDirPath);
            var filePath = Path.Combine(dirPath, $"{logInfo.logType}_{logInfo.AddTime.ToString("yyyy-MM-dd")}.log");
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
           
            try
            {
                if (!File.Exists(filePath)) // 如果文件不存在
                {
                    File.Create(filePath).Close();
                }
                while (IsFileInUse(filePath))
                {
                    Thread.Sleep(100);
                }
              
                using (var filestream= File.Open(filePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                {
                    try
                    {
                        using (var streamWriter = new StreamWriter(filestream))
                        {

                            var content = string.Format("{0} :{1}", logInfo.AddTime.ToString("yyyy-MM-dd HH:mm:ss"), logInfo.log.ToString());
                            streamWriter.WriteLine(content);
                            streamWriter.Flush();
                        }
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                   
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }








        }

        public  bool IsFileInUse(string filePath)
        {
            try
            {

                using (var filestream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {

                    filestream.Close();
                    return false;
                }
            }catch (Exception  ex)
            {
                return true;
            }
        }
    }
}
