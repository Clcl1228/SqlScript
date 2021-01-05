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
        private int CurrentRowIndex { get; set; } //当前行号
        private int CurrentColumnIndex { get; set; } //当前单元格

        DataService dataService = new DataService();
        GenerateSqlService generateService;
        public SqlScript_Del()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            this.gvdataRow.Columns[1].DefaultCellStyle.BackColor = Color.Orange;
            if (SqlConnectionM.Status != "1")
            {
                this.gvdataRow.Columns[3].DefaultCellStyle.BackColor = Color.Orange;
            }
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
                BindData();
            }
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void BindData()
        {
            if(SqlConnectionM.ServerType == "SqlServer")
            {
                DataTable dt = dataService.GetSqlServerDelFieldToTable(this.cboTable.Text.ToString().Trim());
                this.gvdataRow.DataSource = dt;
            }
            else
            {
                DataTable dt = dataService.GetOracleDelFieldToTable(this.cboTable.Text.ToString().Trim());
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
            string msg = generateService.CreateSqlString(gvdataRow, cboTable.Text == null ? "" : cboTable.Text.ToString().Trim());
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
            generateService = new GenerateSqlService(new GenerateOracleDelString());
            string msg = generateService.CreateSqlString(gvdataRow, cboTable.Text == null ? "" : cboTable.Text.ToString().Trim());
            txtSql.Text = msg;
        }

        private void btnAddRow_Click(object sender, EventArgs e)
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

        private void delRow_Click(object sender, EventArgs e)
        {
            if (!this.gvdataRow.Rows[CurrentRowIndex].IsNewRow)//判断是否为新行
            {
                this.gvdataRow.Rows.RemoveAt(CurrentRowIndex);//从集合中移除指定的行
            }
        }

        private void gvdataRow_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView)sender;
            CurrentRowIndex = e.RowIndex;
            CurrentColumnIndex = e.ColumnIndex;
        }

        private void 添加行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.gvdataRow.Rows.Add();
        }
    }
}
