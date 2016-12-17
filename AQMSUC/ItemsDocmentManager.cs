using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Docking2010.Views.Widget;
using AQMSModel;
using AQMSBLL;

namespace AQMSUC
{
    public partial class ItemsDocmentManager : UserControl
    {
        public ItemsDocmentManager()
        {
            InitializeComponent();
            InitAirItemsDocment();
            this.widgetView1.QueryControl += widgetView1_QueryControl;
        }

        public void InitAirItemsDocment()
        {            
            List<Document> mDocments = new List<Document>();
            if (Globle.m_AirDevices != null)
            {
                int count = 0;
                foreach (AirDevice airDev in Globle.m_AirDevices)
                {
                    foreach (AirItem airItem in airDev.Items)
                    {
                        Document airItemDocment = new Document();
                        airItemDocment.Caption = airItem.ItemChName;
                        airItemDocment.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.False;
                        airItemDocment.Properties.AllowMaximize = DevExpress.Utils.DefaultBoolean.False;
                        this.widgetView1.Documents.Add(airItemDocment);
                        int stackGroupIndex = count % this.widgetView1.StackGroups.Count;
                        switch (stackGroupIndex)
                        {
                            case 0:
                                this.stackGroup1.Items.Add(airItemDocment);
                                break;
                            case 1:
                                this.stackGroup2.Items.Add(airItemDocment);
                                break;
                            case 2:
                                this.stackGroup3.Items.Add(airItemDocment);
                                break;
                            case 3:
                                this.stackGroup4.Items.Add(airItemDocment);
                                break;
                            case 4:
                                this.stackGroup5.Items.Add(airItemDocment);
                                break;
                            default:
                                break;
                        }
                        count++;
                    }                   
                }               
            }
        }

        private void widgetView1_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {
            if(e.Document.Caption == "风向")
            {
                WindDocment airWind = new WindDocment();
                e.Control = airWind;
            }
            else
            {
                AirItemDocment airItem = new AirItemDocment();
                e.Control = airItem;
            }         
        }
    }
}
