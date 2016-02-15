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
    public partial class listemail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            if (!IsPostBack)
                ViewEmail();
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

        #region ViewEmail
        public void ViewEmail()
        {
            EmailBSO emailBSO = new EmailBSO();
            DataTable table = emailBSO.GetEmailAll();
            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToGridView(grvEmail, table);
        }
        #endregion
        protected void grvEmail_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = Convert.ToInt32(e.CommandArgument.ToString());
            string nName = e.CommandName.ToLower();
            switch (nName)
            {

                case "_edit":
                    Response.Redirect("~//Admin/editemail/" + Id + "/Default.aspx");
                    break;
                case "_delete":

                    EmailBSO emailBSO = new EmailBSO();
                    emailBSO.DeleteEmail(Id);
                    ViewEmail();
                    break;
            }
        }
        protected void grvEmail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton image_del = (ImageButton)e.Row.FindControl("btn_delete");
                image_del.Attributes.Add("onclick", "javascript:return confirm('Bạn có muốn chắc chắn xóa ???');");

            }
        }

    }
}