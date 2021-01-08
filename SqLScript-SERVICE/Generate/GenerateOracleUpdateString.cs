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
            string rMsg = "", rSql = "", rUp="";
            tName = tName.ToUpper();
            foreach (DataGridViewRow item in dataGridView.Rows)
            {
                string isDel = item.Cells["cboDel"].Value == null ? "" : item.Cells["cboDel"].Value.ToString();
                string name = item.Cells["字段名"].Value == null ? "" : item.Cells[1].Value.ToString();
                string msg = item.Cells["字段描述"].Value == null ? "" : item.Cells["字段描述"].Value.ToString();
                string table = item.Cells["表名"].Value == null ? tName:item.Cells["表名"].Value.ToString()==""?tName: item.Cells["表名"].Value.ToString().ToUpper();
                string updateName = item.Cells["修改后字段名"].Value == null ? "" : item.Cells["修改后字段名"].Value.ToString();


                if (SqlConnectionM.Status == "1" && SqlConnectionM.ServerType == "Oracle")
                {
                    bool flag = OracleHepler.ExistsTable(table);
                    if (!flag) { throw new Exception("表" + table + "不存在"); }
                }
                if (isDel == "True")
                {
                    
                    if (item.Cells["字段类型"].Value.ToString() != "")
                    {
                        string type = item.Cells["字段类型"].Value == null ? "" : GetFieldType(item.Cells["字段类型"].Value.ToString());
                        string rS = "alter table {0} modify ({1} {2})";
                        rSql += GetSql(rS);
                        rSql = String.Format(rSql, table, name, type);
                    }
                    
                    if (msg != "")
                    {
                        string rM = "comment on column {0}.{1} is ''{2}''";
                        rMsg += GetSql(rM)  ;
                        rMsg = String.Format(rMsg, table, name, msg);
                    }
                    if (updateName != "")
                    {
                        string rU = "alter table {0} rename column {1} to {2}";
                        rUp += GetSql(rU);
                        rUp += ""+ "\r\n";
                    }
                    rUp = String.Format(rUp, table, name, updateName);
                }
            }
            if (rSql != "")
            {
                rSql = "--Oracle修改字段类型" + "\r\n" + rSql;
            }
            if (rMsg != "")
            {
                rMsg = "--Oracle修改注释" + "\r\n" + rMsg;
            }
            if (rUp != "")
            {
                rUp = "--Oracle修改字段名" + "\r\n" + rUp;
            }
            return rSql  + "\n\r" + rMsg + "\n\r" + rUp ;
        }
        public string GetFieldType(string type)
        {
            return fType.SqlToOracle(type.ToUpper());
        }

        public string GetSql(string sql)
        {
            string reSql= @"declare  cnt number; tableExistedCount number;
begin
    SELECT count(1) into tableExistedCount from ALL_TABLES  where TABLE_NAME = UPPER('{0}') ;
    if tableExistedCount > 0 THEN
       SELECT count(*) into cnt from cols WHERE TABLE_NAME=UPPER('{0}') AND column_name=UPPER('{1}');
    if cnt>0 THEN
       execute immediate '@SQL';
    end if;
    end if;
end;" + "\r\n" + "\r\n";
            reSql = reSql.Replace("@SQL", sql);
            return reSql;
        }
    }
}
