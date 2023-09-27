using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParse
{
    public class BinFileParse 
    {

        public byte[] Parse(string filePath)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                // 获取文件长度
                long fileSize = new FileInfo(filePath).Length;

                // 读取数据到byte数组
                return reader.ReadBytes((int)fileSize);
            }
        }
    }
}
