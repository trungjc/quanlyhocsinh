using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSO;
using ETO;
using System.Data;

namespace CMS.Client.Admin
{
    public partial class ListImageSlideShow : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            if (!IsPostBack)
                ViewLogo();
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

        #region ViewLogo
        private void ViewLogo()
        {
            LinkBSO linkBSO = new LinkBSO();
            DataTable table = linkBSO.GetLinkAll();
            DataView dv = new DataView(table);
            dv.RowFilter = "LinkType=1";
            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToGridView(grvLink, dv.ToTable());
        }
        #endregion

        protected void grvLink_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = Convert.ToInt32(e.CommandArgument.ToString());
            string cName = e.CommandName.ToLower();
            switch (cName)
            {
                case "_edit":
                    Response.Redirect("~/Admin/EditImageSlideShow/" + Id + "/Default.aspx");
                    break;
                case "_delete":
                    LinkBSO linkBSO = new LinkBSO();
                    linkBSO.DeleteLink(Id);
                    ViewLogo();
                    break;
            }
        }
        protected void grvLink_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton image_del = (ImageButton)e.Row.FindControl("btn_delete");
                image_del.Attributes.Add("onclick", "return confirm('Bạn có chắc chắn muốn xóa?');");

            }
        }

    }
}