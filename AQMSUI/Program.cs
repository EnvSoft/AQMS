using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AQMSUI
{
    static class Program
    {
        public static System.Threading.Mutex mutex;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(DeviceSetting.GetForm());

            mutex = new System.Threading.Mutex(true, "CMING1001");
            if (mutex.WaitOne(0, false))
            {
                LoadForm mLoadForm = new LoadForm();
                mLoadForm.ShowDialog();
                if (mLoadForm.DialogResult == DialogResult.Cancel)
                {
                    SysSetting mSysSetForm = SysSetting.GetForm();
                    mSysSetForm.ShowDialog();
                }
                Application.Run(MainForm.GetForm());
            }
            else
            {
                MessageBox.Show("程序已经在运行！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Environment.Exit(0);
            }
        }
    }
}
