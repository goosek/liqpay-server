using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace LiqPayServer.Utils
{
    public class MailHelper
    {
        static string password = ConfigurationManager.AppSettings["mailPassword"];

        public static void SendMail(string subject, string body,string sendToMail,string sendFromMail)
        {
            SmtpClient client = new SmtpClient();
            MailAddress sendTo = new MailAddress(sendToMail);
            MailAddress from = new MailAddress(sendFromMail);
            MailMessage mailMessage = new MailMessage(from, sendTo);
            mailMessage.IsBodyHtml = false;
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            NetworkCredential nc = new NetworkCredential(sendFromMail, password);
            client.Host = "smtp.gmail.com";
            client.UseDefaultCredentials = false;

            client.Port = 25;
            client.Credentials = nc;
            client.EnableSsl = true;
            
            client.Send(mailMessage);    
        }
    }
}