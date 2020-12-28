using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScriptService.File
{
    public  static class SaveFile
    {
        public static void SaveFilesToText(string txt)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "请选择要保存的文件路径";
            sfd.InitialDirectory = Application.StartupPath;
            sfd.Filter = "文本文件|*.txt|Sql文件|*.sql|所有文件|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string filePath = sfd.FileName;
                using (FileStream fsWrite = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    byte[] buffer = Encoding.Default.GetBytes(txt);
                    fsWrite.Write(buffer, 0, buffer.Length);

                    MessageBox.Show("保存成功");
                }
            }
        }
    }
}
