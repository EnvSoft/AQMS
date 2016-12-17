using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AQMSBLL;
using AQMSModel;
using AQMSUC;

namespace AQMSUI
{
    public partial class DeviceSetting : Form
    {
        public DeviceSetting()
        {
            InitializeComponent();
        }

        private List<AirDevice> tempDevList = Globle.m_AirDevices;
        private ItemParams nowItemParams = new ItemParams();

        private static DeviceSetting DSForm;

        public static DeviceSetting GetForm()
        {
            if (DSForm == null || DSForm.IsDisposed)
            {
                DSForm = new DeviceSetting();
            }
            return DSForm;
        }

        private void DeviceSetting_Load(object sender, EventArgs e)
        {

            InitDeviceTree();
            if (this.treeView1.Nodes[0].Nodes.Count > 0)
            {
                this.treeView1.SelectedNode = this.treeView1.Nodes[0].Nodes[0].Nodes[0];
            }
        }

        private void button3_Click(object sender, EventArgs e)
        { // 恢复默认
            if (this.treeView1.SelectedNode.Text != "")
            {
                foreach (AirDevice item in Globle.m_AllDevices)
                {
                    if (item.DevChName == this.treeView1.SelectedNode.Text)
                    {
                        LoadDeviceInfo(item);
                        return;
                    }
                }
            }           
        }

        private void button1_Click(object sender, EventArgs e)
        { // 保存
            Globle.m_AirDevices = tempDevList;
        }

        private void button2_Click(object sender, EventArgs e)
        { // 取消
            this.Close();
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        { // 勾选设备
            SetEditState(e.Node.Checked);
        }

        /// <summary>
        /// 选择下一项之前，保存前一项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            foreach (AirDevice device in tempDevList)
            {
                if (device.DevChName == e.Node.Text)
                {
                    device.DevMode = this.comboBoxDevMode.Text;
                    device.DevCom.Port = this.comboBoxComPort.Text;
                    device.DevCom.BaudRate = this.comboBoxBaudRate.Text;
                    device.DevCom.ParityBit = this.comboBoxParityBit.Text;
                    device.DevCom.DataBit = this.comboBoxDataBit.Text;
                    device.DevCom.StopBit = this.comboBoxStopBit.Text;
                    device.DevState = this.checkBoxDevState.Checked;
                    device.DevAlarm = this.checkBoxDevAlarm.Checked;
                    device.SampleTime = Convert.ToInt32(this.textBoxSampleSpeed.Text);
                    device.DataValidTime = Convert.ToInt32(this.textBoxDataValidTime.Text);
                    int nIndex = 0;
                    foreach (AirItem item in device.Items)
                    {
                        AirItem tempItem = new AirItem();
                        ItemParams tempItemParams = this.tabControl1.Controls[nIndex].Controls[0] as ItemParams;
                        tempItem = tempItemParams.GetItemParams();
                        item.RangLow =   tempItem.RangLow;
                        item.RangHigh =  tempItem.RangHigh;
                        item.AlarmLow =  tempItem.AlarmLow;
                        item.AlarmHigh = tempItem.AlarmHigh;
                        item.DevUnit =   tempItem.DevUnit;
                        item.DBUnit =    tempItem.DBUnit;
                        item.ShowUnit =  tempItem.ShowUnit;
                        nIndex++;
                    }
                    return;
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        { // 选中设备
            foreach (AirDevice item in Globle.m_AirDevices)
            {
                if (item.DevChName == e.Node.Text)
                {
                    LoadDeviceInfo(item);
                    return;
                }
            }
        }

        private void InitDeviceTree()
        {
            this.treeView1.Nodes.Add("监测设备");
            foreach (AirDevice item in Globle.m_AllDevices)
            {                
                if (!this.treeView1.Nodes.ContainsKey(item.DevType))
                {
                    this.treeView1.Nodes["监测设备"].Nodes.Add(item.DevType);
                }
                this.treeView1.Nodes["监测设备"].Nodes[item.DevType].Nodes.Add(item.DevChName);
            }            
        }

        private void SetEditState(bool editState)
        {
            if (editState)
            {
                this.comboBoxDevMode.Enabled = true;
                this.checkBoxDevState.Enabled = true;
                this.checkBoxDevAlarm.Enabled = true;
                this.comboBoxComPort.Enabled = true;
                this.comboBoxBaudRate.Enabled = true;
                this.comboBoxParityBit.Enabled = true;
                this.comboBoxDataBit.Enabled = true;
                this.comboBoxStopBit.Enabled = true;
                this.textBoxSampleSpeed.Enabled = true;
                this.textBoxDataValidTime.Enabled = true;                
            }
            else
            {
                this.comboBoxDevMode.Enabled = false;
                this.checkBoxDevState.Enabled = false;
                this.checkBoxDevAlarm.Enabled = false;
                this.comboBoxComPort.Enabled = false;
                this.comboBoxBaudRate.Enabled = false;
                this.comboBoxParityBit.Enabled = false;
                this.comboBoxDataBit.Enabled = false;
                this.comboBoxStopBit.Enabled = false;
                this.textBoxSampleSpeed.Enabled = false;
                this.textBoxDataValidTime.Enabled = false;
            }
            nowItemParams.SetEditState(editState);
        }

        private void LoadDeviceInfo(AirDevice mAirDevice)
        {
            this.comboBoxDevMode.Text = mAirDevice.DevChName;
            this.checkBoxDevState.Checked = mAirDevice.DevState;
            this.checkBoxDevAlarm.Checked = mAirDevice.DevAlarm;
            this.textBoxSampleSpeed.Text = mAirDevice.SampleTime.ToString();
            this.textBoxDataValidTime.Text = mAirDevice.DataValidTime.ToString();
            this.comboBoxComPort.SelectedText = mAirDevice.DevCom.Port;
            this.comboBoxBaudRate.SelectedText = mAirDevice.DevCom.BaudRate;
            this.comboBoxParityBit.SelectedText = mAirDevice.DevCom.ParityBit;
            this.comboBoxDataBit.SelectedText = mAirDevice.DevCom.DataBit;
            this.comboBoxStopBit.SelectedText = mAirDevice.DevCom.StopBit;

            foreach (AirItem item in mAirDevice.Items)
            {
                TabPage mTabPage = new TabPage();
                mTabPage.Text = item.ItemName;
                ItemParams mItemParams = new ItemParams();
                mItemParams.InitItemParams(item);
                this.tabControl1.TabPages.Add(mTabPage);
                mTabPage.Controls.Add(mItemParams);
            }
            nowItemParams = this.tabControl1.TabPages[0].Controls[0] as ItemParams;
        }

        
    }
}
