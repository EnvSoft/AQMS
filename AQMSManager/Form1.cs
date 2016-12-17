using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace AQMSManager
{
    public partial class Form1 : Form
    {
        private bool isOpen;
        private bool isClose;

        public Form1()
        {
            InitializeComponent();
            isOpen = false;
            isClose = false;
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Process proce in Process.GetProcesses())
            {
                if ("Test" == proce.ProcessName)
                {
                    isOpen = true;
                    isClose = false;
                    return;
                }
            }

            if (isOpen == false && isClose == false)
            {
                Process.Start("Test.exe");
            }
            isOpen = false;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            foreach (Process proce in Process.GetProcesses())
            {
                if ("Test" == proce.ProcessName)
                {
                    MessageBox.Show("空气质量自动在线监测系统已经打开！", "AQMSManager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            Process.Start("Test.exe");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            foreach (Process proce in Process.GetProcesses())
            {
                if ("Test" == proce.ProcessName)
                {
                    if (MessageBox.Show("是否关闭空气质量自动在线监测系统？", "AQMSManager", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        proce.Kill();
                        isClose = true;
                    }
                    return;
                }
            }
            MessageBox.Show("空气质量自动在线监测系统没有打开！", "AQMSManager", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isOpen == true && MessageBox.Show("是否关闭空气质量自动在线监测系统？", "AQMSManager", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Process[] processes = Process.GetProcesses();
                foreach (Process proce in processes)
                {
                    if ("Test" == proce.ProcessName)
                        proce.Kill();
                }
            }
        }
    }
}