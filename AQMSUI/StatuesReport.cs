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
    public partial class StatuesReport : Form
    {
        public StatuesReport()
        {
            InitializeComponent();
        }

        private static StatuesReport SRForm;

        public static StatuesReport GetForm()
        {
            if (SRForm == null || SRForm.IsDisposed)
            {
                SRForm = new StatuesReport();
            }
            return SRForm;
        }
    }
}
