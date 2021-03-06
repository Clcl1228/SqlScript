﻿using DBHelperOracle;
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
           string sql = @"select t.table_name as name from user_tables t order by t.table_name asc";
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

        public DataTable GetSqlServerUpdateFieldToTable(string tableName)
        {
            string sql = @" SELECT
       C.name as [字段名],'' [修改后字段名],'' as [字段类型]
      ,'' AS [字段描述]
      ,'{0}' AS [表名]
 FROM syscolumns C
 INNER JOIN systypes T ON C.xusertype = T.xusertype 
 left JOIN sys.extended_properties ETP   ON  ETP.major_id = c.id AND ETP.minor_id = C.colid AND ETP.name ='MS_Description' 
 left join syscomments CM on C.cdefault=CM.id
 WHERE C.id = object_id('{0}')";
            sql = String.Format(sql, tableName);
            SqlDataReader sqlData = DBUtility.DbHelperSQL.ExecuteReader(sql);
            return DBUtility.DbHelperSQL.GetDataTableToDataReader(sqlData);
        }
        public DataTable GetOracleUpdateFieldToTable(string tableName)
        {
            string sql = @"select t.COLUMN_NAME AS 字段名 ,'' [修改后字段名],'' AS 字段类型 ,'' AS 字段描述,{0} as 表名
 from user_tab_columns t,user_col_comments c
 where t.table_name = c.table_name and t.column_name = c.column_name and t.table_name ='{0}'";
            sql = String.Format(sql, tableName);
            return OracleHepler.ExecuteDataTable(sql);
        }
    }
}
