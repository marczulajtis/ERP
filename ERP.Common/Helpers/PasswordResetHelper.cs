using ERP.Common.Concrete;
using ERP.Common.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ERP.Common.Helpers
{
    public static class PasswordResetHelper
    {
        public static PasswordReset ValidateResetCode(string nameAndTicksString)
        {
            string[] userNameAndTicksArray = nameAndTicksString.Split('&');

            DateTime linkSentDate = GetDateFromTicks(Convert.ToInt64(userNameAndTicksArray[1]));

            if (userNameAndTicksArray.Length > 0)
            {
                PasswordReset passwordReset = new PasswordReset
                {
                    UserName = userNameAndTicksArray[0],
                    LinkSentDate = linkSentDate
                };

                return passwordReset;
            }

            return null;
        }

        private static DateTime GetDateFromTicks(Int64 ticks)
        {
            return new DateTime(ticks);
        }

        public static string GetArgumentValueFromLink(string userNameAndDate)
        {
            return Encryption.Decrypt(userNameAndDate, ConfigurationManager.AppSettings["encryptionKey"]);
        }
    }
}
