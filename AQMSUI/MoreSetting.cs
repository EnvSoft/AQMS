using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AQMSUI
{
    public partial class MoreSetting : Form
    {
        public MoreSetting()
        {
            InitializeComponent();
        }

        private static MoreSetting MSForm;

        public static MoreSetting GetForm()
        {
            if (MSForm == null || MSForm.IsDisposed)
            {
                MSForm = new MoreSetting();
            }
            return MSForm;
        }

        private void button2_Click(object sender, EventArgs e)
        { // 保存

        }

        private void button3_Click(object sender, EventArgs e)
        { // 取消
            this.Close();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

            }
        }
    }
}
