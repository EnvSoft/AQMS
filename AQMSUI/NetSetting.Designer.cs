namespace AQMSUI
{
    partial class NetSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetSetting));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiParamConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.手动补发数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStartReissue = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStopReissue = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightGray;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.手动补发数据ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(725, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiParamConfig});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // tsmiParamConfig
            // 
            this.tsmiParamConfig.Name = "tsmiParamConfig";
            this.tsmiParamConfig.Size = new System.Drawing.Size(152, 22);
            this.tsmiParamConfig.Text = "参数配置";
            // 
            // 手动补发数据ToolStripMenuItem
            // 
            this.手动补发数据ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiStartReissue,
            this.tsmiStopReissue});
            this.手动补发数据ToolStripMenuItem.Name = "手动补发数据ToolStripMenuItem";
            this.手动补发数据ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.手动补发数据ToolStripMenuItem.Text = "手动补发数据";
            // 
            // tsmiStartReissue
            // 
            this.tsmiStartReissue.Name = "tsmiStartReissue";
            this.tsmiStartReissue.Size = new System.Drawing.Size(152, 22);
            this.tsmiStartReissue.Text = "开始补发";
            // 
            // tsmiStopReissue
            // 
            this.tsmiStopReissue.Name = "tsmiStopReissue";
            this.tsmiStopReissue.Size = new System.Drawing.Size(152, 22);
            this.tsmiStopReissue.Text = "停止补发";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 28);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(720, 431);
            this.textBox1.TabIndex = 1;
            // 
            // NetSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 461);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "NetSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "联网传输配置";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiParamConfig;
        private System.Windows.Forms.ToolStripMenuItem 手动补发数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiStartReissue;
        private System.Windows.Forms.ToolStripMenuItem tsmiStopReissue;
        private System.Windows.Forms.TextBox textBox1;
    }
}