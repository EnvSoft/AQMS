using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AQMSModel;

namespace AQMSUC
{
    public partial class AirItemDocment : UserControl
    {
        public AirItemDocment()
        {
            InitializeComponent();
        }

        private void label_Unit_Click(object sender, EventArgs e)
        {
            if (airItem.ItemType <= 2)
            {

            }
        }

        private AirItem airItem { get; set; }
    }
}
