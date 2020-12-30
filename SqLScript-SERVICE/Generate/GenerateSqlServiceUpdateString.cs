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
    public class GenerateSqlServiceUpdateString : GenerateSqlServiceMain
    {
        SqlOrOracleFieldType fType = new SqlOrOracleFieldType();
        public override string GenerateSql(DataGridView dataGridView,string tName)
        {
            string rMsg = "", rSql = "";
            foreach (DataGridViewRow item in dataGridView.Rows)
            {
                string isDel = item.Cells[0].Value == null ? "" : item.Cells[0].Value.ToString();
                string name = item.Cells[1].Value == null ? "" : item.Cells[1].Value.ToString();
                string length = item.Cells[3].Value == null ? "" : item.Cells[3].Value.ToString();
                string nuermic = item.Cells[4].Value == null ? "" : item.Cells[4].Value.ToString();
                string msg = item.Cells[5].Value == null ? "" : item.Cells[5].Value.ToString();
                string table = item.Cells[6].Value == null ? tName : item.Cells[6].Value.ToString();

                if (SqlConnectionM.Status == "1" && SqlConnectionM.ServerType == "SqlServer")
                {
                    bool flag = DbHelperSQL.TabExists(table);
                    if (!flag) { throw new Exception("表" + table + "不存在"); }
                }
                if (isDel == "True")
                {
                    string type = item.Cells[2].Value == null ? "" : GetFieldType(item.Cells[2].Value.ToString());

                    rSql += @"alter table {0} alter column {1} {2}({3})" + "\r\n" + "";
                    if (nuermic != "" && nuermic != "0")
                    {
                        length = length + "," + nuermic;
                    }
                    rSql = string.Format(rSql, table, name,type,length);
                    if (msg != "")
                    {
                        rMsg += "EXECUTE sp_updateextendedproperty 'MS_Description', '{2}', 'SCHEMA', 'dbo', 'table', '{0}', 'column', '{1}'"+"\n\r";
                        rMsg = String.Format(rMsg, table, name, msg);
                    }
                }
            }

            return rSql+"\n\r"+rMsg;
        }
        public string GetFieldType(string type)
        {
            return fType.OracleToSql(type.ToUpper());
        }
    }
}
