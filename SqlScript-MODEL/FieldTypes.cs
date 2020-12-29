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
            varchar2 = 1,
            nvarchar2= 7,
            number =3,
            date=5
        }
        public enum SqlType
        {
            varchar = 1,
            nvarchar = 7,
            numeric = 3,
            datetime = 5
        }
        public enum AllType
        {
            varchar=1,
            varchar2=2,

            numeric=3,
            number = 4,

            datetime =5,
            date=6,

            nvarchar=7,
            nvarchar2=8,
            
        }
    }
}
