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
    public partial class ListMenuLinks : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            if (!Page.IsPostBack)
            {
                ViewMenuLinks();
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
        public void ViewMenuLinks()
        {
            MenuLinksBSO menuLinksBSO = new MenuLinksBSO();
            DataTable table = menuLinksBSO.MixMenuLinks();
            //commonBSO commonBSO = new commonBSO();
            //commonBSO.FillToGridView(grvMenuLink, table);
            grvMenuLink.DataSource = table;
            grvMenuLink.DataBind();

        }

        protected void grvMenuLink_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int mID = Convert.ToInt32(e.CommandArgument.ToString().Trim());
            string cName = e.CommandName.ToLower().Trim();
            switch (cName)
            {
                case "edit":
                    Response.Redirect("~/Admin/editmenulinks/" + mID + "/Default.aspx");
                    break;
                case "delete":
                    MenuLinksBSO menuLinksBSO = new MenuLinksBSO();
                    menuLinksBSO.DeleteMenuLinks(mID);
                    ViewMenuLinks();
                    break;
            }
        }

        protected void grvMenuLink_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton image_del = (ImageButton)e.Row.FindControl("btn_delete");
                image_del.Attributes.Add("onclick", "javascript:return confirm('Bạn có muốn chắc chắn xóa ???');");
            }
        }

        protected void grvMenuLink_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btn_Order_Click(object sender, ImageClickEventArgs e)
        {
            foreach (GridViewRow row in grvMenuLink.Rows)
            {
                TextBox textOrder = (TextBox)row.FindControl("txtMenuLinksOrder");
                int cOrder = Convert.ToInt32(textOrder.Text);
                int cateID = Convert.ToInt32(row.Cells[0].Text);
                MenuLinksBSO menuLinksBSO = new MenuLinksBSO();
                menuLinksBSO.MenuLinksUpOrder(cateID, cOrder);
            }
            ViewMenuLinks();
        }

        protected void grvMenuLink_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvMenuLink.PageIndex = e.NewPageIndex;
            ViewMenuLinks();
        }
    
    }
}