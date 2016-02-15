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
    public partial class listsinglepage : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            if (!IsPostBack)
                ViewSinglePage(Language.language);
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

        private void ViewSinglePage(string lang)
        {
            SinglePageBSO singlepageBSO = new SinglePageBSO();
            DataTable table = singlepageBSO.GetSinglePageAll(lang);
            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToGridView(grvSinglePage, table);
        }

        protected void grvSinglePage_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvSinglePage.PageIndex = e.NewPageIndex;
            ViewSinglePage(Language.language);
        }
        protected void grvSinglePage_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = Convert.ToInt32(e.CommandArgument.ToString());
            string cName = e.CommandName.ToLower();
            switch (cName)
            {
                case "_edit":
                    Response.Redirect("~/Admin/editsinglepage/" + Id + "/Default.aspx");
                    break;
                case "_delete":
                    SinglePageBSO singlepageBSO = new SinglePageBSO();
                    singlepageBSO.DeleteSinglePage(Id);
                    ViewSinglePage(Language.language);
                    break;
            }
        }
        protected void grvSinglePage_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton image_del = (ImageButton)e.Row.FindControl("btn_delete");
                image_del.Attributes.Add("onclick", "return confirm('Bạn có chắc chắn muốn xóa?');");

            }
        }
        protected void btn_enable_Click(object sender, ImageClickEventArgs e)
        {

        }
        protected void btn_disable_Click(object sender, ImageClickEventArgs e)
        {

        }
        protected void btn_delall_Click(object sender, ImageClickEventArgs e)
        {

        }

    }
}