using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XG.Comm.Core
{
    internal class MemoryStreamFastBinaryConverter : FastBinaryConverter<MemoryStream>
    {
        protected override MemoryStream Read(byte[] buffer, int offset, int len)
        {
            var memoryStream = new MemoryStream(len);
            memoryStream.Write(buffer,offset,len);
            memoryStream.Position = 0;
            return memoryStream;
        }

        protected override int Write(ByteBlock byteBlock, MemoryStream obj)
        {

            var bytes = obj.ToArray();
            byteBlock.Write(bytes);
            return bytes.Length;
        }
    }
}
