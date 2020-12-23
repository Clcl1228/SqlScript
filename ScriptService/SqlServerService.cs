using System;
using System.Collections.Generic;
using System.Text;
using SQLScript_IScriptService;
namespace ScriptService
{
    public class SqlServerService : ISqlConnection
    {
        public bool IsConnection()
        {
            return false;
        }
    }
}
