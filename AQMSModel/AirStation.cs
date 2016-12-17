using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQMSModel
{
    [Serializable]
    public class AirStation
    {
        public AirStation()
        {

        }
        public AirStation(string name, string num)
        {
            airStationName = name;
            airStationNum = num;
        }
        private string airStationName;
        private string airStationNum;
        private string dBServer;
        private string dBUser;
        private string dBPass;
        private string dBName;
        private string dBPath;
        private bool isAutoStart;

        /// <summary>
        /// 站点名称
        /// </summary>
        public string AirStationName
        {
            get { return airStationName; }
            set { airStationName = value; }
        }
        /// <summary>
        /// 站点编号
        /// </summary>
        public string AirStationNum
        {
            get { return airStationNum; }
            set { airStationNum = value; }
        }
        /// <summary>
        /// 数据库服务器
        /// </summary>
        public string DBServer
        {
            get { return dBServer; }
            set { dBServer = value; }
        }
        /// <summary>
        /// 数据库用户名
        /// </summary>
        public string DBUser
        {
            get { return dBUser; }
            set { dBUser = value; }
        }
        /// <summary>
        /// 数据库密码
        /// </summary>
        public string DBPass
        {
            get { return dBPass; }
            set { dBPass = value; }
        }
        /// <summary>
        /// 数据库名称
        /// </summary>
        public string DBName
        {
            get { return dBName; }
            set { dBName = value; }
        }
        /// <summary>
        /// 数据库文件路径
        /// </summary>
        public string DBPath
        {
            get { return dBPath; }
            set { dBPath = value; }
        }
        /// <summary>
        /// 是否开机自启动
        /// </summary>
        public bool IsAutoStart
        {
            get { return isAutoStart; }
            set { isAutoStart = value; }
        }

        
    }
}
