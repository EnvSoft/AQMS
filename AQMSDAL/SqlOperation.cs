using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AQMSDBUtility;
using AQMSModel;

namespace AQMSDAL
{
    public class SqlOperation : SqlHelper
    {
        public bool QueryDB()
        {
            string strDBConnection = String.Format("Server={0};uid={1};pwd={2};database=master;",
                Globle.m_AirStation.DBServer,
                Globle.m_AirStation.DBUser,
                Globle.m_AirStation.DBPass);

            string strQuery = "select database_id from master.sys.databases where name = '" + Globle.m_AirStation.DBName + "'";
            try
            {
                object mObject = SqlHelper.ExecuteScalar(strDBConnection, System.Data.CommandType.Text, strQuery, null);
                if (Convert.ToInt32(mObject) > 0)
                {
                    return true;
                }
            }
            catch (SqlException)
            {
            }
            return false;
        }

        public bool CreateDataBase(string strDBPath)
        {
            string strMasterConnection = String.Format("Server={0};uid={1};pwd={2};database=master;",
                Globle.m_AirStation.DBServer,
                Globle.m_AirStation.DBUser,
                Globle.m_AirStation.DBPass);
            string strDBConnection = String.Format("Server={0};uid={1};pwd={2};database={3};",
                Globle.m_AirStation.DBServer,
                Globle.m_AirStation.DBUser,
                Globle.m_AirStation.DBPass,
                Globle.m_AirStation.DBName);

            string strCreateDB = "CREATE DATABASE " + Globle.m_AirStation.DBName
                + " ON  PRIMARY\r\n(NAME = N'AQMS_Data', FILENAME = N'" + strDBPath
                + "\\AQMS.mdf' , SIZE = 3520KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)\r\n"
                + "LOG ON\r\n(NAME = N'AQMS_Log', FILENAME = N'" + strDBPath
                + "\\AQMS_log.ldf', SIZE = 1024KB, MAXSIZE = UNLIMITED, FILEGROWTH = 10 %)\r\n";
            string strSetDBLevel = "ALTER DATABASE " + Globle.m_AirStation.DBName + " SET COMPATIBILITY_LEVEL = 80\r\n";
            try
            {
                SqlHelper.ExecuteNonQuery(strMasterConnection, System.Data.CommandType.Text, strCreateDB, null);
                SqlHelper.ExecuteNonQuery(strMasterConnection, System.Data.CommandType.Text, strSetDBLevel, null);
            }
            catch (SqlException)
            {
                return false;
            }
            return true;
        }

        public bool QueryAllDevices()
        {
            string strSqlQuery = "select * from AirDevices where Selected = 1 order by DeviceID asc";
            try
            {
                SqlDataReader mSqlDataReader = SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, strSqlQuery, null);
                while (mSqlDataReader.Read())
                {
                    Globle.m_AllDevices.Add(GetDevice(mSqlDataReader));
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool SaveAllDevices()
        {

            return true;
        }

        private AirDevice GetDevice(SqlDataReader mSqlDataReader)
        {
            AirDevice mAirDevice = new AirDevice();
            mAirDevice.DevChName = mSqlDataReader["DeviceChName"].ToString();
            mAirDevice.DevName = mSqlDataReader["DeviceName"].ToString();
            mAirDevice.DevType = mSqlDataReader["DeviceType"].ToString();
            mAirDevice.DevMode = mSqlDataReader["DeviceMode"].ToString();
            int itemCount = Convert.ToInt32(mSqlDataReader["ItemsNum"]);
            string items = mSqlDataReader["Items"].ToString();
            for (int i = 0; i < itemCount; i++)
            {
                AirItem mAirItem = new AirItem();
                int nIndex = items.IndexOf("-");
                if (nIndex == -1)
                {
                    mAirItem.ItemName = items;
                }
                else
                {
                    mAirItem.ItemName = items.Substring(0, nIndex);
                }              
                items = items.Substring(nIndex + 1);
                mAirDevice.Items.Add(mAirItem);
            }
            return mAirDevice;
        }
    }
}
