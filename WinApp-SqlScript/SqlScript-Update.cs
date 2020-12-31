using Oracle.ManagedDataAccess.Client;
using ScriptService;
using ScriptService.File;
using SqlScript_MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp_SqlScript
{
    public partial class SqlScript_Update : Form
    {
        private int CurrentRowIndex { get; set; } //当前行号
        private int CurrentColumnIndex { get; set; } //当前单元格

        DataService dataService = new DataService();
        GenerateSqlService generateService;

        public SqlScript_Update()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void SqlScript_Update_Load(object sender, EventArgs e)
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

                BindData();

                this.gvdataRow.Columns[1].DefaultCellStyle.BackColor = Color.Orange;
                this.gvdataRow.Columns[2].DefaultCellStyle.BackColor = Color.Orange;
                if(SqlConnectionM.Status!="1")
                this.gvdataRow.Columns[4].DefaultCellStyle.BackColor = Color.Orange;
            }
            this.FormBorderStyle = FormBorderStyle.None;
        }
        private void BindData()
        {
            if (SqlConnectionM.ServerType == "SqlServer")
            {
                DataTable dt = dataService.GetSqlServerUpdateFieldToTable(this.cboTable.SelectedValue.ToString().Trim());
                this.gvdataRow.AutoGenerateColumns = true;
                this.gvdataRow.DataSource = dt;
                //this.gvdataRow.DataMember = "FieldName";
            }
            else
            {
                DataTable dt = dataService.GetOracleUpdateFieldToTable(this.cboTable.SelectedValue.ToString().Trim());
                this.gvdataRow.DataSource = dt;
            }

        }

        private void btnClearSql_Click(object sender, EventArgs e)
        {
            this.txtSql.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFile.SaveFilesToText(txtSql.Text.ToString().Trim());
        }

        private void btnSqlServerSave_Click(object sender, EventArgs e)
        {
            generateService = new GenerateSqlService(new GenerateSqlServiceUpdateString());
            string msg = generateService.CreateSqlString(gvdataRow, cboTable.SelectedValue == null ? "" : cboTable.SelectedValue.ToString().Trim());
            txtSql.Text = msg;
        }

        private void cboTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnOracleSave_Click(object sender, EventArgs e)
        {
            generateService = new GenerateSqlService(new GenerateOracleUpdateString());
            string msg = generateService.CreateSqlString(gvdataRow, cboTable.SelectedValue == null ? "" : cboTable.SelectedValue.ToString().Trim());
            txtSql.Text = msg;
        }

        private void delRow_Click(object sender, EventArgs e)
        {
            if (!this.gvdataRow.Rows[CurrentRowIndex].IsNewRow)//判断是否为新行
            {
                this.gvdataRow.Rows.RemoveAt(CurrentRowIndex);//从集合中移除指定的行
            }
        }

        private void 添加行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.gvdataRow.Rows.Add();
        }

        private void gvdataRow_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                gvdataRow.ClearSelection();
                (sender as DataGridView).CurrentRow.Selected = false;
                (sender as DataGridView).Rows[e.RowIndex].Selected = true;

                contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void gvdataRow_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView)sender;
            CurrentRowIndex = e.RowIndex;
            CurrentColumnIndex = e.ColumnIndex;
        }
    }
}
