#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 命名空间：TestProject
 * 文件名：DataBaseOpearation
 * 
 * 创建者：夏浩
 * 电子邮箱：🤮🤮🤮🤮
 * 创建时间：2023/6/26 22:50:05
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 修改人：夏浩
 * 时间：2023/6/26 22:50:05
 * 修改说明：
 *
 * 版本：V1.0.1
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Windows.Forms;
using TestProject.DataBase;

namespace TestProject
{
    public partial class DataBaseOpearation : Form
    {
        public DataBaseOpearation()
        {
            InitializeComponent();
        }

        #region MySqlDB
        public User userModule = new User();
        public UserBLL userBLL = new UserBLL();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            userModule.id = int.Parse(textBox1.Text);
            userModule.name = textBox2.Text;
            userModule.age = int.Parse(textBox3.Text);

            bool isAdd = userBLL.Add(userModule);
            if (isAdd)
                this.label2.Text = "增加数据成功";

            Select();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            bool isDelete = userBLL.Delete(int.Parse(textBox1.Text));
            if (isDelete)
                this.label3.Text = "数据删除成功";

            Select();
        }


     
        private void btnConnect_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(DbHelperMySQL.connectionString))
            {
                MessageBox.Show("成功");
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            Select();
            /*查询*/

        }
        #endregion
        private void btnRevise_Click(object sender, EventArgs e)
        {
            userModule.id = int.Parse(textBox1.Text);
            userModule.name = textBox2.Text;
            userModule.age = int.Parse(textBox3.Text);

            bool isUpdate = userBLL.Update(userModule);
            if (isUpdate)
                this.label4.Text = "修改数据成功";
        }
        private void Select()
        {
            this.dgvDataBase.Rows.Clear();
            //查
            List<User> userlist = userBLL.GetModelList("");
            foreach (User item in userlist)
            {
                DataGridViewRow row = new DataGridViewRow();

                DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                cell.Value = item.id;
                DataGridViewTextBoxCell cell2 = new DataGridViewTextBoxCell();
                cell2.Value = item.name;
                DataGridViewTextBoxCell cell3 = new DataGridViewTextBoxCell();
                cell3.Value = item.age;
                row.Cells.Add(cell);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);

                this.dgvDataBase.Rows.Add(row);
            }
            //this.label1.Text = "查询出user表：" + userlist.Count + "条记录";

            //int rowIndex = dgvDataBase.CurrentRow.Index;
            //if (rowIndex < 0) return;

            //textBox1.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            //textBox2.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            //textBox3.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();


        }

    }

    public class Test1
    {
        private static Test1 instance = null;

        private static readonly object Lock_instance = new object();

        public static Test1 GetInstance()
        {

            if (instance == null)
            {
                lock (Lock_instance)
                {
                    if (instance == null)
                    {
                        instance = new Test1();
                    }
                }
            }
            return instance;
        }

        public Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

    }
}

