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
using AQMSUC;

namespace AQMSUI
{
    public partial class UCDocmentManager : UserControl
    {
        public UCDocmentManager()
        {
            InitializeComponent();
            this.widgetView1.QueryControl += widgetView1_QueryControl;
        }

        public void SetLayoutMode(LayoutMode newMode)
        {
            this.widgetView1.LayoutMode = newMode;
        }

        /// <summary>
        /// 当前视图添加新行
        /// </summary>
        /// <param name="newRow">RowDefinition类型，新增的一行</param>
        public void AddRow(RowDefinition newRow)
        {
            this.widgetView1.Rows.Add(newRow);
        }

        /// <summary>
        /// 当前视图添加多行
        /// </summary>
        /// <param name="newRows">RowDefinition类型的集合，新增的多行</param>
        public void AddRows(List<RowDefinition> newRows)
        {
            this.widgetView1.Rows.AddRange(newRows);
        }

        /// <summary>
        /// 当前视图添加新列
        /// </summary>
        /// <param name="newColumn">ColumnDefinition类型，新增的一列</param>
        public void AddColumn(ColumnDefinition newColumn)
        {
            this.widgetView1.Columns.Add(newColumn);
        }

        /// <summary>
        /// 当前视图添加多列
        /// </summary>
        /// <param name="newColumns">ColumnDefinition类型的集合，新增的多列<</param>
        public void AddColumns(List<ColumnDefinition> newColumns)
        {
            this.widgetView1.Columns.AddRange(newColumns);
        }

        public void AddStackGroups(List<StackGroup> stackGroups)
        {
            this.widgetView1.StackGroups.AddRange(stackGroups);
        }

        public void AddStackGroup(StackGroup stackgroup)
        {
            this.widgetView1.StackGroups.Add(stackgroup);
        }

        public void AddDocuments(List<Document> documents)
        {
            this.widgetView1.Documents.AddRange(documents);
        }

        public void AddDocument(Document document)
        {
            this.widgetView1.Documents.Add(document);
        }

        private void widgetView1_QueryControl(object sender, QueryControlEventArgs e)
        {
            if (e.Document.Caption == "系统状态")
            {
                HomeInfo docHomeInfo = new HomeInfo();
                e.Control = docHomeInfo;
            }
            else if (e.Document.Caption == "系统菜单")
            {
                HomeMenu docHomeMenu = new HomeMenu();               
                e.Control = docHomeMenu;                
            }
            else if (e.Document.Caption == "主页曲线")
            {
                HomeChart docHomeChart = new HomeChart();
                e.Control = docHomeChart;
            }
            else if (e.Document.Caption == "主页AQI")
            {
                HomeAQI docHomeAQI = new HomeAQI();
                e.Control = docHomeAQI;
            }
            else if (e.Document.Caption == "数据显示")
            {
                ItemsDocmentManager docAirItem = new ItemsDocmentManager();
                e.Control = docAirItem;
            }
        }
    }
}
