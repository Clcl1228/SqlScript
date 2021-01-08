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
            string  rSql = "";
            tName = tName.ToUpper();
            foreach (DataGridViewRow item in dataGridView.Rows)
            {
                string isDel = item.Cells["勾选删除"].Value==null?"":item.Cells["勾选删除"].Value.ToString();
                string table = item.Cells["表名"].Value == null ? tName : item.Cells["表名"].Value.ToString() == "" ? tName : item.Cells["表名"].Value.ToString().ToUpper();
                string name = item.Cells["字段名"].Value == null ? "" : item.Cells["字段名"].Value.ToString();

                if (isDel=="True" && name != "")
                {
                    if (SqlConnectionM.Status == "1" && SqlConnectionM.ServerType == "SqlServer")
                    {
                        bool flag = DbHelperSQL.TabExists(table);
                        if (!flag) { throw new Exception("表" + table + "不存在"); }
                    }
                    rSql += @"IF EXISTS( SELECT 1 FROM SYSOBJECTS T1 WHERE T1.NAME = '{0}' )" + "\r\n" + "IF EXISTS (select name from syscolumns where id=object_id(N'{0}') AND NAME='{1}')" + "\r\n" + @" BEGIN" + "\r\n" + @"  alter table {0} drop column {1}" + "\r\n" + @" END" + "\r\n" + "\r\n";
                    rSql = string.Format(rSql, table, name);
                }
            }

            return rSql == "" ? rSql : ("--SqlServer删除字段" + "\r\n" + rSql);
        }

       
    }
}
