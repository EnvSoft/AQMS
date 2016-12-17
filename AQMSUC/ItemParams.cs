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
    public partial class ItemParams : UserControl
    {
        public ItemParams()
        {
            InitializeComponent();
        }

        public void InitItemParams(AirItem mAirItem)
        {
            foreach (string item in mAirItem.UnitList)
            {
                this.comboBoxDevUnit.Items.Add(item);
                this.comboBoxDBUnit.Items.Add(item);
                this.comboBoxShowUnit.Items.Add(item);
            }
            this.textBoxRangeL.Text = mAirItem.RangLow.ToString();
            this.textBoxRangeH.Text = mAirItem.RangHigh.ToString();
            this.textBoxAlarmL.Text = mAirItem.AlarmLow.ToString();
            this.textBoxAlarmH.Text = mAirItem.AlarmHigh.ToString();
            this.comboBoxDevUnit.SelectedText = mAirItem.DevUnit;
            this.comboBoxDBUnit.SelectedText = mAirItem.DBUnit;
            this.comboBoxShowUnit.SelectedText = mAirItem.ShowUnit;
        }

        public AirItem GetItemParams()
        {
            AirItem mAirItem = new AirItem();
            mAirItem.RangLow = Convert.ToInt32(this.textBoxRangeL.Text);
            mAirItem.RangHigh = Convert.ToInt32(this.textBoxRangeH.Text);
            mAirItem.AlarmLow = Convert.ToInt32(this.textBoxAlarmL.Text);
            mAirItem.AlarmHigh = Convert.ToInt32(this.textBoxAlarmH.Text);
            mAirItem.DevUnit = this.comboBoxDevUnit.SelectedText;
            mAirItem.DBUnit = this.comboBoxDBUnit.SelectedText;
            mAirItem.ShowUnit = this.comboBoxShowUnit.SelectedText;
            return mAirItem;
        }

        public void SetEditState(bool editState)
        {
            if (editState)
            {
                this.textBoxRangeL.Enabled = true;
                this.textBoxRangeH.Enabled = true;
                this.textBoxAlarmL.Enabled = true;
                this.textBoxAlarmH.Enabled = true;
                this.comboBoxDevUnit.Enabled = true;
                this.comboBoxDBUnit.Enabled = true;
                this.comboBoxShowUnit.Enabled = true;
            }
            else
            {
                this.textBoxRangeL.Enabled = false;
                this.textBoxRangeH.Enabled = false;
                this.textBoxAlarmL.Enabled = false;
                this.textBoxAlarmH.Enabled = false;
                this.comboBoxDevUnit.Enabled = false;
                this.comboBoxDBUnit.Enabled = false;
                this.comboBoxShowUnit.Enabled = false;
            }
        }
    }
}
