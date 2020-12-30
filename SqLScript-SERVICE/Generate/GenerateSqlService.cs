using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScriptService
{
    public class GenerateSqlService 
    {
        private GenerateSqlServiceMain _main;

        public GenerateSqlService(GenerateSqlServiceMain main)
        {
            _main = main;
        }
        public string CreateSqlString(DataGridView dataGridView,string table)
        {
            return _main.GenerateSql(dataGridView, table);
        }
    }
}
