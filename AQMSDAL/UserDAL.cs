using AQMSDBUtility;
using AQMSModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQMSDAL
{
    public class UserDAL
    {
        public int QueryUser(UserData user)
        {
            string strSqlQuery = "select UserID from UserData where UserGroup = @uGroup and UserName = @uName and UserPass = @uPass";
            List<SqlParameter> queryParameter = new List<SqlParameter>();
            queryParameter.Add(new SqlParameter("@uGroup", user.UserGroup));
            queryParameter.Add(new SqlParameter("@uName", user.UserName));
            queryParameter.Add(new SqlParameter("@uPass", EncryptPass(user.UserPass)));
            object uID =  SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, System.Data.CommandType.Text, strSqlQuery, queryParameter);
            try
            {
                return Convert.ToInt32(uID.ToString());
            }
            catch (Exception)
            {
                return 0;
            }         
        }

        private string EncryptPass(string strPass)
        {
            string encryptPass = "";
            for (int i = 0; i < strPass.Length; i++)
            {
                if (strPass[i] >= 48 && strPass[i] <= 57)
                {
                    encryptPass += (char)(112 - strPass[i]);
                }
                else if (strPass[i] >= 65 && strPass[i] <= 90)
                {
                    encryptPass += (char)(187 - strPass[i]);
                }
                else if (strPass[i] >= 97 && strPass[i] <= 122)
                {
                    encryptPass += (char)(187 - strPass[i]);
                }
            }
            return encryptPass;
        }
    }
}
