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
    public partial class listroles : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            if (!IsPostBack)
                ViewRoles();
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

        #region ViewRoles
        protected void ViewRoles()
        {
            RolesBSO rolesBSO = new RolesBSO();
            DataTable table = rolesBSO.GetAllRoles();
            DataView dataView = new DataView(table);
            dataView.RowFilter = "Roles_Name not in ('adminsys32','Administrators')";
            DataTable dataTable = dataView.ToTable();
            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToGridView(grvRoles, dataTable);

        }
        #endregion
        protected void grvRoles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rId = Convert.ToInt32(e.CommandArgument.ToString());
            string rName = e.CommandName.ToLower().Trim();
            switch (rName)
            {
                case "user":
                    Response.Redirect("~/Admin/editrolesadduser/" + rId + "/Default.aspx");
                    break;
                case "rules":
                    Response.Redirect("~/Admin/editcatenewspermission/" + rId + "/Default.aspx");
                    break;
                case "_edit":
                    Response.Redirect("~/Admin/editroles/" + rId + "/Default.aspx");
                    break;
                case "_delete":
                    RolesBSO rolesBSO = new RolesBSO();
                    rolesBSO.DeleteRoles(rId);
                    ViewRoles();
                    break;

            }
        }
        protected void grvRoles_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton image_del = (ImageButton)e.Row.FindControl("btn_Delete");
                image_del.Attributes.Add("onclick", "return confirm('Bạn có muốn chắc chắn xóa không ??')");
            }
        }

    }
}