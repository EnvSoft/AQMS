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
    public partial class LocalControl : Form
    {
        public LocalControl()
        {
            InitializeComponent();
        }

        private static LocalControl LCForm;

        public static LocalControl GetForm()
        {
            if (LCForm == null || LCForm.IsDisposed)
            {
                LCForm = new LocalControl();
            }
            return LCForm;
        }
    }
}
