using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XG.Com.UI
{
    internal class UITest
    {

        public void Init()
        {
            //List<CalParamU> list = new List<CalParamU>();
            //list.Add(new CalParamU() { Id = 0x2400, Readid = 0x1007, Name = "BMS自放电电流" });
            //XMLOperationExtend.GetInstance().SaveListToXml<CalParamU>(list, Path.GetFullPath("./Config/CalParamDataConfig.xml"));

            // 创建一个TableLayoutPanel
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
        int Clmcount=    tableLayoutPanel.ColumnCount = 1;
         int Rowcount=   tableLayoutPanel.RowCount =12/* DataAnalyze.GetInstance().itemReadItemsParamSet.Count*/;
            tableLayoutPanel.Dock = DockStyle.Fill; // 填充父容器
            tableLayoutPanel.AutoScroll = true; // 启用自动滚动

            // 添加列
            for (int i = 0; i < tableLayoutPanel.ColumnCount; i++)
            {
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / Clmcount));
            }
            for (int i = 0; i < tableLayoutPanel.RowCount; i++)
            {
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / Rowcount));
            }

            //foreach (var item in DataAnalyze.GetInstance().itemReadItemsParamSet)
            //{
            //    CalParamUtil calParamUtil = new CalParamUtil();
            //    calParamUtil.ParamU = item;
            //    calParamUtil.Title = item.Name;
            //    calParamUtil.Util = item.Unit;
            //    calParamUtil.Dock = DockStyle.Fill;
            //    tableLayoutPanel.Controls.Add(calParamUtil);
            //}




            // 设置当前行的大小为百分比
            //tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / tableLayoutPanel.RowCount));
            // 将TableLayoutPanel添加到父容器中
            //panel1.Controls.Add(tableLayoutPanel);
        }
    }
}
