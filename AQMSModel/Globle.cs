using System.Collections.Generic;
using System.IO.Ports;

namespace AQMSModel
{
    public class Globle
    {
        public static List<AirDevice> m_UsedDevices = new List<AirDevice>();

        public static List<AirItem> m_AirItems = new List<AirItem>();

        public static AirStation m_AirStation = new AirStation();

        public static UserData m_User = new UserData();

        public static List<SerialPort> m_ComPort = new List<SerialPort>();

        public static List<AirDevice> m_AirDevices = new List<AirDevice>();

        public static List<AirDevice> m_AllDevices = new List<AirDevice>();
    }
}
