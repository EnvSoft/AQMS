using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AQMSBLL;
using AQMSModel;

namespace AQMSUI
{
    public partial class HomeMenu : UserControl
    {      
        public HomeMenu()
        {
            InitializeComponent();          
        }

        private void tileControl1_SizeChanged(object sender, EventArgs e)
        {
            this.tileControl1.ItemSize = (int)((this.tileControl1.Size.Width - 60) / 3.0 * 1.36);
        }

        private void tileItem10_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        { // 用户登录
            UserLogin userLogin = new UserLogin();
            userLogin.ShowDialog();
        }

        private void tileItem1_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        { // 系统参数设置
            if (Globle.m_User.UserGroup == "" || Globle.m_User.UserGroup == "guest")
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                DialogResult dr = MessageBox.Show("未登录或用户权限不够！", "AQMS", messButton);
                return;
            }
            SysSetting sysSetForm = SysSetting.GetForm();
            sysSetForm.Show();
        }

        private void tileItem2_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        { // 监测设备配置
            if (Globle.m_User.UserGroup == "" || Globle.m_User.UserGroup == "guest")
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                DialogResult dr = MessageBox.Show("未登录或用户权限不够！", "AQMS", messButton);
                return;
            }
            DeviceSetting devSetForm = DeviceSetting.GetForm();
            devSetForm.Show();
        }

        private void tileItem3_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        { // 联网传输配置
            if (Globle.m_User.UserGroup == "" || Globle.m_User.UserGroup == "guest")
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                DialogResult dr = MessageBox.Show("未登录或用户权限不够！", "AQMS", messButton);
                return;
            }
            NetSetting netSetForm = NetSetting.GetForm();
            netSetForm.Show();
        }

        private void tileItem4_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        { // 历史数据查询
            if (Globle.m_User.UserGroup == "")
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                DialogResult dr = MessageBox.Show("未登录或用户权限不够！", "AQMS", messButton);
                return;
            }
            DataReport dataReport = DataReport.GetForm();
            dataReport.Show();
        }

        private void tileItem6_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        { // AQI报表查询
            if (Globle.m_User.UserGroup == "")
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                DialogResult dr = MessageBox.Show("未登录或用户权限不够！", "AQMS", messButton);
                return;
            }
            AQIReport AQIRealReport = AQIReport.GetForm(1);
            AQIRealReport.Show();
        }

        private void tileItem7_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        { // 现场质控任务
            if (Globle.m_User.UserGroup == "" || Globle.m_User.UserGroup == "guest")
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                DialogResult dr = MessageBox.Show("未登录或用户权限不够！", "AQMS", messButton);
                return;
            }
            LocalControl localControl = LocalControl.GetForm();
            localControl.Show();
        }

        private void tileItem8_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        { // 定时质控任务
            if (Globle.m_User.UserGroup == "" || Globle.m_User.UserGroup == "guest")
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                DialogResult dr = MessageBox.Show("未登录或用户权限不够！", "AQMS", messButton);
                return;
            }
            TimerControl timerControl = TimerControl.GetForm();
            timerControl.Show();
        }

        private void tileItem9_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        { // 质控预标识
            if (Globle.m_User.UserGroup == "" || Globle.m_User.UserGroup == "guest")
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                DialogResult dr = MessageBox.Show("未登录或用户权限不够！", "AQMS", messButton);
                return;
            }
            ControlStatues controlStatues = ControlStatues.GetForm();
            controlStatues.Show();
        }

        private void tileItem12_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        { // 质控任务查询
            if (Globle.m_User.UserGroup == "" || Globle.m_User.UserGroup == "guest")
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                DialogResult dr = MessageBox.Show("未登录或用户权限不够！", "AQMS", messButton);
                return;
            }
            ControlReport controlReport = ControlReport.GetForm();
            controlReport.Show();
        }

        private void tileItem5_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        { // 状态信息查询
            if (Globle.m_User.UserGroup == "")
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                DialogResult dr = MessageBox.Show("未登录或用户权限不够！", "AQMS", messButton);
                return;
            }
            StatuesReport statuesReprot = StatuesReport.GetForm();
            statuesReprot.Show();
        }

        private void tileItem11_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        { // 检查更新
            if (Globle.m_User.UserGroup == "" || Globle.m_User.UserGroup == "guest")
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                DialogResult dr = MessageBox.Show("未登录或用户权限不够！", "AQMS", messButton);
                return;
            }
            UpdateForm updateForm = new UpdateForm();
            updateForm.ShowDialog();
        }
    }
}
