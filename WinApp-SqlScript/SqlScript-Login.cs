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
        private string filePath = Application.StartupPath + @"\Server.xml";

        ServerService  connection = new ServerService();
        public SqlScript_Login()
        {
            InitializeComponent();
        }

        private void InitCombox()
        {
            IList<string> list = new List<string>() { "SqlServer", "Oracle" };
            this.comBoxServer.DataSource = list;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CheckButton();
            SaveLoginNews();

            XmlManagerService.UpdateXML(filePath, "UID", SqlConnectionM.LoginName);
            XmlManagerService.UpdateXML(filePath, "PWD", SqlConnectionM.PassWord);
            XmlManagerService.UpdateXML(filePath, "DataSource", SqlConnectionM.dataScore);
            XmlManagerService.UpdateXML(filePath, "Server", SqlConnectionM.ServerType);
            XmlManagerService.UpdateXML(filePath, "CateLog", SqlConnectionM.cataLog);

            MessageBox.Show("保存成功！");
        }

        private void SaveLoginNews()
        {
            SqlConnectionM.LoginName = this.txtUserName.Text;
            SqlConnectionM.PassWord = this.txtPassWord.Text;
            SqlConnectionM.dataScore = this.txtDataScore.Text;
            SqlConnectionM.ServerType = this.comBoxServer.SelectedValue.ToString();
            SqlConnectionM.cataLog = this.txtDataScore.Text;

            SqlConnectionM.SqlConnString = string.Format(SqlConnectionM.SqlConnString, SqlConnectionM.LoginName, SqlConnectionM.PassWord, SqlConnectionM.dataScore, SqlConnectionM.cataLog);
            SqlConnectionM.OracleConnString = string.Format(SqlConnectionM.OracleConnString, SqlConnectionM.LoginName, SqlConnectionM.PassWord, SqlConnectionM.dataScore, SqlConnectionM.cataLog);

        }

        private void CheckButton()
        {
            if (string.IsNullOrEmpty(this.txtUserName.Text))
            {
                throw new Exception("用户名不能为空！");
            }

            if (string.IsNullOrEmpty(this.txtPassWord.Text))
            {
                throw new Exception("密码不能为空！");
            }

            if (string.IsNullOrEmpty(this.txtDataScore.Text))
            {
                throw new Exception("数据源不能为空！");
            }
            if (string.IsNullOrEmpty(this.txtKu.Text))
            {
                throw new Exception("数据库不能为空！");
            }
        }

        [Obsolete]
        private void btnTest_Click(object sender, EventArgs e)
        {
            SqlConnectionM.LoginName = this.txtUserName.Text.Trim().ToString();
            SqlConnectionM.PassWord  = this.txtPassWord.Text.Trim().ToString();
            SqlConnectionM.dataScore = this.txtDataScore.Text.Trim().ToString();
            SqlConnectionM.ServerType = this.comBoxServer.SelectedItem.ToString();
            SqlConnectionM.cataLog = this.txtKu.Text.Trim().ToString();

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

        private void SqlScript_Login_Load(object sender, EventArgs e)
        {
            InitCombox();
        }
    }
}
