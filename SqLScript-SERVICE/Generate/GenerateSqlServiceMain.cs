using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScriptService
{
    public abstract class GenerateSqlServiceMain
    {
       public abstract string GenerateSql(DataGridView dataGridView,string table);
    }
}
