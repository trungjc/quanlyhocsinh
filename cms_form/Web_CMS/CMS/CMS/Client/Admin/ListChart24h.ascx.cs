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
    public partial class ListChart24h : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            if (!IsPostBack)
                ViewChart24h();
            hdnUrl.Value = ResolveUrl("~/") + "Client/Admin/ImportExcel.aspx";
            hdnUrl1.Value = ResolveUrl("~/") + "Client/Admin/ListChart24hConfig.aspx";
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

        #region ViewChart24h
        private void ViewChart24h()
        {
            Chart24hBSO chart24hBSO = new Chart24hBSO();
            DataTable table = chart24hBSO.GetChart24hAll();
            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToGridView(grvChart24h, table);
        }
        #endregion

        protected void grvChart24h_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = Convert.ToInt32(e.CommandArgument.ToString());
            string cName = e.CommandName.ToLower();
            switch (cName)
            {
                case "_edit":
                    Response.Redirect("~/Admin/editchart24h/" + Id + "/Default.aspx");
                    break;
                case "_delete":
                    Chart24hBSO chart24hBSO = new Chart24hBSO();
                    chart24hBSO.DeleteChart24h(Id);
                    ViewChart24h();
                    break;
            }
        }
        protected void grvChart24h_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton image_del = (ImageButton)e.Row.FindControl("btn_delete");
                image_del.Attributes.Add("onclick", "return confirm('Bạn có chắc chắn muốn xóa?');");

            }
        }
        protected void linkImport_Click(object sender, EventArgs e)
        {
            ViewChart24h();

        }

        protected void grvChart24h_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvChart24h.PageIndex = e.NewPageIndex;
            ViewChart24h();
        }
    }
}