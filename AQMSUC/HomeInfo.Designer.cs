namespace AQMSUC
{
    partial class HomeInfo
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
            this.components = new System.ComponentModel.Container();
            this.timer_GDIShow = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer_GDIShow
            // 
            this.timer_GDIShow.Enabled = true;
            this.timer_GDIShow.Interval = 1000;
            this.timer_GDIShow.Tick += new System.EventHandler(this.timer_GDIShow_Tick);
            // 
            // HomeInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "HomeInfo";
            this.Size = new System.Drawing.Size(444, 311);
            this.SizeChanged += new System.EventHandler(this.HomeInfo_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.HomeInfo_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer_GDIShow;
    }
}
