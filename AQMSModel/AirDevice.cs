using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQMSModel
{
    [Serializable]
    public class AirDevice
    {        
        private string devName;        
        private string devChName;
        private string devType;
        private string devMode;
        private bool devState;       
        private bool devAlarm;
        private int sampleTime;     
        private int dataValidTime;      
        private ComPort devCom = new ComPort();
        private List<AirItem> items = new List<AirItem>();

        /// <summary>
        /// 设备英文缩写名称
        /// </summary>
        public string DevName
        {
            get
            {
                return devName;
            }

            set
            {
                devName = value;
            }
        }
        /// <summary>
        /// 设备中文名称
        /// </summary>
        public string DevChName
        {
            get
            {
                return devChName;
            }

            set
            {
                devChName = value;
            }
        }
        /// <summary>
        /// 设备类型
        /// </summary>
        public string DevType
        {
            get
            {
                return devType;
            }

            set
            {
                devType = value;
            }
        }
        /// <summary>
        /// 设备厂家型号
        /// </summary>
        public string DevMode
        {
            get
            {
                return devMode;
            }

            set
            {
                devMode = value;
            }
        }
        /// <summary>
        /// 是否采集设备状态信息
        /// </summary>
        public bool DevState
        {
            get { return devState; }
            set { devState = value; }
        }
        /// <summary>
        /// 是否采集设备报警信息
        /// </summary>
        public bool DevAlarm
        {
            get { return devAlarm; }
            set { devAlarm = value; }
        }
        /// <summary>
        /// 数据采集频率，单位s
        /// </summary>
        public int SampleTime
        {
            get { return sampleTime; }
            set { sampleTime = value; }
        }
        /// <summary>
        /// 数据有效周期，单位s
        /// </summary>
        public int DataValidTime
        {
            get { return dataValidTime; }
            set { dataValidTime = value; }
        }
        /// <summary>
        /// 设备串口
        /// </summary>
        public ComPort DevCom
        {
            get
            {
                return devCom;
            }

            set
            {
                devCom = value;
            }
        }
        /// <summary>
        /// 设备的监测因子List
        /// </summary>
        public List<AirItem> Items
        {
            get
            {
                return items;
            }

            set
            {
                items = value;
            }
        }

        

        public bool UpdateDataValue()
        {
            return true;
        }

        public bool SetValue()
        {
            return true;
        }

        
    }

    [Serializable]
    public class ComPort
    {
        private string port;
        private string baudRate;
        private string parityBit;
        private string dataBit;
        private string stopBit;     

        /// <summary>
        /// 设备端口号
        /// </summary>
        public string Port
        {
            get
            {
                return port;
            }

            set
            {
                port = value;
            }
        }
        /// <summary>
        /// 波特率
        /// </summary>
        public string BaudRate
        {
            get
            {
                return baudRate;
            }

            set
            {
                baudRate = value;
            }
        }
        /// <summary>
        /// 校验位
        /// </summary>
        public string ParityBit
        {
            get
            {
                return parityBit;
            }

            set
            {
                parityBit = value;
            }
        }
        /// <summary>
        /// 数据位
        /// </summary>
        public string DataBit
        {
            get
            {
                return dataBit;
            }

            set
            {
                dataBit = value;
            }
        }
        /// <summary>
        /// 停止位
        /// </summary>
        public string StopBit
        {
            get
            {
                return stopBit;
            }

            set
            {
                stopBit = value;
            }
        }

        
    }

    [Serializable]
    public class AirItem
    {
        private string itemChName;
        private string itemName;
        private int itemType;
        private string dataName;
        private int intUnit;
        private int rangLow;
        private int rangHigh;
        private int alarmLow;
        private int alarmHigh;
        private string devUnit; 
        private string dBUnit;
        private string showUnit;
        private string showValue;
        private bool hasAQI;
        private double dataValue;
        private int dataStatues;
        private List<string> unitList;       

        /// <summary>
        /// 监测因子中文名称
        /// </summary>
        public string ItemChName
        {
            get
            {
                return itemChName;
            }

            set
            {
                itemChName = value;
            }
        }
        /// <summary>
        /// 监测因子英文缩写名称
        /// </summary>
        public string ItemName
        {
            get
            {
                return itemName;
            }

            set
            {
                itemName = value;
            }
        }
        /// <summary>
        /// 因子类型：1、气态污染物；2、颗粒物；3、气象参数；4、温室气体；5、刺激性气体；6、站房环境；7、校准仪；8、其他
        /// </summary>
        public int ItemType
        {
            get
            {
                return itemType;
            }

            set
            {
                itemType = value;
            }
        }
        /// <summary>
        /// 监测因子数据库中字段名称
        /// </summary>
        public string DataName
        {
            get
            {
                return dataName;
            }

            set
            {
                dataName = value;
            }
        }
        /// <summary>
        /// 监测因子单位编号
        /// 气体：0（ug/m3），1(ppb)，2(mg/m3)，3(ppm)，4(默认)
        /// 颗粒物：0（ug/m3），1（mg/m3），2（默认）
        /// 气象参数：固定单位
        /// </summary>
        public int IntUnit
        {
            get
            {
                return intUnit;
            }

            set
            {
                intUnit = value;
            }
        }
        /// <summary>
        /// 监测因子量程下限
        /// </summary>
        public int RangLow
        {
            get { return rangLow; }
            set { rangLow = value; }
        }
        /// <summary>
        /// 监测因子量程上限
        /// </summary>
        public int RangHigh
        {
            get { return rangHigh; }
            set { rangHigh = value; }
        }
        /// <summary>
        /// 监测因子报警下限
        /// </summary>
        public int AlarmLow
        {
            get { return alarmLow; }
            set { alarmLow = value; }
        }
        /// <summary>
        /// 监测因子报警上限
        /// </summary>
        public int AlarmHigh
        {
            get { return alarmHigh; }
            set { alarmHigh = value; }
        }
        /// <summary>
        /// 监测因子设备输出单位
        /// </summary>
        public string DevUnit
        {
            get { return devUnit; }
            set { devUnit = value; }
        }
        /// <summary>
        /// 监测因子入库单位
        /// </summary>
        public string DBUnit
        {
            get { return dBUnit; }
            set { dBUnit = value; }
        }
        /// <summary>
        /// 监测因子主界面显示单位
        /// </summary>
        public string ShowUnit
        {
            get
            {
                return showUnit;
            }

            set
            {
                showUnit = value;
            }
        }
        /// <summary>
        /// 监测因子主界面显示数值
        /// </summary>
        public string ShowValue
        {
            get
            {
                return showValue;
            }

            set
            {
                showValue = value;
            }
        }
        /// <summary>
        /// 监测因子是否统计AQI
        /// </summary>
        public bool HasAQI
        {
            get
            {
                return hasAQI;
            }

            set
            {
                hasAQI = value;
            }
        }
        /// <summary>
        /// 监测因子入库数值，单位（ug/m3）
        /// </summary>
        public double DataValue
        {
            get
            {
                return dataValue;
            }

            set
            {
                dataValue = value;
            }
        }
        /// <summary>
        /// 数据状态：0(仪器正常)，1(串口错误)，2(连接错误)，3(零点校准)，
        /// 4(跨度校准)，5(零点检查)，6(跨度检查)，7(数据异常), 
        /// 8(多点检查), 9(精密度检查), 10(示值误差检查), 11(维护)
        /// </summary>
        public int DataStatues
        {
            get
            {
                return dataStatues;
            }

            set
            {
                dataStatues = value;
            }
        }
        /// <summary>
        /// 监测因子的单位列表
        /// </summary>
        public List<string> UnitList
        {
            get { return unitList; }
            set { unitList = value; }
        }

        public void UpdateShowValue()
        {
            
        }
    }
}
