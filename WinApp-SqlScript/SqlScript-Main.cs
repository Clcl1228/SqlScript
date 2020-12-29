using SqlScript_MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinApp_SqlScript
{
    public partial class SqlScriptMain : Form
    {
        SqlScript_Login _login;
        SqlScript_Add Add;
        SqlScript_Del del;
        SqlScript_Update update;
        public SqlScriptMain(SqlScript_Login login)
        {
            InitializeComponent();
            this._login = login;
        }

        private void SqlScriptMain_Load(object sender, EventArgs e)
        {

        }

        private void 新增字段ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Add == null)
            {
                this.IsMdiContainer = true;
                Add = new SqlScript_Add();
                Add.MdiParent = this;
                Add.Show();
                Add.Dock = DockStyle.Fill;
            }
            else
            {
                Add.BringToFront();
            }
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;

            if (m.Msg == WM_SYSCOMMAND && ((int)m.WParam == SC_CLOSE))
            {
                this._login.Show();
            }
            base.WndProc(ref m);
        }

        private void 删除字段ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SqlConnectionM.Status != "1")
            {
                throw new Exception("数据库未连接");
            }
            else
            {
                if (del == null)
                {
                    this.IsMdiContainer = true;
                    del = new SqlScript_Del();
                    del.MdiParent = this;
                    del.Show();
                    del.Dock = DockStyle.Fill;
                }
                else
                {
                    del.BringToFront();
                }
            }
        }

        private void 更新字段ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SqlConnectionM.Status != "1")
            {
                throw new Exception("数据库未连接");
            }
            else
            {
                if (del == null)
                {
                    this.IsMdiContainer = true;
                    update = new SqlScript_Update();
                    update.MdiParent = this;
                    update.Show();
                    update.Dock = DockStyle.Fill;
                }
                else
                {
                    update.BringToFront();
                }
            }
        }
    }
}
