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
    internal class FileTeat
    {
        public string FileSelect()
        {
            string FilePath = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {

                openFileDialog.Filter = "Binary Files (*.bin)|*.bin";
                openFileDialog.Title = "选择 bin 文件";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FilePath = openFileDialog.FileName;
                }
                return FilePath;
            }
        }
        public string  SaveAs()
        {
            // 调用另存对话框选择保存路径
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV 文件 (*.csv)|*.csv";
                saveFileDialog.FileName = "HistoryData.csv";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return saveFileDialog.FileName;

                }
                else
                {
                    return null;
                }
            }
        }
    }
}
