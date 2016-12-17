using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AQMSModel;
using AQMSDAL;

namespace AQMSBLL
{
    public class LoginBLL
    {
        public int UserLogin(UserData user)
        {
            UserDAL mUserDAL = new UserDAL();
            int nQuery = mUserDAL.QueryUser(user);
            if (nQuery > 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }      
    }
}
