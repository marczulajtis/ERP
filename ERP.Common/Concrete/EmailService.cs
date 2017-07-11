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
                Consts.PasswordLinkCommonPath + HttpUtility.UrlEncode(encryptedString);

            var email = new MailMessage();

            email.From = new MailAddress("mulanecka@gmail.com");
            email.To.Add(new MailAddress(user.Email));

            email.Subject = Consts.EmailSubject;
            email.IsBodyHtml = true;

            email.Body = Consts.ResetLinkBodyMessagePart1 + passwordLink + Consts.ResetLinkBodyMessagePart2;

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
