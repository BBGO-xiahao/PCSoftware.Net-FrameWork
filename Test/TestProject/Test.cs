using System;
<<<<<<< HEAD
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
=======
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using XG.Com.Core;
//using XG.Com.LogHelper;
using XG.Com.Test;
>>>>>>> 47918044a81170e4fe7c9b34c2884e25f3dfd583
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

<<<<<<< HEAD
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
=======
        }

>>>>>>> 47918044a81170e4fe7c9b34c2884e25f3dfd583
        private void btnLog_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
<<<<<<< HEAD
                for (int i = 0; i < 100000; i++)
                {
                    FileLog.GetInstance().DebugLog("123");
                    Thread.Sleep(100);
                    //Console.WriteLine(i);
=======
                for (int i = 0; i < 20; i++)
                {
                    //LogUtil.GetInstance().Log("123");
                    Thread.Sleep(2000);
                    Console.WriteLine(i);
>>>>>>> 47918044a81170e4fe7c9b34c2884e25f3dfd583
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
<<<<<<< HEAD
            XMLTest.GetInstance().XmlSave();
=======
>>>>>>> 47918044a81170e4fe7c9b34c2884e25f3dfd583
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var mm=XMLTest.GetInstance().Ip;
        }

        private void UIReflection_Click(object sender, EventArgs e)
        {
            var mm = ReflectionHelper.GetInstance().ReflectionUI("XG.Com.UI.dll", "HeadTitle", typeof(UserControl));
<<<<<<< HEAD
            mm.Dock = DockStyle.Fill;
=======
            mm.Dock= DockStyle.Fill;
>>>>>>> 47918044a81170e4fe7c9b34c2884e25f3dfd583
        }
    }
}
