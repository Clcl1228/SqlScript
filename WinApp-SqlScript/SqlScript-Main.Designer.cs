
namespace WinApp_SqlScript
{
    partial class SqlScriptMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.新增字段ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除字段ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更新字段ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增字段ToolStripMenuItem,
            this.删除字段ToolStripMenuItem,
            this.更新字段ToolStripMenuItem,
            this.查询ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1220, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 新增字段ToolStripMenuItem
            // 
            this.新增字段ToolStripMenuItem.Name = "新增字段ToolStripMenuItem";
            this.新增字段ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.新增字段ToolStripMenuItem.Text = "新增字段";
            this.新增字段ToolStripMenuItem.Click += new System.EventHandler(this.新增字段ToolStripMenuItem_Click);
            // 
            // 删除字段ToolStripMenuItem
            // 
            this.删除字段ToolStripMenuItem.Name = "删除字段ToolStripMenuItem";
            this.删除字段ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.删除字段ToolStripMenuItem.Text = "删除字段";
            // 
            // 更新字段ToolStripMenuItem
            // 
            this.更新字段ToolStripMenuItem.Name = "更新字段ToolStripMenuItem";
            this.更新字段ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.更新字段ToolStripMenuItem.Text = "更新字段";
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.查询ToolStripMenuItem.Text = "查询";
            // 
            // SqlScriptMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 461);
            this.Controls.Add(this.menuStrip1);
            this.Name = "SqlScriptMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.SqlScriptMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新增字段ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除字段ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更新字段ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询ToolStripMenuItem;
    }
}

