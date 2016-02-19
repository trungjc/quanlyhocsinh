using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace IEE.Utilities.Helpers
{
    public class Mail
    { 
         
        public static void SendMail(MailMessage message)
        {
            try
            {
                var email =  ConfigurationSettings.AppSettings["Email"];
                var password = ConfigurationSettings.AppSettings["EmailPassword"];

                message.From = new MailAddress(email, "IEE Contact.", System.Text.Encoding.UTF8);
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.googlemail.com";
                client.Port = 587;
                client.UseDefaultCredentials = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(email, password);
                client.Send(message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
