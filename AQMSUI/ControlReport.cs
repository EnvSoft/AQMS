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
    public partial class ControlReport : Form
    {
        public ControlReport()
        {
            InitializeComponent();
        }

        private static ControlReport CRForm;

        public static ControlReport GetForm()
        {
            if (CRForm == null ||　CRForm.IsDisposed)
            {
                CRForm = new ControlReport();
            }
            return CRForm;
        }
    }
}
