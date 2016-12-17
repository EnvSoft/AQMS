using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQMSBLL
{
    public class LogToFile
    {
        public LogToFile(string AppPath)
        {
            LogFilePath = AppPath + "\\Log";
        }

        public void WriteSysLog(string strLogMsg)
        {
            DateTime nowTime = DateTime.Now;
            string strFileName = DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            string strFilePath = LogFilePath + "\\SysLog\\" + strFileName;
            FileStream fs = new FileStream(strFilePath, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            string strLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + strLogMsg + "\n";
            sw.Write(strLog); // 开始写入           
            sw.Flush(); // 清空缓冲区            
            sw.Close(); // 关闭流
            fs.Close();
        }

        public void WriteDBLog(string strLogMsg)
        {
            DateTime nowTime = DateTime.Now;
            string strFileName = DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            string strFilePath = LogFilePath + "\\DBLog\\" + strFileName;
            FileStream fs = new FileStream(strFilePath, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            string strLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + strLogMsg + "\n";
            sw.Write(strLog); // 开始写入           
            sw.Flush(); // 清空缓冲区            
            sw.Close(); // 关闭流
            fs.Close();
        }

        public void WriteNetLog(string strLogMsg)
        {
            DateTime nowTime = DateTime.Now;
            string strFileName = DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            string strFilePath = LogFilePath + "\\NetLog\\" + strFileName;
            FileStream fs = new FileStream(strFilePath, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            string strLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + strLogMsg + "\n";
            sw.Write(strLog); // 开始写入           
            sw.Flush(); // 清空缓冲区            
            sw.Close(); // 关闭流
            fs.Close();
        }

        public void WriteComLog(string strLogMsg)
        {
            DateTime nowTime = DateTime.Now;
            string strFileName = DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            string strFilePath = LogFilePath + "\\ComLog\\" + strFileName;
            FileStream fs = new FileStream(strFilePath, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            string strLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + strLogMsg + "\n";
            sw.Write(strLog); // 开始写入           
            sw.Flush(); // 清空缓冲区            
            sw.Close(); // 关闭流
            fs.Close();
        }

        public void WriteCtrLog(string strLogMsg)
        {
            DateTime nowTime = DateTime.Now;
            string strFileName = DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            string strFilePath = LogFilePath + "\\CtrLog\\" + strFileName;
            FileStream fs = new FileStream(strFilePath, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            string strLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + strLogMsg + "\n";
            sw.Write(strLog); // 开始写入           
            sw.Flush(); // 清空缓冲区            
            sw.Close(); // 关闭流
            fs.Close();
        }

        public string LogFilePath { get; private set; }
    }
}
