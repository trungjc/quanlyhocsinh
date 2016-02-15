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
    public partial class ListChartRound : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            if (!IsPostBack)
            {
                ViewChartRound();
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
        public void ViewChartRound()
        {
            ChartRoundBSO chartRoundBSO = new ChartRoundBSO();
            DataTable table = chartRoundBSO.MixChartRound();
            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToGridView(GridView1, table);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int mID = Convert.ToInt32(e.CommandArgument.ToString().Trim());
            string cName = e.CommandName.ToLower().Trim();
            switch (cName)
            {
                case "edit":
                    Response.Redirect("~/Admin/editchartRound/" + mID + "/Default.aspx");
                    break;
                case "delete":
                    ChartRoundBSO chartRoundBSO = new ChartRoundBSO();
                    chartRoundBSO.DeleteChartRound(mID);
                    ViewChartRound();
                    break;
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton image_del = (ImageButton)e.Row.FindControl("btn_delete");
                image_del.Attributes.Add("onclick", "return confirm('Bạn có chắc chắn muốn xóa?');");
            }
        }

    }
}