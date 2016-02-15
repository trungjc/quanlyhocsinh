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
    public partial class listcontact : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            if (!IsPostBack)
                ViewContact();
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

        #region ViewContact
        private void ViewContact()
        {
            ContactBSO contactBSO = new ContactBSO();
            DataTable table = contactBSO.GetContactAll();
            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToGridView(grvContact, table);
        }
        #endregion

        protected void grvContact_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = Convert.ToInt32(e.CommandArgument.ToString());
            string cName = e.CommandName.ToLower();
            switch (cName)
            {
                case "_edit":
                    Response.Redirect("~/Admin/editcontact/" + Id + "/Default.aspx");
                    break;
                case "_delete":
                    ContactBSO contactBSO = new ContactBSO();
                    contactBSO.DeleteContact(Id);
                    ViewContact();
                    break;
            }
        }
        protected void grvContact_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var imageDel = (ImageButton)e.Row.FindControl("btn_delete");
                imageDel.Attributes.Add("onclick", "return confirm('Bạn có chắc chắn muốn xóa?');");
            }
        }

        protected void grvContact_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvContact.PageIndex = e.NewPageIndex;
            ViewContact();
        }
    }
}