using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using AQMSBLL;

namespace AQMSUC
{
    public partial class HomeAQI : UserControl
    {
        public HomeAQI()
        {
            InitializeComponent();
            xIndex = this.Size.Width / 100.0;
            yIndex = this.Size.Height / 100.0;
            GetAQIInfo();
        }

        private void HomeAQI_Paint(object sender, PaintEventArgs e)
        {
            Bitmap mBitmap = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
            //创建位图实例
            Graphics bitmapGraphics = Graphics.FromImage(mBitmap);
            bitmapGraphics.Clear(BackColor);
            bitmapGraphics.SmoothingMode = SmoothingMode.AntiAlias;
            PaintImage(bitmapGraphics);
            Graphics ucGrapgics = e.Graphics;//获取窗体画布
            ucGrapgics.DrawImage(mBitmap, 0, 0); //在窗体的画布中绘画出内存中的图像
            bitmapGraphics.Dispose();
            mBitmap.Dispose();
            ucGrapgics.Dispose();
        }

        private void PaintImage(Graphics g)
        {
            StringFormat mStringFormat1 = new StringFormat();
            mStringFormat1.Alignment = StringAlignment.Center;
            mStringFormat1.LineAlignment = StringAlignment.Center;
            StringFormat mStringFormat2 = new StringFormat();
            mStringFormat2.Alignment = StringAlignment.Near;
            mStringFormat2.LineAlignment = StringAlignment.Center;
            StringFormat mStringFormat3 = new StringFormat();
            mStringFormat3.Alignment = StringAlignment.Far;
            mStringFormat3.LineAlignment = StringAlignment.Center;
            RectangleF AQIValueRect = new RectangleF((int)(xIndex * 10), (int)(yIndex * 10), (int)(xIndex * 80), (int)(yIndex * 20));
            RectangleF firstPollutantRect = new RectangleF((int)(xIndex * 15), (int)(yIndex * 30), (int)(xIndex * 85), (int)(yIndex * 15));
            RectangleF AQILevelRect = new RectangleF((int)(xIndex * 15), (int)(yIndex * 45), (int)(xIndex * 85), (int)(yIndex * 15));
            RectangleF AQIClassRect = new RectangleF((int)(xIndex * 15), (int)(yIndex * 60), (int)(xIndex * 85), (int)(yIndex * 15));
            RectangleF AQIColorRect1 = new RectangleF((int)(xIndex * 15), (int)(yIndex * 75), (int)(xIndex * 30), (int)(yIndex * 15));
            RectangleF AQIColorRect2 = new RectangleF((int)(xIndex * 45), (int)(yIndex * 75), (int)(xIndex * 25), (int)(yIndex * 15));
            g.DrawString("实时AQI：" + AQIValue, new Font("宋体", 20, FontStyle.Bold), new SolidBrush(Color.Black), AQIValueRect, mStringFormat1);
            g.DrawString("首要污染物：" + firstPollutant, new Font("宋体", 14), new SolidBrush(Color.Black), firstPollutantRect, mStringFormat2);
            g.DrawString("AQI级别：" + AQILevel, new Font("宋体", 14), new SolidBrush(Color.Black), AQILevelRect, mStringFormat2);
            g.DrawString("AQI类别：" + AQIClass, new Font("宋体", 14), new SolidBrush(Color.Black), AQIClassRect, mStringFormat2);
            g.DrawString("AQI颜色：", new Font("宋体", 14), new SolidBrush(Color.Black), AQIColorRect1, mStringFormat2);
            if (AQIColor == "绿色")
            {
                g.FillRectangle(Brushes.Green, AQIColorRect2);
            }
            else if (AQIColor == "黄色")
            {
                g.FillRectangle(Brushes.Yellow, AQIColorRect2);
            }
            else if (AQIColor == "橙色")
            {
                g.FillRectangle(Brushes.Orange, AQIColorRect2);
            }
            else if (AQIColor == "红色")
            {
                g.FillRectangle(Brushes.Red, AQIColorRect2);
            }
            else if (AQIColor == "紫色")
            {
                g.FillRectangle(Brushes.Purple, AQIColorRect2);
            }
            else if (AQIColor == "褐红色")
            {
                g.FillRectangle(Brushes.Maroon, AQIColorRect2);
            }
            g.DrawString(AQIColor, new Font("宋体", 14), new SolidBrush(Color.Black), AQIColorRect2, mStringFormat1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetAQIInfo();
            Bitmap mBitmap = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
            //创建位图实例
            Graphics bitmapGraphics = Graphics.FromImage(mBitmap);
            bitmapGraphics.Clear(BackColor);
            bitmapGraphics.SmoothingMode = SmoothingMode.AntiAlias;
            PaintImage(bitmapGraphics);
            Graphics ucGrapgics = this.CreateGraphics();//获取窗体画布
            ucGrapgics.DrawImage(mBitmap, 0, 0); //在窗体的画布中绘画出内存中的图像
            bitmapGraphics.Dispose();
            mBitmap.Dispose();
            ucGrapgics.Dispose();
        }

        private void GetAQIInfo()
        {
            AQIDataBLL mAirAQIInfo = new AQIDataBLL();
            AQIValue = "123";
            firstPollutant = "PM2.5";
            AQILevel = "二级";
            AQIClass = "轻度污染";
            AQIColor = "褐红色";
        }

        private void HomeAQI_SizeChanged(object sender, EventArgs e)
        {
            xIndex = this.Size.Width / 100.0;
            yIndex = this.Size.Height / 100.0;
        }

        private double xIndex { get; set; }
        private double yIndex { get; set; }
        private string AQIValue { get; set; }
        private string firstPollutant { get; set; }
        private string AQILevel { get; set; }
        private string AQIClass { get; set; }
        private string AQIColor { get; set; }
    }
}
