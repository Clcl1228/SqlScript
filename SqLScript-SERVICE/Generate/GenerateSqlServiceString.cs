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
    public class GenerateSqlServiceString : GenerateSqlServiceMain
    {
        SqlOrOracleFieldType fType = new SqlOrOracleFieldType();
        public override string GenerateSql(DataGridView dataGridView, string tName)
        {
            string rMsg = "", rSql = "", name = "", type = "", msg = "", table = "", isNull = "", def = "", bz = "";
            tName = tName.ToUpper();
            foreach (DataGridViewRow item in dataGridView.Rows)
            {
                bool isNum = int.TryParse(item.Cells[5].Value==null?"":item.Cells[5].Value.ToString(), out int defN);
                name = item.Cells[0].Value == null ? "" : item.Cells[0].Value.ToString().ToUpper();
                type = item.Cells[1].Value == null ? "" : GetFieldType(item.Cells[1].Value.ToString());
                msg = item.Cells[2].Value == null ? "" : item.Cells[2].Value.ToString();
                table = item.Cells[3].Value == null ? tName : item.Cells[3].Value.ToString() == "" ? tName : item.Cells[3].Value.ToString().ToUpper();
                isNull = item.Cells[4].Value == null ? " NULL" : " NOT NULL";
                def = item.Cells[5].Value == null ? "" : "DEFAULT " + (isNum == true ? item.Cells[5].Value.ToString() : "'" + item.Cells[5].Value.ToString() + "'");


                if (SqlConnectionM.Status == "1" && SqlConnectionM.ServerType == "SqlServer")
                {
                    bool flag = DbHelperSQL.TabExists(table);
                    if (!flag) { throw new Exception("表" + table + "不存在"); }
                }
                if (table != "" && name != "" && type != "")
                {
                    rSql += "\r\n" + @"IF NOT EXISTS (select name from syscolumns where id=object_id(N'{0}') AND NAME='{1}')" + "\r\n" + @" BEGIN" + "\r\n" + @"  ALTER TABLE {0} ADD {1} {2} {3} {4} {6}" + "\r\n" + @" END";
                    if (msg == "")
                    {
                        bz = "";
                    }
                    else
                    {
                        bz = "\r\n" + "execute sp_addextendedproperty N'MS_Description', '{2}', N'SCHEMA', N'dbo', N'table', N'{0}', N'COLUMN', N'{1}'";
                        bz = String.Format(bz, table, name, msg);
                    }
                    rSql = string.Format(rSql, table, name, type, isNull, def, msg, bz);
                }
            }

            return rSql + "\r\n";
        }
        public string GetFieldType(string type)
        {
            return fType.OracleToSql(type.ToUpper());
        }
    }
}
