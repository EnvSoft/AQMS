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
    public partial class TimerControl : Form
    {
        public TimerControl()
        {
            InitializeComponent();
        }

        private static TimerControl TCForm;

        public static TimerControl GetForm()
        {
            if (TCForm == null || TCForm.IsDisposed)
            {
                TCForm = new TimerControl();
            }
            return TCForm;
        }
    }
}
