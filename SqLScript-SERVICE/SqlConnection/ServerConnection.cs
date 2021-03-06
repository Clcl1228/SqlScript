﻿using SqlScript_MODEL;
using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptService
{
    public class ServerConnection
    {
        /// <summary>
        /// 错误信息
        /// </summary>
        private string errMsg = string.Empty;

        public string ErrMsg
        {
            get { return errMsg; }
            set { errMsg = value; }
        }
        /// <summary>
        /// 连接字符串
        /// </summary>
        private string connString = string.Empty;
        public ServerConnection()
        {
            
        }

        [Obsolete]
        public bool openConnection()
        {
            this.connString = SqlConnectionM.ServerType == "SqlServer" ? SqlConnectionM.SqlConnString : SqlConnectionM.OracleConnString;

            bool result = false;
            try
            {
                result=TestServerLoad(SqlConnectionM.ServerType);
            }
            catch (Exception exception)
            {
                this.ErrMsg = exception.Message;
                result = false;
            }
            return result;
        }

        [Obsolete]
        public bool TestServerLoad(string type)
        {
            bool result = false;
            if (type == "SqlServer")
                {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        result = true;
                    }
                }
            }
            else
            {
                using (OracleConnection conn = new OracleConnection(connString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

    }
}
