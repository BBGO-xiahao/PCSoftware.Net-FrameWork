using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using XG.Com.Core;
using XG.Com.LogHelper;
//using XG.Com.LogHelper;
using XG.Com.Test;
using XG.Com.XML;
//using XG.Com.Test;
//using XG.Com.XML;
//using XG.Com.LogHelper;

namespace TestProject
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();

        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    LogUtil.GetInstance().Log("123");
                    Thread.Sleep(2000);
                    Console.WriteLine(i);
                }


            });


        }

        private void btnClient_Click(object sender, EventArgs e)
        {

        }

        private void btnServer_Click(object sender, EventArgs e)
        {

        }

        private void btnMySQLDB_Click(object sender, EventArgs e)
        {
            DataBaseOpearation dataBase = new DataBaseOpearation();
            dataBase.Show();
        }

        private void btnXML_Click(object sender, EventArgs e)
        {
            //var mm=   XMLTest.GetInstance().Ip;

            InitXML.GetInstance().XMLInit();
            var mm = XMLTest.GetInstance().Ip;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var mm=XMLTest.GetInstance().Ip;
        }

        private void UIReflection_Click(object sender, EventArgs e)
        {
            var mm = ReflectionHelper.GetInstance().ReflectionUI("XG.Com.UI.dll", "HeadTitle", typeof(UserControl));
            mm.Dock= DockStyle.Fill;
        }
    }
}
