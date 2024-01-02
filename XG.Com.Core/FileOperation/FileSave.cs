using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XG.Com.Core.FileOperation
{
    public  class FileSave
    {
        public void SaveDataTableToCsv(DataTable dataTable)
        {
            // 调用另存对话框选择保存路径
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV 文件 (*.csv)|*.csv";
                saveFileDialog.FileName = "HistoryData.csv";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string csvFilePath = saveFileDialog.FileName;
                    // 创建一个写入器并打开文件
                    using (StreamWriter writer = new StreamWriter(csvFilePath))
                    {
                        // 写入表头
                        foreach (DataColumn column in dataTable.Columns)
                        {
                            writer.Write(QuoteCsvValue(column.ColumnName)); // 处理特殊字符
                            writer.Write(",");
                        }
                        writer.WriteLine();

                        // 写入数据行
                        foreach (DataRow row in dataTable.Rows)
                        {
                            foreach (var item in row.ItemArray)
                            {
                                writer.Write(QuoteCsvValue(item.ToString())); // 处理特殊字符
                                writer.Write(",");
                            }
                            writer.WriteLine();
                        }
                    }

                }
            }
        }
        private string QuoteCsvValue(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            // 处理特殊字符和换行符
            value = value.Replace("\"", "\"\""); // 转义双引号
            if (value.Contains(",") || value.Contains("\n"))
            {
                value = "\"" + value + "\""; // 用双引号括起来
            }

            return value;
        }
    }
}
