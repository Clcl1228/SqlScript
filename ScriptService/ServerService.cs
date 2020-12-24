using SQLScript_IScriptService;
using SqlScript_MODEL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OracleClient;
using System.Data.SqlClient;
using SqlScript_BLL;

namespace ScriptService
{
    public class ServerService : ISqlConnection
    {
        ServerConnection serverConnection = new ServerConnection();
        public ServerService()
        {
            
        }

        [Obsolete]
        public bool IsConnection()
        {
            return serverConnection.openConnection();
        }
        
    }
}
