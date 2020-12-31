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
            tName = tName.ToUpper();
            foreach (DataGridViewRow item in dataGridView.Rows)
            {
                string isDel = item.Cells[0].Value == null ? "" : item.Cells[0].Value.ToString();
                string name = item.Cells[1].Value == null ? "" : item.Cells[1].Value.ToString();
                string msg = item.Cells[3].Value == null ? "" : item.Cells[3].Value.ToString();
                string table = item.Cells[4].Value == null ? tName : item.Cells[4].Value.ToString()==""?tName: item.Cells[4].Value.ToString().ToUpper();

                if (SqlConnectionM.Status == "1" && SqlConnectionM.ServerType == "SqlServer")
                {
                    bool flag = DbHelperSQL.TabExists(table);
                    if (!flag) { throw new Exception("表" + table + "不存在"); }
                }
                if (isDel == "True")
                {
                    
                    if (item.Cells[2].Value.ToString() != "")
                    {
                        string type = item.Cells[2].Value == null ? "" : GetFieldType(item.Cells[2].Value.ToString());
                        rSql += @"alter table {0} alter column {1} {2}" + "\r\n" + "";
                        rSql = string.Format(rSql, table, name, type);
                    }
                    
                    if (msg != "")
                    {
                        string sql = @"SELECT top 1  isnull(name,'')
FROM ::fn_listextendedproperty (NULL, 'user', 'dbo', 'table', '{0}', 'column',
default)
where objname = '{1}'
";
                        sql = String.Format(sql, table, name);
                        object value = DbHelperSQL.GetSingle(sql);
                        if(value!=null && value.ToString()== "MS_Description")
                        {
                            rMsg += "\r\n" + "EXECUTE sp_updateextendedproperty 'MS_Description', '{2}', 'SCHEMA', 'dbo', 'table', '{0}', 'column', '{1}'";
                        }
                        else
                        {
                            rMsg += "\r\n" + "EXECUTE sp_addextendedproperty 'MS_Description', '{2}', 'SCHEMA', 'dbo', 'table', '{0}', 'column', '{1}'";
                        }
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
