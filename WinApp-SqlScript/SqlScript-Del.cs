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

namespace WinApp_SqlScript
{
    public partial class SqlScript_Del : Form
    {
        DataService dataService=new DataService();
        public SqlScript_Del()
        {
            InitializeComponent();
        }

        private void SqlScript_Del_Load(object sender, EventArgs e)
        {
            if (SqlConnectionM.Status == "1")
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
            else
            {
                throw new Exception("数据库未连接");
            }
        }

        private void BindData()
        {
            DataTable dt = dataService.GetSqlServerDelFieldToTable(this.cboTable.SelectedValue.ToString().Trim());
            this.gvdataRow.DataSource = dt;
        }

        private void cboTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
