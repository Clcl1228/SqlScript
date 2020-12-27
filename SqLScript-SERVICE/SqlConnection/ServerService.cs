using SqlScript_MODEL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OracleClient;
using System.Data.SqlClient;

namespace ScriptService
{
    public class ServerService 
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
