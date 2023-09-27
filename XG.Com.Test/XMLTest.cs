using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XG.Com.XML;

namespace XG.Com.Test
{
    public class XMLTest : XMLOperation
    {

        #region 标准单例

        private static XMLTest instance = new XMLTest();

        private static readonly object Lock_instance = new object();

        public static XMLTest GetInstance()
        {
            if (instance == null)
            {
                lock (Lock_instance)
                {
                    if (instance == null)
                    {
                        instance = new XMLTest();
                    }
                }
            }
            return instance;
        }

        #endregion
        private string ip = "127.0.0.1";

        public string Ip { get => ip; set => ip = value; }
    }

   
}
