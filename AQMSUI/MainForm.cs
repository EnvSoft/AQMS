using AQMSBLL;
using DevExpress.XtraBars.Docking2010.Views.Widget;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AQMSModel;


namespace AQMSUI
{
    public partial class MainForm : Form
    {
        //[DllImport("shell32.dll")]
        //public extern static IntPtr ShellExecute(IntPtr hwnd,
        //                                         string lpOperation,
        //                                         string lpFile,
        //                                         string lpParameters,
        //                                         string lpDirectory,
        //                                         int nShowCmd
        //                                        );
        //public enum ShowWindowCommands : int
        //{

        //    SW_HIDE = 0,
        //    SW_SHOWNORMAL = 1,
        //    SW_NORMAL = 1,
        //    SW_SHOWMINIMIZED = 2,
        //    SW_SHOWMAXIMIZED = 3,
        //    SW_MAXIMIZE = 3,
        //    SW_SHOWNOACTIVATE = 4,
        //    SW_SHOW = 5,
        //    SW_MINIMIZE = 6,
        //    SW_SHOWMINNOACTIVE = 7,
        //    SW_SHOWNA = 8,
        //    SW_RESTORE = 9,
        //    SW_SHOWDEFAULT = 10,
        //    SW_MAX = 10
        //}

        public MainForm()
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;
            InitDocmentManager();
        }

        private static MainForm MForm;

        public static MainForm GetForm()
        {
            if (MForm == null || MForm.IsDisposed)
            {
                MForm = new MainForm();
            }
            return MForm;
        }

        public void InitDocmentManager()
        {
            #region 加载状态和菜单Docment
            StackGroup stackGroup1 = new StackGroup();
            ucDocmentManager_HomeInfo.SetLayoutMode(LayoutMode.TableLayout);
            ucDocmentManager_HomeInfo.AddStackGroup(stackGroup1);
            ColumnDefinition HomeInfoColumn1 = new ColumnDefinition();
            HomeInfoColumn1.Length.UnitType = LengthUnitType.Star;
            HomeInfoColumn1.Length.UnitValue = 1;
            ucDocmentManager_HomeInfo.AddColumn(HomeInfoColumn1);
            RowDefinition HomeInfoRow1 = new RowDefinition();
            RowDefinition HomeInfoRow2 = new RowDefinition();
            HomeInfoRow1.Length.UnitType = LengthUnitType.Star;
            HomeInfoRow1.Length.UnitValue = 3;
            HomeInfoRow2.Length.UnitType = LengthUnitType.Star;
            HomeInfoRow2.Length.UnitValue = 6;
            ucDocmentManager_HomeInfo.AddRow(HomeInfoRow1);
            ucDocmentManager_HomeInfo.AddRow(HomeInfoRow2);

            Document homeDocment = new Document();
            homeDocment.Caption = "系统状态";
            homeDocment.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.False;
            homeDocment.Properties.AllowMaximize = DevExpress.Utils.DefaultBoolean.False;
            homeDocment.ColumnIndex = 0;
            homeDocment.ColumnSpan = 1;
            homeDocment.RowIndex = 0;
            homeDocment.RowSpan = 1;
            
            Document homeMenu = new Document();
            homeMenu.Caption = "系统菜单";
            homeMenu.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.False;
            homeMenu.ColumnIndex = 0;
            homeMenu.ColumnSpan = 1;
            homeMenu.RowIndex = 1;
            homeMenu.RowSpan = 1;
            stackGroup1.Items.Add(homeDocment);
            stackGroup1.Items.Add(homeMenu);
            ucDocmentManager_HomeInfo.AddDocument(homeDocment);
            ucDocmentManager_HomeInfo.AddDocument(homeMenu);
            #endregion

            #region 加载曲线、AQI和数据显示Docment        
            StackGroup stackGroup2 = new StackGroup();
            ucDocmentManager_Device.SetLayoutMode(LayoutMode.TableLayout);
            ucDocmentManager_Device.AddStackGroup(stackGroup2);
            ColumnDefinition deviceColumn1 = new ColumnDefinition();
            ColumnDefinition deviceColumn2 = new ColumnDefinition();
            deviceColumn1.Length.UnitType = LengthUnitType.Star;
            deviceColumn1.Length.UnitValue = 6;            
            deviceColumn2.Length.UnitType = LengthUnitType.Star;
            deviceColumn2.Length.UnitValue = 3;
            ucDocmentManager_Device.AddColumn(deviceColumn1);
            ucDocmentManager_Device.AddColumn(deviceColumn2);
            RowDefinition deviceRow1 = new RowDefinition();
            RowDefinition deviceRow2 = new RowDefinition();
            deviceRow1.Length.UnitType = LengthUnitType.Star;
            deviceRow1.Length.UnitValue = 3;
            deviceRow2.Length.UnitType = LengthUnitType.Star;
            deviceRow2.Length.UnitValue = 6;
            ucDocmentManager_Device.AddRow(deviceRow1);
            ucDocmentManager_Device.AddRow(deviceRow2);

            Document homeChart = new Document();
            homeChart.Caption = "主页曲线";
            homeChart.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.False;
            homeChart.ColumnIndex = 0;
            homeChart.ColumnSpan = 1;
            homeChart.RowIndex = 0;
            homeChart.RowSpan = 1;
            Document homeAQI = new Document();
            homeAQI.Caption = "主页AQI";
            homeAQI.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.False;
            homeAQI.Properties.AllowMaximize = DevExpress.Utils.DefaultBoolean.False;
            homeAQI.ColumnIndex = 1;
            homeAQI.ColumnSpan = 1;
            homeAQI.RowIndex = 0;
            homeAQI.RowSpan = 1;
            Document homeDevice = new Document();
            homeDevice.Caption = "数据显示";
            homeDevice.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.False;
            homeDevice.ColumnIndex = 0;
            homeDevice.ColumnSpan = 2;
            homeDevice.RowIndex = 1;
            homeDevice.RowSpan = 1;
            stackGroup2.Items.Add(homeChart);
            stackGroup2.Items.Add(homeAQI);
            stackGroup2.Items.Add(homeDevice);
            ucDocmentManager_Device.AddDocument(homeChart);
            ucDocmentManager_Device.AddDocument(homeAQI);
            ucDocmentManager_Device.AddDocument(homeDevice);
            #endregion
        }

