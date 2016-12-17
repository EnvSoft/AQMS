using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AQMSModel;
using AQMSDAL;

namespace AQMSBLL
{
    public class AQIDataBLL
    {
        AirAQI mAirAQI = new AirAQI();
        List<int> IAQIValues = new List<int>();

        public int GetAQIValue()
        {
            
            int mAQI = mAirAQI.GetAQI(IAQIValues);
            return mAQI;
        }

        public string GetAQILevel()
        {
            string AQILevel = "";
            return AQILevel;
        }


    }
}
