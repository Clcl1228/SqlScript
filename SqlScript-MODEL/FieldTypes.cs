using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlScript_MODEL
{
    public class FieldTypes
    {
        public enum OracleType
        {
            VARCHAR2 = 1,
            NVARCHAR2= 7,
            NUMBER =3,
            DATE=5,
            INTEGER=6
        }
        public enum SqlType
        {
            VARCHAR = 1,
            NVARCHAR = 7,
            NUMERIC = 3,
            DATETIME = 5,
            INT =6
        }
        public enum AllType
        {
            VARCHAR = 1,
            VARCHAR2= 2,

            NUMERIC = 3,
            NUMBER = 4,

            DATETIME =5,
            DATE=6,

            NVARCHAR = 7,
            NVARCHAR2= 8,

            INT =9,
            INTEGER=10
        }
    }
}
