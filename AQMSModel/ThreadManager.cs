using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AQMSModel
{
    public class ThreadManager
    {
        private static Dictionary<string, Thread> m_ThreadDict = new Dictionary<string, Thread>();

        public bool AddThread(string name, Thread thr)
        {
            try
            {
                m_ThreadDict.Add(name, thr);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool RemoveThread(string name)
        {
            try
            {
                m_ThreadDict.Remove(name);
            }
            catch (Exception)
            {
                return false; ;
            }            
            return true;
        }

        public bool CloseAll()
        {

            return true;
        }
    }
}
