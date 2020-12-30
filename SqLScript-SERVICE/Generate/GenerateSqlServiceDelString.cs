using DBUtility;
using SqlScript_MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScriptService
{
    public class GenerateSqlServiceDelString : GenerateSqlServiceMain
    {
        public override string GenerateSql(DataGridView dataGridView,string tName)
        {
            string rMsg = "", rSql = "";
            foreach (DataGridViewRow item in dataGridView.Rows)
            {
                string isDel = item.Cells[0].Value==null?"":item.Cells[0].Value.ToString();
                string table = item.Cells[1].Value == null ? tName : item.Cells[1].Value.ToString() == "" ? tName : item.Cells[1].Value.ToString();
                string name = item.Cells[2].Value == null ? "" : item.Cells[2].Value.ToString();

                if (isDel=="True" && name != "")
                {
                    if (SqlConnectionM.Status == "1" && SqlConnectionM.ServerType == "SqlServer")
                    {
                        bool flag = DbHelperSQL.TabExists(table);
                        if (!flag) { throw new Exception("表" + table + "不存在"); }
                    }
                    rSql += @"alter table {0} drop column {1}" + "\r\n" + "";
                    rSql = string.Format(rSql, table, name);
                }
            }

            return rSql;
        }
    }
}
