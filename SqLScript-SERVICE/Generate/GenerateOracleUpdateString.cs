using DBHelperOracle;
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
    public class GenerateOracleUpdateString : GenerateSqlServiceMain
    {
        SqlOrOracleFieldType fType = new SqlOrOracleFieldType();
        public override string GenerateSql(DataGridView dataGridView,string tName)
        {
            string rMsg = "", rSql = "";
            tName = tName.ToUpper();
            foreach (DataGridViewRow item in dataGridView.Rows)
            {
                string isDel = item.Cells[0].Value == null ? "" : item.Cells[0].Value.ToString();
                string name = item.Cells[1].Value == null ? "" : item.Cells[1].Value.ToString();
                string msg = item.Cells[3].Value == null ? "" : item.Cells[3].Value.ToString();
                string table = item.Cells[4].Value == null ? tName:item.Cells[4].Value.ToString()==""?tName: item.Cells[4].Value.ToString().ToUpper();

                if (SqlConnectionM.Status == "1" && SqlConnectionM.ServerType == "Oracle")
                {
                    bool flag = OracleHepler.ExistsTable(table);
                    if (!flag) { throw new Exception("表" + table + "不存在"); }
                }
                if (isDel == "True")
                {
                    
                    if (item.Cells[2].Value.ToString() != "")
                    {
                        string type = item.Cells[2].Value == null ? "" : GetFieldType(item.Cells[2].Value.ToString());
                        rSql += @"alter table {0} modify ({1} {2});" + "\r\n" + "";
                        rSql = string.Format(rSql, table, name, type);
                    }
                    
                    if (msg != "")
                    {
                        rMsg += "\r\n" + "comment on column {0}.{1} is '{2}'";
                        rMsg = String.Format(rMsg, table, name, msg);
                    }
                }
            }

            return rSql+"\n\r"+rMsg;
        }
        public string GetFieldType(string type)
        {
            return fType.SqlToOracle(type.ToUpper());
        }
    }
}
