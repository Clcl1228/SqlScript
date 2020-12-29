using SqlScript_MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptService
{
    public class SqlOrOracleFieldType
    {
        public string OracleToSql(object fieldType)
        {
            string sqlName = "";
            if (!Enum.IsDefined(typeof(FieldTypes.AllType), fieldType.ToString().Split('(')[0].ToLower()))
            {
                throw new Exception("数据类型有误:" + fieldType);
            }
            else if (Enum.IsDefined(typeof(FieldTypes.OracleType), fieldType.ToString().Split('(')[0].ToLower()))
            {
                int ft = (int)(FieldTypes.OracleType)fieldType;
                sqlName = Enum.GetName(typeof(FieldTypes.SqlType), ft);
            }
            else
            {
                sqlName = fieldType.ToString();
            }
            return sqlName;
        }
        public string SqlToOracle(object fieldType)
        {
            string sqlName = "";
            if (!Enum.IsDefined(typeof(FieldTypes.AllType), fieldType.ToString().Split('(')[0].ToLower()))
            {
                throw new Exception("数据类型有误:" + fieldType);
            }
            else if (Enum.IsDefined(typeof(FieldTypes.SqlType), fieldType.ToString().Split('(')[0].ToLower()))
            {
                int ft = (int)(FieldTypes.SqlType)(object)fieldType.ToString().Split('(')[0].ToLower());
                sqlName = Enum.GetName(typeof(FieldTypes.OracleType), ft);
            }
            else
            {
                sqlName = fieldType.ToString();
            }
            return sqlName;
        }
    }
}
