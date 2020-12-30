
namespace WinApp_SqlScript
{
    partial class SqlScript_Update
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSave = new System.Windows.Forms.Button();
            this.cboTable = new System.Windows.Forms.ComboBox();
            this.btnClearSql = new System.Windows.Forms.Button();
            this.btnSqlServerSave = new System.Windows.Forms.Button();
            this.btnOracleSave = new System.Windows.Forms.Button();
            this.groupSql = new System.Windows.Forms.GroupBox();
            this.txtSql = new System.Windows.Forms.TextBox();
            this.groupAdd = new System.Windows.Forms.GroupBox();
            this.gvdataRow = new System.Windows.Forms.DataGridView();
            this.cboDel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupSql.SuspendLayout();
            this.groupAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvdataRow)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.AccessibleName = "表名";
            this.btnSave.Location = new System.Drawing.Point(610, 236);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 23);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "保存到文件";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cboTable
            // 
            this.cboTable.FormattingEnabled = true;
            this.cboTable.Location = new System.Drawing.Point(575, 52);
            this.cboTable.Name = "cboTable";
            this.cboTable.Size = new System.Drawing.Size(172, 20);
            this.cboTable.TabIndex = 23;
            this.cboTable.SelectedIndexChanged += new System.EventHandler(this.cboTable_SelectedIndexChanged);
            // 
            // btnClearSql
            // 
            this.btnClearSql.AccessibleName = "表名";
            this.btnClearSql.Location = new System.Drawing.Point(610, 295);
            this.btnClearSql.Name = "btnClearSql";
            this.btnClearSql.Size = new System.Drawing.Size(100, 23);
            this.btnClearSql.TabIndex = 22;
            this.btnClearSql.Text = "清空Sql";
            this.btnClearSql.UseVisualStyleBackColor = true;
            this.btnClearSql.Click += new System.EventHandler(this.btnClearSql_Click);
            // 
            // btnSqlServerSave
            // 
            this.btnSqlServerSave.AccessibleName = "表名";
            this.btnSqlServerSave.Location = new System.Drawing.Point(610, 112);
            this.btnSqlServerSave.Name = "btnSqlServerSave";
            this.btnSqlServerSave.Size = new System.Drawing.Size(100, 23);
            this.btnSqlServerSave.TabIndex = 21;
            this.btnSqlServerSave.Text = "生成SqlServer";
            this.btnSqlServerSave.UseVisualStyleBackColor = true;
            this.btnSqlServerSave.Click += new System.EventHandler(this.btnSqlServerSave_Click);
            // 
            // btnOracleSave
            // 
            this.btnOracleSave.AccessibleName = "表名";
            this.btnOracleSave.Location = new System.Drawing.Point(610, 176);
            this.btnOracleSave.Name = "btnOracleSave";
            this.btnOracleSave.Size = new System.Drawing.Size(100, 23);
            this.btnOracleSave.TabIndex = 20;
            this.btnOracleSave.Text = "生成Oracle";
            this.btnOracleSave.UseVisualStyleBackColor = true;
            this.btnOracleSave.Click += new System.EventHandler(this.btnOracleSave_Click);
            // 
            // groupSql
            // 
            this.groupSql.Controls.Add(this.txtSql);
            this.groupSql.Location = new System.Drawing.Point(753, 12);
            this.groupSql.Name = "groupSql";
            this.groupSql.Size = new System.Drawing.Size(455, 397);
            this.groupSql.TabIndex = 19;
            this.groupSql.TabStop = false;
            this.groupSql.Text = "Sql语句";
            // 
            // txtSql
            // 
            this.txtSql.Location = new System.Drawing.Point(6, 20);
            this.txtSql.Multiline = true;
            this.txtSql.Name = "txtSql";
            this.txtSql.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSql.Size = new System.Drawing.Size(443, 371);
            this.txtSql.TabIndex = 0;
            this.txtSql.WordWrap = false;
            // 
            // groupAdd
            // 
            this.groupAdd.Controls.Add(this.gvdataRow);
            this.groupAdd.Location = new System.Drawing.Point(12, 12);
            this.groupAdd.Name = "groupAdd";
            this.groupAdd.Size = new System.Drawing.Size(557, 397);
            this.groupAdd.TabIndex = 18;
            this.groupAdd.TabStop = false;
            this.groupAdd.Text = "修改字段";
            // 
            // gvdataRow
            // 
            this.gvdataRow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvdataRow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cboDel});
            this.gvdataRow.Location = new System.Drawing.Point(6, 20);
            this.gvdataRow.Name = "gvdataRow";
            this.gvdataRow.RowTemplate.Height = 23;
            this.gvdataRow.Size = new System.Drawing.Size(537, 371);
            this.gvdataRow.TabIndex = 0;
            // 
            // cboDel
            // 
            this.cboDel.HeaderText = "勾选更新";
            this.cboDel.Name = "cboDel";
            this.cboDel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cboDel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cboDel.Width = 80;
            // 
            // SqlScript_Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 421);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboTable);
            this.Controls.Add(this.btnClearSql);
            this.Controls.Add(this.btnSqlServerSave);
            this.Controls.Add(this.btnOracleSave);
            this.Controls.Add(this.groupSql);
            this.Controls.Add(this.groupAdd);
            this.Name = "SqlScript_Update";
            this.Text = "SqlScript_Update";
            this.Load += new System.EventHandler(this.SqlScript_Update_Load);
            this.groupSql.ResumeLayout(false);
            this.groupSql.PerformLayout();
            this.groupAdd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvdataRow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cboTable;
        private System.Windows.Forms.Button btnClearSql;
        private System.Windows.Forms.Button btnSqlServerSave;
        private System.Windows.Forms.Button btnOracleSave;
        private System.Windows.Forms.GroupBox groupSql;
        private System.Windows.Forms.TextBox txtSql;
        private System.Windows.Forms.GroupBox groupAdd;
        private System.Windows.Forms.DataGridView gvdataRow;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cboDel;
    }
}