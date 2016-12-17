using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AQMSModel;
using AQMSBLL;

namespace AQMSUI
{
    public partial class UserLogin : Form
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        private void UserLogin_Load(object sender, EventArgs e)
        {
            this.comboBox_UserType.SelectedIndex = 1;
        }

        private void button_Login_MouseUp(object sender, MouseEventArgs e)
        {
            Globle.m_User.UserGroup = this.comboBox_UserType.SelectedItem.ToString();
            Globle.m_User.UserName = this.textBox_UserName.Text.Trim();
            Globle.m_User.UserPass = this.textBox_UserPass.Text;
            if (Globle.m_User.UserName == "" && Globle.m_User.UserPass != "")
            {
                DialogResult dr = MessageBox.Show("请输入用户名！", "AQMS", MessageBoxButtons.OK);
                return;
            }
            else if (Globle.m_User.UserName != "" && Globle.m_User.UserPass == "")
            {
                DialogResult dr = MessageBox.Show("请输入密码！", "AQMS", MessageBoxButtons.OK);
                return;
            }
            else if (Globle.m_User.UserName == "" && Globle.m_User.UserPass == "")
            {
                DialogResult dr = MessageBox.Show("请输入用户名和密码！", "AQMS", MessageBoxButtons.OK);
                return;
            }
            int nLogin = mLoginBLL.UserLogin(Globle.m_User);
            if (nLogin == 0)
            {
                DialogResult dr = MessageBox.Show("登录成功！", "AQMS", MessageBoxButtons.OK);
                mMainForm.ChangeInfomation(Globle.m_User.UserGroup);
                this.Close();
            }
            else if (nLogin == 1)
            {
                DialogResult dr = MessageBox.Show("登录失败！用户名或密码错误！", "错误", MessageBoxButtons.OK);
                return;
            }
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            Globle.m_User.UserGroup = "";
            DialogResult dr = MessageBox.Show("确定要注销当前用户吗？", "注销登录", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                mMainForm.ChangeInfomation(Globle.m_User.UserGroup);
            }            
            this.Close();
        }

        private MainForm mMainForm = MainForm.GetForm();
        private LoginBLL mLoginBLL = new LoginBLL();
    }
}
