using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comm.Core
{
    public class DataConvert
    {
        private static DataConvert instance = null;
        private static readonly object LockObject = new object();
        private DataConvert() { }

        public static DataConvert GetInstance()
        {
            //双重锁定
            if (instance == null)//只有为null需要实例化处理时才进行加锁，提高性能避免不必要的等待
            {
                lock (LockObject)
                {
                    if (instance == null)//避免其他线程等待锁释放期间有线程已经实例化，从而造成多个实例
                        instance = new DataConvert();
                }
            }
            return instance;
        }

        
        public  byte[] IntToBytesBig(int value)
        {
            byte[] src = new byte[4];
            src[0] = (byte)((value >> 24) & 0xFF);
            src[1] = (byte)((value >> 16) & 0xFF);
            src[2] = (byte)((value >> 8) & 0xFF);
            src[3] = (byte)(value & 0xFF);
            return src;
        }
        public byte[] ShortToBytesBig(short value)
        {
            byte[] src = new byte[2];
            src[0] = (byte)(value >> 8);
            src[1] = (byte)value ;
            
            return src;
        }

        public  byte[] IntToBytesLittle(int value)
        {
            byte[] src = new byte[4];
            src[3] = (byte)((value >> 24) & 0xFF);
            src[2] = (byte)((value >> 16) & 0xFF);
            src[1] = (byte)((value >> 8) & 0xFF);
            src[0] = (byte)(value & 0xFF);
            return src;
        }
       
        public  int BytesToIntBig(byte[] src, int offset)
        {
            int value;
            value = (int)(((src[offset] & 0xFF) << 24)
                    | ((src[offset + 1] & 0xFF) << 16)
                    | ((src[offset + 2] & 0xFF) << 8)
                    | (src[offset + 3] & 0xFF));
            return value;
        }
       
        public  int BytesToIntLittle(byte[] src, int offset)
        {
            int value;
            value = (int)((src[offset] & 0xFF)
                    | ((src[offset + 1] & 0xFF) << 8)
                    | ((src[offset + 2] & 0xFF) << 16)
                    | ((src[offset + 3] & 0xFF) << 24));
            return value;
        }

        public Dictionary<int, bool> BitinfoAnsly(ushort value)
        {
            Dictionary<int, bool> keyValuePairs = new Dictionary<int, bool>();
            byte[] bytes = BitConverter.GetBytes(value);

            // 将byte数组转换为BitArray
            BitArray bitArray = new BitArray(bytes);
            for (int i = 0; i < bitArray.Length; i++)
            {
                keyValuePairs.Add(i, bitArray[i]);
            }
            return keyValuePairs;
        }


    }
}
