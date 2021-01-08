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
                    rSql += @"declare  cnt number; tableExistedCount number;
begin
    SELECT count(1) into tableExistedCount from ALL_TABLES  where TABLE_NAME = UPPER('{0}') ;
    if tableExistedCount > 0 THEN
       SELECT count(*) into cnt from cols WHERE TABLE_NAME=UPPER('{0}') AND column_name=UPPER('{1}');
    if cnt=0 THEN
       execute immediate 'ALTER TABLE {0} ADD {1} {2} {4} {3}';
       {5}
    end if;
    end if;
end;" + "\r\n" + "\r\n";
                    if (msg != "")
                    {
                        rMsg = @"execute immediate 'comment  on  column  {0}.{1} is ''{2}'' ';";
                        rMsg = string.Format(rMsg, table, Name, msg);
                    }
                    rSql = string.Format(rSql, table, Name, type, isNull, def, rMsg);
                }
            }
            if (rSql != "")
            {
                rSql = "--Oracle新增字段" + "\r\n" + rSql;
            }
            return rSql;
        }
        public string GetFieldType(string type)
        {
            return fType.SqlToOracle(type.ToUpper());
        }
    }
}
