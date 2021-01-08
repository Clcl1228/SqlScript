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
                bool isNum = int.TryParse(item.Cells["txtDefault"].Value == null ? "" : item.Cells["txtDefault"].Value.ToString(), out int defN);
                name = item.Cells["txtName"].Value == null ? "" : item.Cells["txtName"].Value.ToString().ToUpper();
                type = item.Cells["txtFieldType"].Value == null ? "" : GetFieldType(item.Cells["txtFieldType"].Value.ToString());
                msg = item.Cells["txtMsg"].Value == null ? "" : item.Cells["txtMsg"].Value.ToString();
                table = item.Cells["txtTable"].Value == null ? tName : item.Cells["txtTable"].Value.ToString() == "" ? tName : item.Cells["txtTable"].Value.ToString().ToUpper();
                isNull = item.Cells["txtIsNull"].Value == null ? " NULL" : " NOT NULL";

                def = item.Cells["txtIsNull"].Value == null ? "" : "DEFAULT " + (isNum == true ? item.Cells["txtDefault"].Value.ToString() : "'" + item.Cells["txtDefault"].Value.ToString() + "'");


                if (SqlConnectionM.Status == "1" && SqlConnectionM.ServerType == "SqlServer")
                {
                    bool flag = DbHelperSQL.TabExists(table);
                    if (!flag) { throw new Exception("表" + table + "不存在"); }
                }
                if (table != "" && name != "" && type != "")
                {
                    rSql += @"IF EXISTS( SELECT 1 FROM SYSOBJECTS T1 WHERE T1.NAME = '{0}' )" + "\r\n" +"IF NOT EXISTS (select name from syscolumns where id=object_id(N'{0}') AND NAME='{1}')" + "\r\n" + @" BEGIN" + "\r\n" + @"  ALTER TABLE {0} ADD {1} {2} {3} {4} {6}" + "\r\n" + @" END" + "\r\n" + "\r\n";
                    if (msg == "")
                    {
                        bz = "";
                    }
                    else
                    {
                        bz = "\r\n" + "  execute sp_addextendedproperty N'MS_Description', '{2}', N'SCHEMA', N'dbo', N'table', N'{0}', N'COLUMN', N'{1}'";
                        bz = String.Format(bz, table, name, msg);
                    }
                    rSql = string.Format(rSql, table, name, type, isNull, def, msg, bz);
                    rSql += "\r\n";
                }
            }
            if (rSql != "")
            {
                rSql = "--SqlServer新增字段" + "\r\n" + rSql;
            }
            return rSql ;
        }
        public string GetFieldType(string type)
        {
            return fType.OracleToSql(type.ToUpper());
        }
    }
}
