using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ETO;
using BSO;
using System.Net.Mail;
using System.Web.Configuration;
using System.Net;
using System.Threading;
using System.Net.Mime;

namespace CMS.Client.Admin
{
    public partial class editcontact : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = 0;
            if (Page.RouteData.Values["Id"] != null)
                int.TryParse(Page.RouteData.Values["Id"].ToString().Replace(",", ""), out Id);
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            if (!IsPostBack)
            {
                ViewDate();
                initControl(Id);
            }
        }

        #region NavigationTitle
        private void NavigationTitle(string url)
        {
            ModulesBSO modulesBSO = new ModulesBSO();
            Modules modules = modulesBSO.GetModulesByUrl(url);
            imgIcon.ImageUrl = "~/Upload/Admin_Theme/Icons/" + modules.ModulesIcon;
            litModules.Text = modules.ModulesName;
        }
        #endregion

        #region initControl
        protected void initControl(int Id)
        {
            if (Id > 0)
            {
                btn_add.Visible = false;
                btn_edit.Visible = true;
                try
                {
                    ContactBSO contactBSO = new ContactBSO();
                    Contact contact = contactBSO.GetContactById(Id);

                    hddContactID.Value = Convert.ToString(contact.ContactID);

                    txtEmail.Text = contact.Email;

                    txtName.Text = contact.Name;
                    txtAddress.Text = contact.Address;
                    txtTel.Text = contact.Tel;
                    txtFax.Text = contact.Fax;

                    txtCity.Text = contact.City;
                    txtCompany.Text = contact.Company;




                    cboDay1.SelectedValue = contact.Date.Day.ToString();
                    cboMonth1.SelectedValue = contact.Date.Month.ToString();
                    cboYear1.SelectedValue = contact.Date.Year.ToString();
                    cboMinutes1.SelectedValue = contact.Date.Minute.ToString();
                    cboHour1.SelectedValue = contact.Date.Hour.ToString();




                    txtRequire.Value = contact.Require;
                    txtAnswer.Text = contact.Answer;
                    if (contact.Sendmail == true)
                    {
                        chkSendMail.Checked = true;
                    }
                    else 
                    {
                        chkSendMail.Checked = false;
                    }


                }
                catch (Exception ex)
                {
                    error.Text = ex.Message.ToString();
                }
            }
            else if (Id == 0)
            {
                btn_add.Visible = true;
                btn_edit.Visible = false;
            }
        }
        #endregion

        #region ViewDate
        public void ViewDate()
        {

            for (int i = 1; i <= 31; i++)
                cboDay1.Items.Add(Convert.ToString(i));
            for (int i = 1; i <= 12; i++)
                cboMonth1.Items.Add(Convert.ToString(i));
            for (int i = 2009; i <= 2100; i++)
                cboYear1.Items.Add(Convert.ToString(i));
            for (int i = 0; i < 24; i++)
                cboHour1.Items.Add(Convert.ToString(i));
            for (int i = 0; i < 60; i++)
                cboMinutes1.Items.Add(Convert.ToString(i));

            cboDay1.SelectedValue = DateTime.Now.Day.ToString();
            cboMonth1.SelectedValue = DateTime.Now.Month.ToString();
            cboYear1.SelectedValue = DateTime.Now.Year.ToString();
            cboMinutes1.SelectedValue = DateTime.Now.Minute.ToString();
            cboHour1.SelectedValue = DateTime.Now.Hour.ToString();


        }
        #endregion

        #region ReceiveHtml
        public Contact ReceiveHtml()
        {
            Contact contact = new Contact();
            contact.ContactID = (hddContactID.Value != "") ? Convert.ToInt32(hddContactID.Value) : 0;

            contact.Email = (txtEmail.Text != "") ? txtEmail.Text.Trim() : "";
            contact.Name = (txtName.Text != "") ? txtName.Text.Trim() : "";
            contact.Address = (txtAddress.Text != "") ? txtAddress.Text.Trim() : "";
            contact.Tel = (txtTel.Text != "") ? txtTel.Text.Trim() : "";
            contact.Fax = (txtFax.Text != "") ? txtFax.Text.Trim() : "";

            contact.City = (txtCity.Text != "") ? txtCity.Text.Trim() : "";
            contact.Company = (txtCompany.Text != "") ? txtCompany.Text.Trim() : "";


            contact.Date = new DateTime(Convert.ToInt16(cboYear1.SelectedValue),
                                        Convert.ToInt16(cboMonth1.SelectedValue),
                                        Convert.ToInt16(cboDay1.SelectedValue),
                                        Convert.ToInt16(cboHour1.SelectedValue),
                                        Convert.ToInt16(cboMinutes1.SelectedValue), 0);


            contact.Attact = "";
            contact.Require = txtRequire.Value;
            contact.Answer = txtAnswer.Text.Trim();
            if (chkSendMail.Checked == true)
            {
                contact.Sendmail = true;
            }
            else
            {
                contact.Sendmail = false;
            }
            return contact;
        }
        #endregion

        #region Send Mail
        public void SendMail(string toEmail, string subject, string body)
        {
            var fromAddress = new MailAddress(WebConfigurationManager.AppSettings["WebMail.UserName"], "Web MEDI Long Biên");
            var toAddress = new MailAddress(toEmail, "To Name");
            string fromPassword = WebConfigurationManager.AppSettings["WebMail.Pass"];

            var smtp = new SmtpClient
            {
                Host = WebConfigurationManager.AppSettings["WebMail.Host"],
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,

                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            Thread ThreadEmail = new Thread(delegate()
            {
                using (MailMessage message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,

                })
                {
                    message.Body = body;
                    message.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(body, new ContentType("text/html")));
                    smtp.Send(message);
                }
            });

            ThreadEmail.Start();
        }

        public void Check_SendMail(Contact contact)
        {
            string host = Request.Url.Host.ToLower();
            int port = Request.Url.Port;
            string subject = "Giải đáp câu hỏi " + host;
            if (port != 0)
            {
                host += ":" + port.ToString();
            }

            string body = "   Chào bạn <b>" + contact.Name + "</b>, <p>Câu hỏi " + contact.Require + " của bạn đã có câu trả lời:  </p>" + txtAnswer.Text.ToString();
            SendMail(contact.Email, subject, body);
        }
        #endregion

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Contact contact = ReceiveHtml();
            try
            {
                ContactBSO contactBSO = new ContactBSO();
                contactBSO.CreateContact(contact);
                if (chkSendMail.Checked == true)
                {
                    Check_SendMail(contact);
                }
                error.Text = String.Format(Resources.StringAdmin.AddNewsSuccessful);
            }
            catch (Exception ex)
            {
                error.Text = ex.Message.ToString();
            }
        }
        protected void btn_edit_Click(object sender, EventArgs e)
        {

            try
            {
                Contact contact = ReceiveHtml();
                ContactBSO contactBSO = new ContactBSO();
                contactBSO.UpdateContact(contact);
                if (chkSendMail.Checked == true)
                {
                    Check_SendMail(contact);
                }
                error.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "Đặt thuê xe", contact.ContactID);
            }
            catch (Exception ex)
            {
                error.Text = ex.Message.ToString();
            }
        }
        protected void chkSendMail_CheckChanged(object sender, EventArgs e)
        {
           
        }
    }
}