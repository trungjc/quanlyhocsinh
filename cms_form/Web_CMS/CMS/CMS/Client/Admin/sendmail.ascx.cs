using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ETO;
using BSO;
using System.Data;


namespace CMS.Client.Admin
{
    public partial class sendmail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());

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


        protected void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigBSO configBSO = new ConfigBSO();
                Config config = configBSO.GetAllConfig(Language.language);

                MailBSO mailBSO = new MailBSO();
                mailBSO.EmailFrom = config.Email_from;

                EmailBSO emailBSO = new EmailBSO();
                DataTable table = emailBSO.GetEmailAll();


                string subject = txtTitle.Text;
                string body = txtRadFull.Html;

                for (int i = 0; i < table.Rows.Count; i++)
                    mailBSO.SendMail(table.Rows[i]["EmailAddress"].ToString(), subject, body);

                clientview.Text = "Thư đã được gửi đến danh sách Người dùng";

            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }

    }
}