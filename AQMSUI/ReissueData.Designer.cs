namespace AQMSUI
{
    partial class ReissueData
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
            this.timeEnd = new DevExpress.XtraEditors.TimeEdit();
            this.timeBegin = new DevExpress.XtraEditors.TimeEdit();
            this.dateEnd = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dateBegin = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtSendCycle = new DevExpress.XtraEditors.TextEdit();
            this.txtPlatformNo = new DevExpress.XtraEditors.TextEdit();
            this.cboDataType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.timeEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeBegin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSendCycle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlatformNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDataType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // timeEnd
            // 
            this.timeEnd.EditValue = new System.DateTime(2016, 10, 20, 0, 0, 0, 0);
            this.timeEnd.Location = new System.Drawing.Point(212, 67);
            this.timeEnd.Name = "timeEnd";
            this.timeEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEnd.Size = new System.Drawing.Size(79, 20);
            this.timeEnd.TabIndex = 11;
            // 
            // timeBegin
            // 
            this.timeBegin.EditValue = new System.DateTime(2016, 10, 20, 0, 0, 0, 0);
            this.timeBegin.Location = new System.Drawing.Point(212, 32);
            this.timeBegin.Name = "timeBegin";
            this.timeBegin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeBegin.Size = new System.Drawing.Size(79, 20);
            this.timeBegin.TabIndex = 10;
            // 
            // dateEnd
            // 
            this.dateEnd.EditValue = null;
            this.dateEnd.Location = new System.Drawing.Point(101, 67);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Size = new System.Drawing.Size(100, 20);
            this.dateEnd.TabIndex = 9;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(35, 70);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "终止时间：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(35, 35);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "起始时间：";
            // 
            // dateBegin
            // 
            this.dateBegin.EditValue = null;
            this.dateBegin.Location = new System.Drawing.Point(101, 32);
            this.dateBegin.Name = "dateBegin";
            this.dateBegin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBegin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBegin.Size = new System.Drawing.Size(100, 20);
            this.dateBegin.TabIndex = 6;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(35, 105);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 14);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "发送周期：";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(35, 140);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 14);
            this.labelControl4.TabIndex = 13;
            this.labelControl4.Text = "数据类型：";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(35, 175);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(60, 14);
            this.labelControl5.TabIndex = 14;
            this.labelControl5.Text = "平台序号：";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(212, 167);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(132, 28);
            this.labelControl6.TabIndex = 15;
            this.labelControl6.Text = "（补发数据的平台序号，\r\n   即网络通道序号）";
            // 
            // txtSendCycle
            // 
            this.txtSendCycle.Location = new System.Drawing.Point(101, 102);
            this.txtSendCycle.Name = "txtSendCycle";
            this.txtSendCycle.Size = new System.Drawing.Size(100, 20);
            this.txtSendCycle.TabIndex = 16;
            // 
            // txtPlatformNo
            // 
            this.txtPlatformNo.Location = new System.Drawing.Point(101, 172);
            this.txtPlatformNo.Name = "txtPlatformNo";
            this.txtPlatformNo.Size = new System.Drawing.Size(100, 20);
            this.txtPlatformNo.TabIndex = 17;
            // 
            // cboDataType
            // 
            this.cboDataType.Location = new System.Drawing.Point(101, 137);
            this.cboDataType.Name = "cboDataType";
            this.cboDataType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDataType.Properties.Items.AddRange(new object[] {
            "实时数据",
            "小时数据",
            "日数据"});
            this.cboDataType.Size = new System.Drawing.Size(100, 20);
            this.cboDataType.TabIndex = 18;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(70, 222);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 19;
            this.btnOk.Text = "确 定";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(235, 222);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "取 消";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(212, 105);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(24, 14);
            this.labelControl7.TabIndex = 21;
            this.labelControl7.Text = "分钟";
            // 
            // ReissueData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 271);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cboDataType);
            this.Controls.Add(this.txtPlatformNo);
            this.Controls.Add(this.txtSendCycle);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.timeEnd);
            this.Controls.Add(this.timeBegin);
            this.Controls.Add(this.dateEnd);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.dateBegin);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReissueData";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "补发数据";
            ((System.ComponentModel.ISupportInitialize)(this.timeEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeBegin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSendCycle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlatformNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDataType.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TimeEdit timeEnd;
        private DevExpress.XtraEditors.TimeEdit timeBegin;
        private DevExpress.XtraEditors.DateEdit dateEnd;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dateBegin;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtSendCycle;
        private DevExpress.XtraEditors.TextEdit txtPlatformNo;
        private DevExpress.XtraEditors.ComboBoxEdit cboDataType;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl labelControl7;
    }
}