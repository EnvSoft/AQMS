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
    public partial class FirstRun1 : Form
    {
        public FirstRun1()
        {
            InitializeComponent();
        }

        private static FirstRun1 FRForm;

        public static FirstRun1 GetForm()
        {
            if (FRForm == null || FRForm.IsDisposed)
            {
                FRForm = new FirstRun1();
            }
            return FRForm;
        }

        private void label6_Click(object sender, EventArgs e)
        { // 下一步
            if (this.textBoxServer.Text == "" || this.textBoxUser.Text == "" || this.textBoxName.Text == "")
            {
                MessageBox.Show("请填写数据库参数！", "错误", MessageBoxButtons.OK);
                return;
            }
            Globle.m_AirStation.DBServer = this.textBoxServer.Text;
            Globle.m_AirStation.DBUser = this.textBoxUser.Text;
            Globle.m_AirStation.DBPass = this.textBoxPass.Text;
            Globle.m_AirStation.DBName = this.textBoxName.Text;
            this.Hide();
            FirstRun2 mFirstRun2 = FirstRun2.GetForm();
            mFirstRun2.ShowDialog();
        }
    }
}
