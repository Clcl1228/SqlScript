using DBHelperOracle;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptService
{
    public class DataService
    {
        public DataTable GetSqlServerDelFieldToTable(string tableName)
        {
            string sql = @"SELECT 
A.name AS table_name, 
B.name AS column_name, 
C.value AS column_description 
FROM sys.tables A 
INNER JOIN sys.columns B ON B.object_id = A.object_id 
LEFT JOIN sys.extended_properties C ON C.major_id = B.object_id AND C.minor_id = B.column_id 
WHERE A.name = '"+ tableName .ToString().Trim()+ "'";
            SqlDataReader sqlData = DBUtility.DbHelperSQL.ExecuteReader(sql);
            return DBUtility.DbHelperSQL.GetDataTableToDataReader(sqlData);
        }

        public OracleDataReader GetOracleAllTable()
        {
           string sql = @"select t.table_name as name from user_tables t ";
            OracleDataReader dataReader = DBHelperOracle.OracleHepler.ExecuteDataReader(sql, false);
            return dataReader;
        }

        public DataTable GetOracleDelFieldToTable(string tableName)
        {
            string sql = @"select  
       uc.table_name AS table_name, 
      ut.column_name, 
      uc.comments as column_description
from user_tab_columns  ut 
inner JOIN user_col_comments uc 
on ut.TABLE_NAME  = uc.table_name and ut.COLUMN_NAME = uc.column_name 
where ut.Table_Name='{0}' 
order by ut.column_name ";
            sql = String.Format(sql, tableName);
            DataTable sqlData = OracleHepler.ExecuteDataTable(sql);
            return sqlData;
        }
    }
}
