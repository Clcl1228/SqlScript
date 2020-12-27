using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlScript_MODEL
{
    public class FieldTypes
    {
        public enum SqlFieldType 
        {
            varchar,
            nvarchar,
            numeric,
            datetime
        }


        public enum OracleFieldType 
        {
            varchar2,
            nvarchar2,
            date,
            number
        }

        public enum AllType
        {
            varchar,
            nvarchar,
            numeric,
            datetime,
            varchar2,
            nvarchar2,
            date,
            number
        }
    }
}
