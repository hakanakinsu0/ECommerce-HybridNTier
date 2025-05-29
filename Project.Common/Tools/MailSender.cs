using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Project.Common.Tools
{
    public static class MailSender
    {

        #region TestEmailiVeSifre
        //testemail3172@gmail.com

        //rvzhpxwpegickwtq 
        #endregion

        public static void Send(string receiver, string password = "rvzhpxwpegickwtq", string body = "Test mesajıdır", string subject = "Test", string sender = "testemail3172@gmail.com")
        {
            MailAddress senderEmail = new MailAddress(sender);
            MailAddress receiverEmail = new MailAddress(receiver);

            SmtpClient smtpClient = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };

            using (MailMessage message = new MailMessage(senderEmail, receiverEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
            {
                smtpClient.Send(message);
            }
        }
    }
}