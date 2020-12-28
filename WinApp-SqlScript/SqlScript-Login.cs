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
            SaveLoginNews();

            XmlManagerService.UpdateXML(filePath, "UID", SqlConnectionM.LoginName);
            XmlManagerService.UpdateXML(filePath, "PWD", SqlConnectionM.PassWord);
            XmlManagerService.UpdateXML(filePath, "DataSource", SqlConnectionM.dataScore);
            XmlManagerService.UpdateXML(filePath, "Server", SqlConnectionM.ServerType);
            XmlManagerService.UpdateXML(filePath, "DBName", SqlConnectionM.cataLog);

            MessageBox.Show("保存成功！");
            //this.Hide();
            //SqlScriptMain main = new SqlScriptMain(this);
            //main.Show();

        }

        private void SaveLoginNews()
        {
            CheckButton();
            SaveLoginMessages();
        }

        private void SaveLoginMessages()
        {
            SqlConnectionM.LoginName = this.txtUserName.Text;
            SqlConnectionM.PassWord = this.txtPassWord.Text;
            SqlConnectionM.dataScore = this.txtDataScore.Text;
            SqlConnectionM.ServerType = this.comBoxServer.SelectedValue.ToString();
            SqlConnectionM.cataLog = this.txtKu.Text;

            SqlConnectionM.SqlConnString = string.Format(SqlConnectionM.SqlConnStringM, SqlConnectionM.LoginName, SqlConnectionM.PassWord, SqlConnectionM.dataScore, SqlConnectionM.cataLog);
            SqlConnectionM.OracleConnString = string.Format(SqlConnectionM.OracleConnStringM, SqlConnectionM.LoginName, SqlConnectionM.PassWord, SqlConnectionM.dataScore, SqlConnectionM.cataLog);

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
            if (string.IsNullOrEmpty(this.txtKu.Text)&& this.comBoxServer.SelectedValue=="Sqlerver")
            {
                throw new Exception("数据库不能为空！");
            }
        }

        [Obsolete]
        private void btnTest_Click(object sender, EventArgs e)
        {
            SaveLoginNews();

            bool flag=connection.IsConnection();
            if (flag)
            {
                MessageBox.Show("连接成功");
                SqlConnectionM.Status = "1";
                OpenMain();
            }
            else
            {
                MessageBox.Show("连接失败");
            }
        }

        private void SqlScript_Login_Load(object sender, EventArgs e)
        {
            InitCombox();
            InitLoginInfo();
            LoadLoginforXml();
        }

        private void InitLoginInfo()
        {
            string userID = string.Empty;
            string password = string.Empty;
            string dataSource = string.Empty;
            string ku = string.Empty;
            XmlManagerService.ReadNodeValue(filePath, "UID", ref userID);
            XmlManagerService.ReadNodeValue(filePath, "PWD", ref password);
            XmlManagerService.ReadNodeValue(filePath, "DataSource", ref dataSource);
            XmlManagerService.ReadNodeValue(filePath, "DBName", ref ku);
            this.txtUserName.Text = userID;
            this.txtPassWord.Text = password;
            this.txtDataScore.Text = dataSource;
            this.txtKu.Text = ku;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            OpenMain();
        }

        private void OpenMain()
        {
            this.Hide();
            SqlScriptMain main = new SqlScriptMain(this);
            main.Show();
        }

        private void LoadLoginforXml()
        {
            string userID = string.Empty;
            string password = string.Empty;
            string dataSource = string.Empty;
            string ku = string.Empty;

            XmlManagerService.ReadNodeValue(filePath, "PWD", ref password);
            XmlManagerService.ReadNodeValue(filePath, "UID", ref userID);
            XmlManagerService.ReadNodeValue(filePath, "DataSource", ref dataSource);
            XmlManagerService.ReadNodeValue(filePath, "DBName", ref ku);

            //SqlConnectionM.LoginName = userID;
            //SqlConnectionM.PassWord = password;
            //SqlConnectionM.dataScore = dataSource;
            //SqlConnectionM.cataLog = ku;

            //SqlConnectionM.SqlConnString = string.Format(SqlConnectionM.SqlConnString, SqlConnectionM.LoginName, SqlConnectionM.PassWord, SqlConnectionM.dataScore, SqlConnectionM.cataLog);
            //SqlConnectionM.OracleConnString = string.Format(SqlConnectionM.OracleConnString, SqlConnectionM.LoginName, SqlConnectionM.PassWord, SqlConnectionM.dataScore);

        }
    }
}
