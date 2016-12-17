namespace AQMSUI
{
    partial class LoadForm
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
            this.label_Begin_Info = new System.Windows.Forms.Label();
            this.label_Begin_Show = new System.Windows.Forms.Label();
            this.panel_Form = new System.Windows.Forms.Panel();
            this.panel_AQMS = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.panel_Form.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Begin_Info
            // 
            this.label_Begin_Info.AutoSize = true;
            this.label_Begin_Info.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Begin_Info.Location = new System.Drawing.Point(389, 105);
            this.label_Begin_Info.Name = "label_Begin_Info";
            this.label_Begin_Info.Size = new System.Drawing.Size(341, 19);
            this.label_Begin_Info.TabIndex = 0;
            this.label_Begin_Info.Text = "CopyRight © 2016 盈峰环境-宇星科技";
            // 
            // label_Begin_Show
            // 
            this.label_Begin_Show.AutoSize = true;
            this.label_Begin_Show.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Begin_Show.Location = new System.Drawing.Point(12, 66);
            this.label_Begin_Show.Name = "label_Begin_Show";
            this.label_Begin_Show.Size = new System.Drawing.Size(115, 19);
            this.label_Begin_Show.TabIndex = 1;
            this.label_Begin_Show.Text = "正在加载...";
            // 
            // panel_Form
            // 
            this.panel_Form.Controls.Add(this.panel_AQMS);
            this.panel_Form.Controls.Add(this.panel1);
            this.panel_Form.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Form.Location = new System.Drawing.Point(0, 0);
            this.panel_Form.Name = "panel_Form";
            this.panel_Form.Size = new System.Drawing.Size(752, 475);
            this.panel_Form.TabIndex = 3;
            // 
            // panel_AQMS
            // 
            this.panel_AQMS.BackgroundImage = global::AQMSUI.Properties.Resources.AirQuality;
            this.panel_AQMS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_AQMS.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_AQMS.Location = new System.Drawing.Point(0, 0);
            this.panel_AQMS.Name = "panel_AQMS";
            this.panel_AQMS.Size = new System.Drawing.Size(752, 342);
            this.panel_AQMS.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.progressBarControl1);
            this.panel1.Controls.Add(this.label_Begin_Show);
            this.panel1.Controls.Add(this.label_Begin_Info);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 342);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(752, 133);
            this.panel1.TabIndex = 1;
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Location = new System.Drawing.Point(16, 25);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Size = new System.Drawing.Size(724, 22);
            this.progressBarControl1.TabIndex = 2;
            // 
            // LoadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 475);
            this.Controls.Add(this.panel_Form);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoadForm";
            this.Load += new System.EventHandler(this.LoadForm_Load);
            this.panel_Form.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_Begin_Info;
        private System.Windows.Forms.Label label_Begin_Show;
        private System.Windows.Forms.Panel panel_Form;
        private System.Windows.Forms.Panel panel_AQMS;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
    }
}