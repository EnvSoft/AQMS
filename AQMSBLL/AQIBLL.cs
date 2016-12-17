using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQMSBLL
{
    public class AQIBLL
    {
        public AQIBLL()
        {
            IAQI.Add(0);
            IAQI.Add(50);
            IAQI.Add(100);
            IAQI.Add(150);
            IAQI.Add(200);
            IAQI.Add(300);
            IAQI.Add(400);
            IAQI.Add(500);

            SO2_AQI24.Add(0);
            SO2_AQI24.Add(50);
            SO2_AQI24.Add(150);
            SO2_AQI24.Add(475);
            SO2_AQI24.Add(800);
            SO2_AQI24.Add(1600);
            SO2_AQI24.Add(2100);
            SO2_AQI24.Add(2620);

            SO2_AQI1.Add(0);
            SO2_AQI1.Add(150);
            SO2_AQI1.Add(500);
            SO2_AQI1.Add(650);
            SO2_AQI1.Add(800);

            NO2_AQI24.Add(0);
            NO2_AQI24.Add(40);
            NO2_AQI24.Add(80);
            NO2_AQI24.Add(180);
            NO2_AQI24.Add(280);
            NO2_AQI24.Add(565);
            NO2_AQI24.Add(750);
            NO2_AQI24.Add(940);

            NO2_AQI1.Add(0);
            NO2_AQI1.Add(100);
            NO2_AQI1.Add(200);
            NO2_AQI1.Add(700);
            NO2_AQI1.Add(1200);
            NO2_AQI1.Add(2340);
            NO2_AQI1.Add(3090);
            NO2_AQI1.Add(3840);

            PM10_AQI24.Add(0);
            PM10_AQI24.Add(50);
            PM10_AQI24.Add(150);
            PM10_AQI24.Add(250);
            PM10_AQI24.Add(350);
            PM10_AQI24.Add(420);
            PM10_AQI24.Add(500);
            PM10_AQI24.Add(600);

            CO_AQI24.Add(0); //mg/m3
            CO_AQI24.Add(2);
            CO_AQI24.Add(4);
            CO_AQI24.Add(14);
            CO_AQI24.Add(24);
            CO_AQI24.Add(36);
            CO_AQI24.Add(48);
            CO_AQI24.Add(60);

            CO_AQI1.Add(0);
            CO_AQI1.Add(5);
            CO_AQI1.Add(10);
            CO_AQI1.Add(35);
            CO_AQI1.Add(60);
            CO_AQI1.Add(90);
            CO_AQI1.Add(120);
            CO_AQI1.Add(150);

            O3_AQI1.Add(0);
            O3_AQI1.Add(160);
            O3_AQI1.Add(200);
            O3_AQI1.Add(300);
            O3_AQI1.Add(400);
            O3_AQI1.Add(800);
            O3_AQI1.Add(1000);
            O3_AQI1.Add(1200);

            O3_AQI8.Add(0);
            O3_AQI8.Add(100);
            O3_AQI8.Add(160);
            O3_AQI8.Add(215);
            O3_AQI8.Add(265);
            O3_AQI8.Add(800);

            PM25_AQI24.Add(0);
            PM25_AQI24.Add(35);
            PM25_AQI24.Add(75);
            PM25_AQI24.Add(115);
            PM25_AQI24.Add(150);
            PM25_AQI24.Add(250);
            PM25_AQI24.Add(350);
            PM25_AQI24.Add(500);
        }

        private int GetIAQI(List<int> AQIType, double value)
        {
            int IAQIValue = 0;
            double fIAQI = 0;
            int IAQIIndex = 0;
            double minValue = 0, maxValue = 0;
            double minIAQI = 0, maxIAQI = 0;

            if (value <= 0)
            {
                return 0;
            }

            for (int i = 0; i < AQIType.Count; i++)
            {
                if (AQIType[i] > value)
                {
                    maxValue = AQIType[i];
                    minValue = AQIType[i - 1];
                    break;
                }
                IAQIIndex++;
            }

            if (maxValue == 0)
            {
                return 500;
            }

            maxIAQI = IAQI[IAQIIndex];
            minIAQI = IAQI[IAQIIndex - 1];

            fIAQI = (maxIAQI - minIAQI) / (maxValue - minValue) * (value - minValue) + minIAQI;
            IAQIValue = (int)(fIAQI);
            return IAQIValue;
        }

        public int GetRealIAQI(string deviceName, double value)
        {
            if (value <= 0)
            {
                return 0;
            }

            if (deviceName == "SO2")
            {
                return GetIAQI(SO2_AQI1, value);
            }
            else if (deviceName == "NO2")
            {
                return GetIAQI(NO2_AQI1, value);
            }
            else if (deviceName == "CO")
            {
                return GetIAQI(CO_AQI1, value);
            }
            else if (deviceName == "O3")
            {
                return GetIAQI(O3_AQI1, value);
            }
            else if (deviceName == "PM10")
            {
                return GetIAQI(PM10_AQI24, value);
            }
            else if (deviceName == "PM2.5")
            {
                return GetIAQI(PM25_AQI24, value);
            }
            else
            {
                return 0;
            }
        }

        public int GetDayIAQI(string deviceName, double value)
        {
            if (value <= 0)
            {
                return 0;
            }

            if (deviceName == "SO2")
            {
                return GetIAQI(SO2_AQI24, value);
            }
            else if (deviceName == "NO2")
            {
                return GetIAQI(NO2_AQI24, value);
            }
            else if (deviceName == "CO")
            {
                return GetIAQI(CO_AQI24, value);
            }
            else if (deviceName == "O3")
            {
                return GetIAQI(O3_AQI8, value);
            }
            else if (deviceName == "PM10")
            {
                return GetIAQI(PM10_AQI24, value);
            }
            else if (deviceName == "PM2.5")
            {
                return GetIAQI(PM25_AQI24, value);
            }
            else
            {
                return 0;
            }
        }

        public int GetAQI(List<int> IAQIValues)
        {
            int AQIValue = 0;
            foreach (int item in IAQIValues)
            {
                if (item > AQIValue)
                {
                    AQIValue = item;
                }
            }
            return AQIValue;
        }

        public string GetFirstPollutant(int AQIValue, List<int> IAQIValues)
        {
            string firstPollutant = "";
            if (AQIValue <= 50)
            {
                return "";
            }

            return firstPollutant;
        }

        public string GetAQILevel(int AQIValue)
        {
            string AQILevel = "";
            if (AQIValue <= 50)
            {
                AQILevel = "一级";
            }
            if (AQIValue > 50 && AQIValue <= 100)
            {
                AQILevel = "二级";
            }
            if (AQIValue > 100 && AQIValue <= 150)
            {
                AQILevel = "三级";
            }
            if (AQIValue > 150 && AQIValue <= 200)
            {
                AQILevel = "四级";
            }
            if (AQIValue > 200 && AQIValue <= 300)
            {
                AQILevel = "五级";
            }
            if (AQIValue > 300)
            {
                AQILevel = "六级";
            }
            return AQILevel;
        }

        public string GetAQIClass(int AQIValue)
        {
            string AQIClass = "";
            if (AQIValue <= 50)
            {
                AQIClass = "优";
            }
            if (AQIValue > 50 && AQIValue <= 100)
            {
                AQIClass = "良";
            }
            if (AQIValue > 100 && AQIValue <= 150)
            {
                AQIClass = "轻度污染";
            }
            if (AQIValue > 150 && AQIValue <= 200)
            {
                AQIClass = "中度污染";
            }
            if (AQIValue > 200 && AQIValue <= 300)
            {
                AQIClass = "重度污染";
            }
            if (AQIValue > 300)
            {
                AQIClass = "严重污染";
            }
            return AQIClass;
        }

        public string GetAQIColor(int AQIValue)
        {
            string AQIColor = "";
            if (AQIValue <= 50)
            {
                AQIColor = "绿色";
            }
            if (AQIValue > 50 && AQIValue <= 100)
            {
                AQIColor = "黄色";
            }
            if (AQIValue > 100 && AQIValue <= 150)
            {
                AQIColor = "橙色";
            }
            if (AQIValue > 150 && AQIValue <= 200)
            {
                AQIColor = "红色";
            }
            if (AQIValue > 200 && AQIValue <= 300)
            {
                AQIColor = "紫色";
            }
            if (AQIValue > 300)
            {
                AQIColor = "褐红色";
            }
            return AQIColor;
        }

        private List<int> IAQI = new List<int>();
        private List<int> SO2_AQI24 = new List<int>();
        private List<int> SO2_AQI1 = new List<int>();
        private List<int> NO2_AQI24 = new List<int>();
        private List<int> NO2_AQI1 = new List<int>();
        private List<int> PM10_AQI24 = new List<int>();
        private List<int> CO_AQI24 = new List<int>();
        private List<int> CO_AQI1 = new List<int>();
        private List<int> O3_AQI1 = new List<int>();
        private List<int> O3_AQI8 = new List<int>();
        private List<int> PM25_AQI24 = new List<int>();
    }
}
