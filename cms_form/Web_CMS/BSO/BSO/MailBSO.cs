namespace BSO
{
    using System;
    using System.Net.Mail;
    using System.Text.RegularExpressions;
    using System.Web.Configuration;

    public class MailBSO
    {
        private string emailfrom;

        private void AttachFile(MailMessage mailMessage, string attachFileName)
        {
            if (attachFileName != "")
            {
                using (Attachment attachment = new Attachment(attachFileName))
                {
                    mailMessage.Attachments.Add(attachment);
                }
            }
        }

        public bool IsEmail(string inputEmail)
        {
            if ((inputEmail == null) | (inputEmail.Length > 0x23))
            {
                return false;
            }
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,6}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            return re.IsMatch(inputEmail);
        }

        public bool SendMail(string emailTo, string subject, string body)
        {
            bool sendSucessful = true;
            try
            {
                MailAddress mailAddress = new MailAddress(this.emailfrom);
                MailMessage mailMessage = new MailMessage {
                    From = mailAddress
                };
                mailMessage.To.Add(emailTo);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.Priority = MailPriority.High;
                SmtpClient smtpClient = new SmtpClient();
                string strHost = WebConfigurationManager.ConnectionStrings["SMTPServer"].ConnectionString;
                smtpClient.Host = strHost;
                smtpClient.Send(mailMessage);
            }
            catch
            {
                sendSucessful = false;
            }
            return sendSucessful;
        }

        public bool SendMail(string emailTo, string emailCC, string emailBCC, string subject, string body)
        {
            bool sendSucessful = true;
            try
            {
                MailAddress mailAddress = new MailAddress(this.emailfrom);
                MailMessage mailMessage = new MailMessage {
                    From = mailAddress
                };
                mailMessage.To.Add(emailTo);
                mailMessage.Subject = subject;
                if (emailCC != "")
                {
                    mailMessage.CC.Add(emailCC);
                }
                if (emailBCC != "")
                {
                    mailMessage.Bcc.Add(emailBCC);
                }
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.Priority = MailPriority.High;
                new SmtpClient().Send(mailMessage);
            }
            catch
            {
                sendSucessful = false;
            }
            return sendSucessful;
        }

        public bool SendMail(string emailTo, string emailCC, string emailBCC, string subject, string body, string[] attachFileName)
        {
            bool sendSucessful = true;
            try
            {
                MailAddress mailAddress = new MailAddress(this.emailfrom);
                MailMessage mailMessage = new MailMessage {
                    From = mailAddress
                };
                mailMessage.To.Add(emailTo);
                mailMessage.Subject = subject;
                if (emailCC != "")
                {
                    mailMessage.CC.Add(emailCC);
                }
                if (emailBCC != "")
                {
                    mailMessage.Bcc.Add(emailBCC);
                }
                mailMessage.Body = body;
                if (attachFileName != null)
                {
                    foreach (string fileName in attachFileName)
                    {
                        this.AttachFile(mailMessage, fileName);
                    }
                }
                mailMessage.IsBodyHtml = true;
                mailMessage.Priority = MailPriority.High;
                new SmtpClient().Send(mailMessage);
            }
            catch
            {
                sendSucessful = false;
            }
            return sendSucessful;
        }

        public string EmailFrom
        {
            get
            {
                return this.emailfrom;
            }
            set
            {
                this.emailfrom = value;
            }
        }
    }
}

