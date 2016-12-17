using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AQMSModel;
using AQMSBLL;

namespace AQMSUI
{
    public partial class FirstRun3 : Form
    {
        public FirstRun3()
        {
            InitializeComponent();
        }

        private static FirstRun3 FRForm;

        public static FirstRun3 GetForm()
        {
            if (FRForm == null || FRForm.IsDisposed)
            {
                FRForm = new FirstRun3();
            }
            return FRForm;
        }

        private void label6_Click(object sender, EventArgs e)
        { // 下一步
            if (this.textBoxPath.Text == "")
            {
                MessageBox.Show("请选择数据库创建路径！", "错误", MessageBoxButtons.OK);
                return;
            }
            Globle.m_AirStation.DBPath = this.textBoxPath.Text;
            LoadFormBLL mLoadFormBLL = new LoadFormBLL();
            if (!mLoadFormBLL.SaveAirStation())
            {
                MessageBox.Show("保存参数失败！", "错误", MessageBoxButtons.OK);
                return;
            }
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        { // 上一步
            this.Hide();
            FirstRun2 mFirstRun2 = FirstRun2.GetForm();
            mFirstRun2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        { // 浏览路径
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择数据库创建路径";
            string strPath = "";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                strPath = dialog.SelectedPath;
            }
            this.textBoxPath.Text = strPath;
        }        
    }
}
