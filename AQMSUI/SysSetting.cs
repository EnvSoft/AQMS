using System;
using System.Windows.Forms;
using AQMSUC;

namespace AQMSUI
{
    public partial class SysSetting : Form
    {
        public SysSetting()
        {
            InitializeComponent();
        }

        private SysSetUC1 mSysSetUC1 = new SysSetUC1();
        private SysSetUC2 mSysSetUC2 = new SysSetUC2();
        private SysSetUC3 mSysSetUC3 = new SysSetUC3();
        private SysSetUC4 mSysSetUC4 = new SysSetUC4();

        private static SysSetting SSForm;        

        public static SysSetting GetForm()
        {
            if (SSForm == null || SSForm.IsDisposed)
            {
                SSForm = new SysSetting();
            }
            return SSForm;
        }

        private void SysSetting_Load(object sender, EventArgs e)
        {
            
        }

        private void navigationFrame1_QueryControl(object sender, DevExpress.XtraBars.Navigation.QueryControlEventArgs e)
        {
            if (e.Page == this.navigationPage1)
            {
                e.Control = mSysSetUC1;
            }
            else if (e.Page == this.navigationPage2)
            {
                e.Control = mSysSetUC2;
            }
            else if (e.Page == this.navigationPage3)
            {
                e.Control = mSysSetUC3;
            }
            else if (e.Page == this.navigationPage4)
            {                
                e.Control = mSysSetUC4;
            }
        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            this.navigationFrame1.SelectedPage = this.navigationPage1;
        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
            this.navigationFrame1.SelectedPage = this.navigationPage2;
        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            this.navigationFrame1.SelectedPage = this.navigationPage3;
        }

        private void accordionControlElement5_Click(object sender, EventArgs e)
        {
            this.navigationFrame1.SelectedPage = this.navigationPage4;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
