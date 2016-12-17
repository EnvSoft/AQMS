namespace AQMSUC
{
    partial class AirItemDocment
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_Statues = new System.Windows.Forms.Label();
            this.label_Unit = new System.Windows.Forms.Label();
            this.label_Value = new System.Windows.Forms.Label();
            this.label_Name = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label_Statues);
            this.panel1.Controls.Add(this.label_Unit);
            this.panel1.Controls.Add(this.label_Value);
            this.panel1.Controls.Add(this.label_Name);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 250);
            this.panel1.TabIndex = 0;
            // 
            // label_Statues
            // 
            this.label_Statues.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_Statues.AutoSize = true;
            this.label_Statues.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Statues.Location = new System.Drawing.Point(3, 220);
            this.label_Statues.Name = "label_Statues";
            this.label_Statues.Size = new System.Drawing.Size(89, 20);
            this.label_Statues.TabIndex = 4;
            this.label_Statues.Text = "仪器正常";
            // 
            // label_Unit
            // 
            this.label_Unit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Unit.AutoSize = true;
            this.label_Unit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Unit.Location = new System.Drawing.Point(152, 220);
            this.label_Unit.Name = "label_Unit";
            this.label_Unit.Size = new System.Drawing.Size(59, 20);
            this.label_Unit.TabIndex = 3;
            this.label_Unit.Text = "mg/m3";
            this.label_Unit.Click += new System.EventHandler(this.label_Unit_Click);
            // 
            // label_Value
            // 
            this.label_Value.AutoSize = true;
            this.label_Value.Font = new System.Drawing.Font("宋体", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Value.Location = new System.Drawing.Point(66, 120);
            this.label_Value.Name = "label_Value";
            this.label_Value.Size = new System.Drawing.Size(117, 38);
            this.label_Value.TabIndex = 1;
            this.label_Value.Text = "0.123";
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Font = new System.Drawing.Font("宋体", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Name.Location = new System.Drawing.Point(77, 57);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(77, 38);
            this.label_Name.TabIndex = 0;
            this.label_Name.Text = "SO2";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(217, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(43, 250);
            this.panel2.TabIndex = 5;
            // 
            // AirItemDocment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "AirItemDocment";
            this.Size = new System.Drawing.Size(260, 250);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.Label label_Statues;
        private System.Windows.Forms.Label label_Unit;
        private System.Windows.Forms.Label label_Value;
        private System.Windows.Forms.Panel panel2;
    }
}
