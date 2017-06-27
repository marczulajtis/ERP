using ERP.Common.Entities;
using ERP.Common.Helpers;
using ERP.Common.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ERP.Common.Concrete
{
    public class EmailService
    {
        public EmailService()
        { }

        public void SendResetEmail(User user)
        {
            string encryptedString = Encryption.Encrypt(string.Format("{0}&{1}",
                user.UserName, DateTime.Now.Ticks),
                ConfigurationManager.AppSettings[AppSettings.EncryptionKey]);

            var passwordLink = ApplicationHelpers.GetBaseURL() +
                "/User/User/ResetPassword?userNameAndDate=" + HttpUtility.UrlEncode(encryptedString);

            var email = new MailMessage();

            email.From = new MailAddress("mulanecka@gmail.com");
            email.To.Add(new MailAddress(user.Email));

            email.Subject = "Password reset";
            email.IsBodyHtml = true;

            email.Body += "<p> Request has been received to reset your password." +
                " If you did not initiate this request, please ignore this email.</p>";
            email.Body += "<p> Please click the following link " + passwordLink + " to reset your password </p>";
            email.Body += "<br/> <p> This link will be active for 15 minutes from visiting it. </p>";

            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 25;
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("mulanecka@gmail.com", "Fltk22!.!");

            try
            {
                smtpClient.Send(email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
