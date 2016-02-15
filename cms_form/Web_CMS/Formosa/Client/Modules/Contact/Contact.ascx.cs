using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSO;
using ETO;

namespace Fomusa.Client.Modules.Contact
{
    public partial class Contact : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewWelcome(Language.language);
            title_cate.Text = CateNavigator();

        }

        private string CateNavigator()
        {
            string ngonngu = Session["Lang"].ToString();
            string url = "<a href='" + ResolveUrl("~/") + "Default.aspx' class='content_Text_Cat'>" + Resources.resource.Home + "</a>  &nbsp;<img src='" + ResolveUrl("~/") + "images/icon_arrows1.png'>&nbsp;";
            return url;
        }
        private void ViewWelcome(string lang)
        {
            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(lang);
            LiteralContact.Text = config.Contact;
        }

        #region ReceiveHtml
        public ETO.Contact ReceiveHtml()
        {


            ETO.Contact contact = new ETO.Contact();
            contact.ContactID = 0;

            contact.Email = Email.Value.Trim();
            contact.Name = NameContact.Value.Trim();
            contact.Address = Address.Value.Trim();
            contact.Tel = Telephone.Value.Trim();
            contact.Fax = Fax.Value.Trim();

            contact.City = City.Value.Trim();
            contact.Company = Company.Value.Trim();


            contact.Date = DateTime.Now;


            contact.Attact = "";

            contact.Require = Require.Value;

            return contact;
        }
        #endregion

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ETO.Contact contact = ReceiveHtml();
                BSO.ContactBSO contactBSO = new BSO.ContactBSO();
                contactBSO.CreateContact(contact);


                ConfigBSO configBSO = new ConfigBSO();
                Config config = configBSO.GetAllConfig(Language.language);

                string strBody = "Thông tin liên hệ tới Website " + config.WebName + " (" + config.WebDomain + "): <br>";
                strBody += "<b>Họ tên  : </b> " + NameContact.Value + "<br>";
                strBody += "<b>Cơ quan công tác : </b> " + Company.Value + "<br>";
                strBody += "<b>Địa chỉ : </b> " + Address.Value + "<br>";
                strBody += "<b>Thành phố : </b> " + City.Value + "<br>";
                strBody += "<b>Điện thoại : </b> " + Telephone.Value + "<br>";
                strBody += "<b>Fax : </b> " + Fax.Value + "<br>";

                strBody += "<b>Email : </b> " + Email.Value + "<br>";
                strBody += "<b>Nội dung Yêu cầu : </b> " + Require.Value + "<br>";

                MailBSO mailBSO = new MailBSO();


                //       mailBSO.EmailFrom = Email.Value;
                mailBSO.EmailFrom = config.Email_from;
                string strObj = "Thông tin liên hệ tới quản trị viên website " + config.WebName + " (" + config.WebDomain + ") - Ngày " + DateTime.Now.ToString("dd:MM:yyyy");
                mailBSO.SendMail(config.Email_to, strObj, strBody);

                Response.Redirect("~/ContactSucceed/Default.aspx");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}