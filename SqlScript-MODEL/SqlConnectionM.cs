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
        /// 连接字符串（SqlServer）
        /// </summary>
        public static string SqlConnString = "User ID={0};Password={1};Initial Catalog=PT2_JGEQ_QW;Data Source={2};";
        /// <summary>
        /// 连接字符串（Oracle）
        /// </summary>
        public static string OracleConnString = "data source={2};password={1};persist security info=True;user id={0}";
        /// <summary>
        /// 数据库类型
        /// </summary>
        public static string ServerType = string.Empty;
    }
}
