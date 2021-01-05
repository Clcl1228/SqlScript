using DBHelperOracle;
using SqlScript_MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScriptService
{
    public class GenerateOracleString : GenerateSqlServiceMain
    {
        SqlOrOracleFieldType fType = new SqlOrOracleFieldType();
        public override string GenerateSql(DataGridView dataGridView,string tName)
        {
            string rMsg = "", rSql = ""; 
            tName = tName.ToUpper();
            foreach (DataGridViewRow item in dataGridView.Rows)
            {
                string Name = item.Cells["txtName"].Value == null ? "" : item.Cells["txtName"].Value.ToString().ToUpper();
                string type = item.Cells["txtFieldType"].Value == null ? "" : GetFieldType(item.Cells["txtFieldType"].Value.ToString());
                string msg = item.Cells["txtMsg"].Value == null ? "" : item.Cells["txtMsg"].Value.ToString();
                string table = item.Cells["txtTable"].Value == null ? tName : item.Cells["txtTable"].Value.ToString()==""?tName: item.Cells["txtTable"].Value.ToString().ToUpper();
                string isNull = item.Cells["txtIsNull"].Value == null ? " NULL" : " NOT NULL";

                bool isNum = int.TryParse(item.Cells["txtDefault"].Value == null ? "" : item.Cells["txtDefault"].Value.ToString(), out int defN);
                string def = item.Cells["txtIsNull"].Value == null ? "" : "DEFAULT " + (isNum == true ? item.Cells["txtDefault"].Value.ToString() : "''" + item.Cells["txtDefault"].Value.ToString() + "''");


                if (SqlConnectionM.Status == "1" && SqlConnectionM.ServerType=="Oracle")
                {
                    bool flag = OracleHepler.ExistsTable(table);
                    if (!flag) { throw new Exception("表" + table + "不存在"); }
                }
                if (table != "" && Name != "" && type != "")
                {
                    rSql += @"declare  cnt number;
begin
   SELECT COUNT(*) into cnt FROM cols WHERE table_name=UPPER('{0}') AND column_name=UPPER('{1}');
   if cnt=0 then
    execute immediate 'ALTER TABLE {0} ADD {1} {2} {4} {3}';
  end if;
  cnt:=0;
end;"+"\r\n";
                    rSql = string.Format(rSql, table, Name, type, isNull, def);
                    if (msg != "")
                    {
                        rMsg += @"comment  on  column  {0}.{1} is '{2}';"+ "\r\n"+"";
                        rMsg = string.Format(rMsg, table, Name, msg);
                    }
                }
            }
            if (rSql != "")
            {
                rSql = "--Oracle新增字段" + "\r\n" + rSql;
            }
            if (rMsg != "")
            {
                rMsg = "--Oracle新增注释" + "\r\n" + rMsg;
            }
            return rSql+ "\r\n"+rMsg;
        }
        public string GetFieldType(string type)
        {
            return fType.SqlToOracle(type.ToUpper());
        }
    }
}
