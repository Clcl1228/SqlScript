using ScriptService;
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
    public partial class SqlScript_Login : Form
    {
        ServerService  connection = new ServerService();
        public SqlScript_Login()
        {
            InitCombox();
            InitializeComponent();
        }

        private void InitCombox()
        {
            this.comBoxServer.Items.Add("SqlServer");
            this.comBoxServer.Items.Add("Oracle");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            SqlConnectionM.LoginName = this.txtUserName.Text.Trim().ToString();
            SqlConnectionM.PassWord  = this.txtPassWord.Text.Trim().ToString();
            SqlConnectionM.dataScore = this.txtDataScore.Text.Trim().ToString();
            SqlConnectionM.ServerType = this.comBoxServer.SelectedItem.ToString();

            bool flag=connection.IsConnection();
            if (flag)
            {
                MessageBox.Show("连接成功");
            }
            else
            {
                MessageBox.Show("连接失败");
            }
        }
    }
}
