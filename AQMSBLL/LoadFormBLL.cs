using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AQMSDAL;
using AQMSModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Win32;
using System.Xml;

namespace AQMSBLL
{
    public class LoadFormBLL
    {
        SqlOperation mSqlOperation = new SqlOperation();

        public bool InitAirStation()
        {
            string strDataPath = "..\\..\\data";
            if (!Directory.Exists(strDataPath))
            {
                Directory.CreateDirectory(strDataPath);
            }
            string strDataFile = strDataPath + "\\data1.bin";
            if (!File.Exists(strDataFile))
            {
                File.Create(strDataFile).Close();
            }

            using (FileStream fs = new FileStream(strDataFile, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                if (fs.Length > 0)
                {
                    try
                    {
                        Globle.m_AirStation = bf.Deserialize(fs) as AirStation;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool SaveAirStation()
        {
            SaveAppConfig();
            string strDataPath = "..\\..\\data";
            if (!Directory.Exists(strDataPath))
            {
                Directory.CreateDirectory(strDataPath);
            }
            string strDataFile = strDataPath + "\\data1.bin";      

            using (FileStream fs = new FileStream(strDataFile, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, Globle.m_AirStation);
            }
            return true;
        }

        public bool SaveAppConfig()
        {
            string strDBConnection = String.Format("Server={0};uid={1};pwd={2};database={3};",
                Globle.m_AirStation.DBServer,
                Globle.m_AirStation.DBUser,
                Globle.m_AirStation.DBPass,
                Globle.m_AirStation.DBName);
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("..\\..\\App.config");
                XmlNode root = xmlDoc.SelectSingleNode("configuration");
                XmlNode node1 = root.SelectSingleNode("connectionStrings/add[@name='source']");
                XmlElement el = node1 as XmlElement;
                el.SetAttribute("connectionString", strDBConnection);
                xmlDoc.Save("..\\..\\App.config");
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool InitAllDevices()
        {
            string strDataPath = "..\\..\\data";
            if (!Directory.Exists(strDataPath))
            {
                Directory.CreateDirectory(strDataPath);
            }
            string strDataFile = strDataPath + "\\SystemData1.bin";
            if (!File.Exists(strDataFile))
            {
                File.Create(strDataFile).Close();
            }

            using (FileStream fs = new FileStream(strDataFile, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                if (fs.Length > 0)
                {
                    try
                    {
                        Globle.m_AllDevices = bf.Deserialize(fs) as List<AirDevice>;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool SaveAllDevices()
        {
            string strDataPath = "..\\..\\data";
            if (!Directory.Exists(strDataPath))
            {
                Directory.CreateDirectory(strDataPath);
            }
            string strDataFile = strDataPath + "\\SystemData1.bin";

            using (FileStream fs = new FileStream(strDataFile, FileMode.Create))
            {
                BinaryFormatter br = new BinaryFormatter();
                br.Serialize(fs, Globle.m_AllDevices);
            }
            return true;
        }

        public bool InitAirDevices()
        {
            string strDataPath = "..\\..\\data";
            if (!Directory.Exists(strDataPath))
            {
                Directory.CreateDirectory(strDataPath);
            }
            string strDataFile = strDataPath + "\\data2.bin";
            if (!File.Exists(strDataFile))
            {
                File.Create(strDataFile).Close();
            }

            using (FileStream fs = new FileStream(strDataFile, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                if (fs.Length > 0)
                {
                    try
                    {
                        Globle.m_AirDevices = bf.Deserialize(fs) as List<AirDevice>;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool SaveAirDevices()
        {
            string strDataPath = "..\\..\\data";
            if (!Directory.Exists(strDataPath))
            {
                Directory.CreateDirectory(strDataPath);
            }
            string strDataFile = strDataPath + "\\data2.bin";

            using (FileStream fs = new FileStream(strDataFile, FileMode.Create))
            {
                BinaryFormatter br = new BinaryFormatter();
                br.Serialize(fs, Globle.m_AirDevices);
            }
            return true;
        }

        public bool TestSqlConnection()
        {
            if (!mSqlOperation.QueryDB())
            {
                return false;
            }
            return true;
        }

        public bool InitPhysicsCom()
        {

            return true;
        }

        public bool CreateDataBase(string strDBPath)
        {
            if (!Directory.Exists(strDBPath))
            {
                Directory.CreateDirectory(strDBPath);
            }
            if (!mSqlOperation.CreateDataBase(strDBPath))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 开机启动项
        /// </summary>
        /// <param name="Started">是否启动</param>
        /// <param name="name">启动值的名称</param>
        /// <param name="path">启动程序的路径 Application.ExecutablePath</param>
        public void RunWhenStart(bool Started, string name, string path)
        {
            RegistryKey HKLM = Registry.LocalMachine;
            RegistryKey Run = HKLM.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            if (Started == true)
            {
                try
                {
                    Run.SetValue(name, path);
                    HKLM.Close();
                }
                catch { }
            }
            else
            {
                try
                {
                    Run.DeleteValue(name);
                    HKLM.Close();
                }
                catch { }
            }
        }

        /// <summary>
        /// 是否第一次运行
        /// </summary>
        public bool GetFirstRun()
        {
            if (IsRegeditDirExist("AQMS") == 0)
            {
                return false;
            }
            else
            {
                SetRegeditData("AQMS", "FirstRun", "firstrun", "1");
            }
            return true;
        }

        public bool ClearFirstRun()
        {
            if (IsRegeditDirExist("AQMS") == 0)
            {
                DelRegeditData("AQMS", "FirstRun");
            }
            return true;
        }

        /// <summary>
        /// 写注册表中字串(REG_SZ)数据
        /// </summary>
        /// <param name="SoftDirName">HKLM\SOFTWARE\EnvSoft的子项名称</param>
        /// <param name="SubDirName">\EnvSoft\SubDirName\的子项的名称</param>
        /// <param name="KeyName">SubDirName的子键名</param>
        /// <param name="KeyValue">写入KeyName的键值</param>
        private void SetRegeditData(string SoftDirName, string SubDirName, string KeyName, string KeyValue)
        {
            RegistryKey hklm = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
            RegistryKey SubDirKey;
            int exitState = IsRegeditDirExist(SoftDirName);
            if (exitState == 0)
            {
                SubDirKey = hklm.OpenSubKey("EnvSoft", true).OpenSubKey(SoftDirName, true);
            }
            else if (exitState == 1)
            {
                SubDirKey = hklm.CreateSubKey("EnvSoft").CreateSubKey(SoftDirName);
            }
            else
            {
                SubDirKey = hklm.OpenSubKey("EnvSoft", true).CreateSubKey(SoftDirName);
            }
            RegistryKey aimdir = SubDirKey.CreateSubKey(SubDirName);
            aimdir.SetValue(KeyName, KeyValue);
        }

        /// <summary>
        /// 删除注册表中子项
        /// </summary>
        /// <param name="SoftDirName">HKLM\SOFTWARE\EnvSoft的子项名称</param>
        /// <param name="SubDirName">要删除的\EnvSoft\SubDirName\的子项的名称</param>
        private void DelRegeditData(string SoftDirName, string SubDirName)
        {
            RegistryKey hklm = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
            RegistryKey SubDirKey;
            int exitState = IsRegeditDirExist(SoftDirName);
            if (exitState == 0)
            {
                SubDirKey = hklm.OpenSubKey("EnvSoft", true).OpenSubKey(SoftDirName, true);
                SubDirKey.DeleteSubKeyTree(SubDirName);
            }
        }

        /// <summary>
        /// 判断目录是否存在
        /// </summary>
        /// <param name="EnvSoftSubDir">HKLM\SOFTWARE\EnvSoft下是否存在该子项</param>
        /// <returns>0：存在，1：不存在EnvSoft，2：不存在EnvSoftSubDir</returns>
        private int IsRegeditDirExist(string EnvSoftSubDir)
        {
            RegistryKey hklm = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
            RegistryKey EnvSoftKey;
            RegistryKey EnvSoftSubKey;

            EnvSoftKey = hklm.OpenSubKey("EnvSoft", true);
            if (EnvSoftKey == null)
            {
                return 1;
            }

            EnvSoftSubKey = EnvSoftKey.OpenSubKey(EnvSoftSubDir, true);
            if (EnvSoftSubKey == null)
            {
                return 2;
            }

            return 0;
        }
    }
}
