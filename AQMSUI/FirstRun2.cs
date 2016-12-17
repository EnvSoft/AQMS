using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AQMSModel;

namespace AQMSUI
{
    public partial class FirstRun2 : Form
    {
        public FirstRun2()
        {
            InitializeComponent();
        }

        private static FirstRun2 FRForm;

        public static FirstRun2 GetForm()
        {
            if (FRForm == null || FRForm.IsDisposed)
            {
                FRForm = new FirstRun2();
            }
            return FRForm;
        }

        private void label3_Click(object sender, EventArgs e)
        { // 上一步
            this.Hide();
            FirstRun1 mFirstRun1 = FirstRun1.GetForm();
            mFirstRun1.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        { // 下一步
            if (this.textBoxName.Text == "" || this.textBoxNum.Text == "")
            {
                MessageBox.Show("请填写站点信息！", "错误", MessageBoxButtons.OK);
                return;
            }
            Globle.m_AirStation.AirStationName = this.textBoxName.Text;
            Globle.m_AirStation.AirStationNum = this.textBoxNum.Text;
            Globle.m_AirStation.IsAutoStart = this.checkBox1.Checked;
            this.Hide();
            FirstRun3 mFirstRun3 = FirstRun3.GetForm();
            mFirstRun3.ShowDialog();
        }
    }
}
