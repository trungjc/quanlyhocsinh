using System;
using System.Collections.Generic;
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
                message.From = new MailAddress("iee.contact105@gmail.com", "IEE Contact.", System.Text.Encoding.UTF8);
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.googlemail.com";
                client.Port = 587;
                client.UseDefaultCredentials = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("iee.contact105@gmail.com", "iee@12345");
                client.Send(message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
