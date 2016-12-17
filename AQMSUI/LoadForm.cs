using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using AQMSBLL;
using AQMSModel;

namespace AQMSUI
{
    public partial class LoadForm : Form
    {
        private Thread thread1; // 定义线程

        LoadFormBLL mLoadFormBLL = new LoadFormBLL();

        public LoadForm()
        {
            FirstRunApp();
            InitializeComponent();            
        }

        private void FirstRunApp()
        {
            if (mLoadFormBLL.GetFirstRun())
            {
                DialogResult drFirst = MessageBox.Show("第一次运行，请先进行系统参数配置！", "AQMS", MessageBoxButtons.OK);
                FirstRun1 mFirstRun1 = FirstRun1.GetForm();
                FirstRun2 mFirstRun2 = FirstRun2.GetForm();
                FirstRun3 mFirstRun3 = FirstRun3.GetForm();
                mFirstRun1.ShowDialog();
                mFirstRun1.Dispose();
                mFirstRun2.Dispose();
                mFirstRun3.Dispose();
                string strDataBasePath = Globle.m_AirStation.DBPath + "\\EnvSoft\\DataBase\\AQMS";
                if (!mLoadFormBLL.CreateDataBase(strDataBasePath))
                {
                    mLoadFormBLL.ClearFirstRun();
                    MessageBox.Show("数据库创建失败！停止运行！", "错误", MessageBoxButtons.OK);
                    System.Environment.Exit(0);
                }
                else
                {
                    MessageBox.Show("数据库创建成功！请重启系统！", "提示", MessageBoxButtons.OK);
                    System.Environment.Exit(0);
                }
            }
        }

        public void InitSystem()
        {
            SetProgressBarValue(10);
            SetLableText("正在加载系统参数...");
            Thread.Sleep(200);                        
            SetProgressBarValue(20);
            if (!mLoadFormBLL.InitAirStation())
            {
                MessageBox.Show("无法运行，系统配置错误！", "错误！");
                this.DialogResult = DialogResult.Cancel;
                return;
            }
            SetProgressBarValue(30);
            SetLableText("正在加载数据库配置...");
            Thread.Sleep(200);
            SetProgressBarValue(40);
            if (!mLoadFormBLL.TestSqlConnection())
            {
                MessageBox.Show("无法连接数据库，请重新配置！", "错误！");
                this.DialogResult = DialogResult.Cancel;
                return;
            }
            SetProgressBarValue(50);
            SetLableText("正在加载设备信息...");
            Thread.Sleep(200);           
            SetProgressBarValue(60);
            if (!mLoadFormBLL.InitAllDevices())
            {
                MessageBox.Show("无法运行，系统配置错误！", "错误！");
                this.DialogResult = DialogResult.Cancel;
                return;
            }
            SetProgressBarValue(70);
            SetLableText("正在加载监测信息...");
            Thread.Sleep(200);
            SetProgressBarValue(80);
            if (!mLoadFormBLL.InitAirDevices())
            {
                MessageBox.Show("无法运行，系统配置错误！", "错误！");
                this.DialogResult = DialogResult.Cancel;
                return;
            }
            SetProgressBarValue(90);
            SetLableText("加载完成");
            Thread.Sleep(200);
            SetProgressBarValue(100);
            SetLableText("正在启动");
            Thread.Sleep(200);
            this.DialogResult = DialogResult.OK;
            return;
        }

        private void SetProgressBarValue(int nValue)
        {
            this.Invoke((EventHandler)(delegate { progressBarControl1.Position = nValue; }));
        }

        private void SetLableText(string strText)
        {
            this.Invoke((EventHandler)(delegate { label_Begin_Show.Text = strText; }));
        }

        private void LoadForm_Load(object sender, EventArgs e)
        {            
            progressBarControl1.Properties.Maximum = 100;
            progressBarControl1.Properties.Minimum = 0;
            progressBarControl1.Position = 0;//当前值
            progressBarControl1.Properties.ShowTitle = true;//是否显示数据
            progressBarControl1.Properties.PercentView = true;

            thread1 = new Thread(new ThreadStart(InitSystem));
            thread1.Start();
        }
    }
}
