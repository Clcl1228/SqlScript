using System;

namespace SqlScript_MODEL
{
    public class SqlConnectionM
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public static string LoginName = string.Empty;
        /// <summary>
        /// 密码
        /// </summary>
        public static string PassWord = string.Empty;
        /// <summary>
        /// 数据源
        /// </summary>
        public static string dataScore = string.Empty;
        /// <summary>
        /// 数据库
        /// </summary>
        public static string cataLog = string.Empty;
        /// <summary>
        /// 连接字符串M（SqlServer）
        /// </summary>
        public static string SqlConnStringM = "User ID={0};Password={1};Initial Catalog={3};Data Source={2};";
        /// <summary>
        /// 连接字符串（SqlServer）
        /// </summary>
        public static string SqlConnString = "User ID={0};Password={1};Initial Catalog={3};Data Source={2};";
        /// <summary>
        /// 连接字符串M（Oracle）
        /// </summary>
        public static string OracleConnStringM = @"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={2}) (PORT=1521)))(CONNECT_DATA=(SERVICE_NAME={3})));Persist Security Info=True;User Id={0}; Password={1}";

        /// <summary>
        /// 连接字符串（Oracle）
        /// </summary>
        public static string OracleConnString = @"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={2}) (PORT=1521)))(CONNECT_DATA=(SERVICE_NAME={3})));Persist Security Info=True;User Id={0}; Password={1}";
        /// <summary>
        /// 数据库类型
        /// </summary>
        public static string ServerType = string.Empty;
        /// <summary>
        /// 表名
        /// </summary>
        public static string TableName = string.Empty;
        /// <summary>
        /// 连接状态
        /// </summary>
        public static string Status = string.Empty;
    }
}
