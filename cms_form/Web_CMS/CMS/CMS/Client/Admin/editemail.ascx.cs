using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ETO;
using BSO;

namespace CMS.Client.Admin
{
    public partial class editemail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            int Id = 0;
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            if (Page.RouteData.Values["Id"] != null)                
                int.TryParse(Page.RouteData.Values["Id"].ToString(), out Id);
            if (!IsPostBack)
                initControl(Id);
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
        private void initControl(int Id)
        {
            if (Id > 0)
            {
                btn_add.Visible = false;
                btn_edit.Visible = true;
                try
                {
                    EmailBSO emailBSO = new EmailBSO();
                    Email email = emailBSO.GetEmailById(Id);
                    hddEmailID.Value = Convert.ToString(email.EmailID);
                    txtEmailAddress.Text = email.EmailAddress;
                    txtName.Text = email.Name;
                }
                catch (Exception ex)
                {
                    clientview.Text = ex.Message.ToString();
                }
            }
            else
            {
                btn_add.Visible = true;
                btn_edit.Visible = false;
            }
        }
        #endregion

        #region ReceiveHtml
        private Email ReceiveHtml()
        {


            Email email = new Email();
            email.EmailID = (hddEmailID.Value != "") ? Convert.ToInt32(hddEmailID.Value) : 0;
            email.Name = txtName.Text;
            email.EmailAddress = txtEmailAddress.Text;

            return email;
        }
        #endregion
        protected void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                Email email = ReceiveHtml();
                EmailBSO emailBSO = new EmailBSO();
                emailBSO.CreateEmail(email);
                clientview.Text = String.Format(Resources.StringAdmin.AddNewsSuccessful);
            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }
        protected void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                Email email = ReceiveHtml();
                EmailBSO emailBSO = new EmailBSO();
                emailBSO.UpdateEmail(email);
                clientview.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "Email: ", email.EmailAddress);
            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }
    }
}