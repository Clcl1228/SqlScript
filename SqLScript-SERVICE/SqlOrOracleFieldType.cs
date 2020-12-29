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
            string tp = fieldType.ToString().Split('(')[0].ToLower();
            if (!Enum.IsDefined(typeof(FieldTypes.AllType), tp))
            {
                throw new Exception("数据类型有误:" + fieldType);
            }
            else if (Enum.IsDefined(typeof(FieldTypes.OracleType), tp))
            {
                FieldTypes.OracleType state = (FieldTypes.OracleType)Enum.Parse(typeof(FieldTypes.OracleType), tp);
                int ft = (int)(FieldTypes.OracleType)state;
                sqlName = Enum.GetName(typeof(FieldTypes.SqlType), ft);
                sqlName= fieldType.ToString().ToLower().Replace(tp, sqlName);
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
            string tp = fieldType.ToString().Split('(')[0].ToLower();

            if (!Enum.IsDefined(typeof(FieldTypes.AllType), tp))
            {
                throw new Exception("数据类型有误:" + fieldType);
            }
            else if (Enum.IsDefined(typeof(FieldTypes.SqlType), tp))
            {
                FieldTypes.SqlType state = (FieldTypes.SqlType)Enum.Parse(typeof(FieldTypes.SqlType), tp);
                int ft = (int)(FieldTypes.SqlType)state;
                sqlName = Enum.GetName(typeof(FieldTypes.OracleType), ft);
                sqlName = fieldType.ToString().ToLower().Replace(tp, sqlName);
    
            }
            else
            {
                sqlName = fieldType.ToString();
            }
            return sqlName;
        }
    }
}
