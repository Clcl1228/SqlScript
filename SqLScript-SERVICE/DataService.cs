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
           string sql = @"select t.table_name from user_tables t;";
            OracleDataReader dataReader = DBHelperOracle.OracleHepler.ExecuteDataReader(sql, false, new OracleParameter[] { new OracleParameter() });
            return dataReader;
        }
    }
}
