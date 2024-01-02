using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using XG.Com.LogHelper;
using XG.Com.Reflection;
//using XG.Com.LogHelper;
using XG.Com.Test;
using XG.Com.UI;
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

            //组合键使用
            GlobalKeyboardHook hook = new GlobalKeyboardHook(new Keys[] { Keys.LControlKey, Keys.A, Keys.B, Keys.C });
            hook.KeysPressed += (sender, e) =>
            {
                Console.WriteLine("Ctrl + A + B + C pressed");
            };
            hook.HookKeyboard();

            //Application.Run();

            //hook.UnhookKeyboard();

        }




        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.H | Keys.M))
            {

                //FromAdd(fromIsVisable);
                //fromIsVisable = !fromIsVisable;
                // 执行保存操作
                return true; // 返回true表示已经处理了按键事件
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void btnLog_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                for (int i = 0; i < 100000; i++)
                {
                    FileLog.GetInstance().DebugLog("123");
                    Thread.Sleep(100);
                    //Console.WriteLine(i);
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
            XMLTest.GetInstance().XmlSave();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var mm=XMLTest.GetInstance().Ip;
        }

        private void UIReflection_Click(object sender, EventArgs e)
        {
            var mm = ReflectionHelper.GetInstance().ReflectionUI("XG.Com.UI.dll", "HeadTitle", typeof(UserControl));
            mm.Dock = DockStyle.Fill;
        }
    }
}
