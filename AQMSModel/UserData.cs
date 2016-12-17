using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQMSModel
{
    public class UserData
    {
        private int userID;
        private string userName;
        private string userPass;
        private string userGroup;

        public int UserID
        {
            get
            {
                return userID;
            }

            set
            {
                userID = value;
            }
        }

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public string UserPass
        {
            get
            {
                return userPass;
            }

            set
            {
                userPass = value;
            }
        }

        public string UserGroup
        {
            get
            {
                return userGroup;
            }

            set
            {
                userGroup = value;
            }
        }

        
    }
}
