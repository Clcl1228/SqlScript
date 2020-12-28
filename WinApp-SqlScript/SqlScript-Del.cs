using SqlScript_MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScriptService;
using System.IO;
using ScriptService.File;

namespace WinApp_SqlScript
{
    public partial class SqlScript_Del : Form
    {
        DataService dataService = new DataService();
        GenerateSqlService generateService;
        public SqlScript_Del()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void SqlScript_Del_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            if (SqlConnectionM.ServerType == "SqlServer")
            {
                SqlDataReader dataReader = DBUtility.DbHelperSQL.GetAllTable();
                dt.Load(dataReader);
                dataReader.Close();
            }
            else if (SqlConnectionM.ServerType == "Oracle")
            {
                OracleDataReader dataReader = dataService.GetOracleAllTable();
                dt.Load(dataReader);
                dataReader.Close();
            }

            this.cboTable.DataSource = dt;
            this.cboTable.DisplayMember = "name";
            this.cboTable.ValueMember = "name";
            this.FormBorderStyle = FormBorderStyle.None;

            BindData();
        }

        private void BindData()
        {
            if(SqlConnectionM.ServerType == "SqlServer")
            {
                DataTable dt = dataService.GetSqlServerDelFieldToTable(this.cboTable.SelectedValue.ToString().Trim());
                this.gvdataRow.DataSource = dt;
            }
            else
            {
                DataTable dt = dataService.GetOracleDelFieldToTable(this.cboTable.SelectedValue.ToString().Trim());
                this.gvdataRow.DataSource = dt;
            }
            
        }

        private void cboTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            generateService = new GenerateSqlService(new GenerateSqlServiceDelString());
            string msg = generateService.CreateSqlString(gvdataRow);
            txtSql.Text = msg;
        }

        private void btnClearSql_Click(object sender, EventArgs e)
        {
            this.txtSql.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFile.SaveFilesToText(txtSql.Text.ToString().Trim());
        }

        private void btnCreateSqlO_Click(object sender, EventArgs e)
        {
            generateService = new GenerateSqlService(new GenerateSqlServiceDelString());
            string msg = generateService.CreateSqlString(gvdataRow);
            txtSql.Text = msg;
        }
    }
}
