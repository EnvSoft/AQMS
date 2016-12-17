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
using AQMSModel;

namespace AQMSUC
{
    public partial class HomeInfo : UserControl
    {
        public HomeInfo()
        {
            InitializeComponent();
            xIndex = this.Size.Width / 100.0;
            yIndex = this.Size.Height / 100.0;
        }

        private void HomeInfo_Paint(object sender, PaintEventArgs e)
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
            DateTime nowDateTime = DateTime.Now;
            string nowDate = nowDateTime.ToString("yyyy-MM-dd");
            string nowTime = nowDateTime.ToString("HH:mm:ss");
            string nowWeek = nowDateTime.ToString("dddd");

            StringFormat mStringFormat1 = new StringFormat();
            mStringFormat1.Alignment = StringAlignment.Center;
            mStringFormat1.LineAlignment = StringAlignment.Center;
            StringFormat mStringFormat2 = new StringFormat();
            mStringFormat2.Alignment = StringAlignment.Near;
            mStringFormat2.LineAlignment = StringAlignment.Center;
            StringFormat mStringFormat3 = new StringFormat();
            mStringFormat3.Alignment = StringAlignment.Far;
            mStringFormat3.LineAlignment = StringAlignment.Center;
            RectangleF timeRect = new RectangleF((int)(xIndex * 10), (int)(yIndex * 10), (int)(xIndex * 50), (int)(yIndex * 40));
            RectangleF dateRect = new RectangleF((int)(xIndex * 65), (int)(yIndex * 10), (int)(xIndex * 35), (int)(yIndex * 20));
            RectangleF weekRect = new RectangleF((int)(xIndex * 65), (int)(yIndex * 30), (int)(xIndex * 35), (int)(yIndex * 20));
            RectangleF stationRect = new RectangleF((int)(xIndex * 15), (int)(yIndex * 55), (int)(xIndex * 85), (int)(yIndex * 20));
            RectangleF numRect = new RectangleF((int)(xIndex * 15), (int)(yIndex * 75), (int)(xIndex * 85), (int)(yIndex * 20));
            g.DrawString(nowTime, new Font("宋体", 40, FontStyle.Bold), new SolidBrush(Color.Black), timeRect, mStringFormat2);
            g.DrawString(nowDate, new Font("宋体", 20, FontStyle.Bold), new SolidBrush(Color.Black), dateRect, mStringFormat2);
            g.DrawString(nowWeek, new Font("宋体", 20, FontStyle.Bold), new SolidBrush(Color.Black), weekRect, mStringFormat2);
            g.DrawString("站点名称：" + Globle.m_AirStation.AirStationName, new Font("宋体", 14, FontStyle.Bold), new SolidBrush(Color.Black), stationRect, mStringFormat2);
            g.DrawString("站点编号：" + Globle.m_AirStation.AirStationNum, new Font("宋体", 14), new SolidBrush(Color.Black), numRect, mStringFormat2);
        }

        private void HomeInfo_SizeChanged(object sender, EventArgs e)
        {
            xIndex = this.Size.Width / 100.0;
            yIndex = this.Size.Height / 100.0;
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

        private double xIndex { get; set; }
        private double yIndex { get; set; }

        private void timer_GDIShow_Tick(object sender, EventArgs e)
        {
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
    }
}
