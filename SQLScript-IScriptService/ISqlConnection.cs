using System;
using System.Collections.Generic;
using System.Text;

namespace SQLScript_IScriptService
{
    public interface ISqlConnection
    {
        /// <summary>
        /// 是否连接成功
        /// </summary>
        /// <returns></returns>
         bool IsConnection();
    }
}