        #region 系统菜单栏响应事件
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        { // 主菜单
            if (e.Button == MouseButtons.Left)
            {
                this.contextMenuStrip1.Show(this.pictureBox1, 5, 25);
            }
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            mainmenuTip.Show("主菜单", this.pictureBox1, 5, 25);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            mainmenuTip.Hide(this.pictureBox1);
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        { // 最小化
            if (e.Button == MouseButtons.Left)
            {
                this.WindowState = FormWindowState.Minimized;
            }           
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox2.BackgroundImage = global::AQMSUI.Properties.Resources.min_red;
            minTip.Show("最小化", this.pictureBox2, 5, 25);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox2.BackgroundImage = global::AQMSUI.Properties.Resources.min_withe;
            minTip.Hide(this.pictureBox2);
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox3.BackgroundImage = global::AQMSUI.Properties.Resources.close_1;
            closeTip.Show("关闭", this.pictureBox3, 5, 25);
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox3.BackgroundImage = global::AQMSUI.Properties.Resources.close_2;
            closeTip.Hide(this.pictureBox3);
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        { // 退出
            if (e.Button == MouseButtons.Left)
            {
                //if (AppGloble.m_User.UserGroup == "" || AppGloble.m_User.UserGroup == "guest")
                //{
                //    MessageBoxButtons messButton1 = MessageBoxButtons.OK;
                //    DialogResult dr1 = MessageBox.Show("未登录或用户权限不够！", "AQMS", messButton1);
                //    return;
                //}
                MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("确定要退出空气质量监测系统吗?", "AQMS", messButton);
                if (dr == DialogResult.OK)
                {
                    // System.Environment.Exit(0);
                    Application.Exit();
                }
            }           
        }

        private ToolTip mainmenuTip;
        private ToolTip minTip;
        private ToolTip closeTip;
        public void InitToolTips()
        {
            mainmenuTip = new ToolTip();
            mainmenuTip.SetToolTip(this.pictureBox1, "主菜单");
            mainmenuTip.AutoPopDelay = 100000;
            mainmenuTip.InitialDelay = 500;
            mainmenuTip.ReshowDelay = 800;

            minTip = new ToolTip();
            minTip.SetToolTip(this.pictureBox2, "最小化");
            minTip.AutoPopDelay = 100000;
            minTip.InitialDelay = 500;
            minTip.ReshowDelay = 800;

            closeTip = new ToolTip();
            closeTip.SetToolTip(this.pictureBox3, "关闭");
            closeTip.AutoPopDelay = 100000;
            closeTip.InitialDelay = 500;
            closeTip.ReshowDelay = 800;
        }
        #endregion

        #region 主菜单事件响应
        private void 用户登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserLogin userLogin = new UserLogin();
            userLogin.ShowDialog();
        }

        private void 系统参数设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globle.m_User.UserGroup == "" || Globle.m_User.UserGroup == "guest")
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                DialogResult dr = MessageBox.Show("未登录或用户权限不够！", "AQMS", messButton);
                return;
            }
            SysSetting sysSetForm = SysSetting.GetForm();
            sysSetForm.Show();
        }

        private void 高级设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globle.m_User.UserGroup == "" || Globle.m_User.UserGroup == "guest" || Globle.m_User.UserGroup == "操作员")
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                DialogResult dr = MessageBox.Show("未登录或用户权限不够！", "AQMS", messButton);
                return;
            }
            MoreSetting moreSetForm = MoreSetting.GetForm();
            moreSetForm.Show();
        }

        private void 监测设备配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globle.m_User.UserGroup == "" || Globle.m_User.UserGroup == "guest")
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                DialogResult dr = MessageBox.Show("未登录或用户权限不够！", "AQMS", messButton);
                return;
            }
            DeviceSetting devSetForm = DeviceSetting.GetForm();
            devSetForm.Show();
        }

        private void 联网传输配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globle.m_User.UserGroup == "" || Globle.m_User.UserGroup == "guest")
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                DialogResult dr = MessageBox.Show("未登录或用户权限不够！", "AQMS", messButton);
                return;
            }
            NetSetting netSetForm = NetSetting.GetForm();
            netSetForm.Show();
        }

        private void 历史数据查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globle.m_User.UserGroup == "")
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                DialogResult dr = MessageBox.Show("未登录或用户权限不够！", "AQMS", messButton);
                return;
            }
            DataReport dataReport = DataReport.GetForm();
            dataReport.Show();
        }

        private void 状态信息查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globle.m_User.UserGroup == "")
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                DialogResult dr = MessageBox.Show("未登录或用户权限不够！", "AQMS", messButton);
                return;
            }
            StatuesReport statuesReprot = StatuesReport.GetForm();
            statuesReprot.Show();
        }

        private void aQI实时报表查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globle.m_User.UserGroup == "")
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                DialogResult dr = MessageBox.Show("未登录或用户权限不够！", "AQMS", messButton);
                return;
            }
            AQIReport AQIRealReport = AQIReport.GetForm(1);
            AQIRealReport.Show();
        }

        private void aQI日报表查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globle.m_User.UserGroup == "")
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                DialogResult dr = MessageBox.Show("未登录或用户权限不够！", "AQMS", messButton);
                return;
            }
            AQIReport AQIDayReport = AQIReport.GetForm(2);
            AQIDayReport.Show();
        }

        private void 现场质控任务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globle.m_User.UserGroup == "" || Globle.m_User.UserGroup == "guest")
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                DialogResult dr = MessageBox.Show("未登录或用户权限不够！", "AQMS", messButton);
                return;
            }
            LocalControl localControl = LocalControl.GetForm();
            localControl.Show();
        }

        private void 定时质控任务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globle.m_User.UserGroup == "" || Globle.m_User.UserGroup == "guest")
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                DialogResult dr = MessageBox.Show("未登录或用户权限不够！", "AQMS", messButton);
                return;
            }
            TimerControl timerControl = TimerControl.GetForm();
            timerControl.Show();
        }

        private void 质控预标识ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globle.m_User.UserGroup == "" || Globle.m_User.UserGroup == "guest")
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                DialogResult dr = MessageBox.Show("未登录或用户权限不够！", "AQMS", messButton);
                return;
            }
            ControlStatues controlStatues = ControlStatues.GetForm();
            controlStatues.Show();
        }

        private void 质控任务查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globle.m_User.UserGroup == "" || Globle.m_User.UserGroup == "guest")
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                DialogResult dr = MessageBox.Show("未登录或用户权限不够！", "AQMS", messButton);
                return;
            }
            ControlReport controlReport = ControlReport.GetForm();
            controlReport.Show();
        }

        private void 串口调试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globle.m_User.UserGroup == "" || Globle.m_User.UserGroup == "guest" || Globle.m_User.UserGroup == "操作员")
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                DialogResult dr = MessageBox.Show("未登录或用户权限不够！", "AQMS", messButton);
                return;
            }
            string strDataFile = Application.StartupPath + "\\tools\\串口调试助手\\UartAssist.exe";
            if (!File.Exists(strDataFile))
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                MessageBox.Show("错误！指定路径下不存在目标文件！", "AQMS", messButton);
                return;
            }
            System.Diagnostics.Process.Start(strDataFile);
        }

        private void 串口侦测ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globle.m_User.UserGroup == "" || Globle.m_User.UserGroup == "guest" || Globle.m_User.UserGroup == "操作员")
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                DialogResult dr = MessageBox.Show("未登录或用户权限不够！", "AQMS", messButton);
                return;
            }
            string strDataFile = Application.StartupPath + "\\tools\\串口侦测工具\\AccessPort.exe";
            if (!File.Exists(strDataFile))
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                MessageBox.Show("错误！指定路径下不存在目标文件！", "AQMS", messButton);
                return;
            }
            System.Diagnostics.Process.Start(strDataFile);
        }

        private void 检查更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globle.m_User.UserGroup == "" || Globle.m_User.UserGroup == "guest")
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                DialogResult dr = MessageBox.Show("未登录或用户权限不够！", "AQMS", messButton);
                return;
            }
            UpdateForm updateForm = new UpdateForm();
            updateForm.ShowDialog();
        }

        private void 帮助文档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strDataFile = Application.StartupPath + "\\help\\宇星科技空气质量自动在线监测系统使用手册.doc";
            if (!File.Exists(strDataFile))
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                MessageBox.Show("错误！指定路径下不存在目标文件！", "AQMS", messButton);
                return;
            }
            System.Diagnostics.Process.Start(strDataFile);
            //ShellExecute(this.Handle, "open", strDataFile, null, null, (int)ShowWindowCommands.SW_SHOWNORMAL);
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitToolTips();
        }

        private void 显示主界面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void 最小化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (AppGloble.m_User.UserGroup == "" || AppGloble.m_User.UserGroup == "guest")
            //{
            //    DialogResult dr1 = MessageBox.Show("未登录或用户权限不够！", "AQMS", MessageBoxButtons.OK);
            //    return;
            //}
            DialogResult dr = MessageBox.Show("确定要退出空气质量监测系统吗?", "AQMS", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                // System.Environment.Exit(0);
                Application.Exit();
            }
        }

        public void ChangeInfomation(string userGroup)
        {
            if (userGroup == "")
            {
                this.barStaticItem1.Caption = "登录状态：未登录";
                this.高级设置ToolStripMenuItem.Visible = false;
                this.调试工具ToolStripMenuItem.Visible = false;
            }
            else if (userGroup == "guest")
            {
                this.barStaticItem1.Caption = "登录状态：guest已登录";
                this.高级设置ToolStripMenuItem.Visible = false;
                this.调试工具ToolStripMenuItem.Visible = false;
            }
            else if (userGroup == "操作员")
            {
                this.barStaticItem1.Caption = "登录状态：操作员已登录";
                this.高级设置ToolStripMenuItem.Visible = false;
                this.调试工具ToolStripMenuItem.Visible = false;
            }
            else if (userGroup == "管理员")
            {
                this.barStaticItem1.Caption = "登录状态：管理员已登录";
                this.高级设置ToolStripMenuItem.Visible = true;
                this.调试工具ToolStripMenuItem.Visible = true;
            }
            else if (userGroup == "系统管理员")
            {
                this.barStaticItem1.Caption = "登录状态：系统管理员已登录";
                this.高级设置ToolStripMenuItem.Visible = true;
                this.调试工具ToolStripMenuItem.Visible = true;
            }
        }
    }
}
