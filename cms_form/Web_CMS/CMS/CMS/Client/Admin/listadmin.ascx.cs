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
    public partial class listadmin : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            if (!IsPostBack)
            {
                ViewRoles();
                ViewAdmin();

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

        #region ViewRoles
        public void ViewRoles()
        {
            ddlRoles.Items.Clear();
            RolesBSO rolesBSO = new RolesBSO();
            DataTable table = rolesBSO.GetAllRoles();
            DataView dataView = new DataView(table);
            dataView.RowFilter = "Roles_Name NOT IN ('adminsys32','Administrators')";
            DataTable dataTable = dataView.ToTable();

            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToDropDown(ddlRoles, dataTable, "~~ Trong tất cả các nhóm ~~", "0", "Roles_Name", "Roles_ID", "");

        }
        #endregion

        #region ViewAdmin
        protected void ViewAdmin()
        {
            AdminBSO adminBSO = new AdminBSO();
            DataTable table = adminBSO.GetAllAdminRoles();
            DataView dataView = new DataView(table);
            //dataView.RowFilter = "Admin_Username <> 'administrator' and Admin_Username <> 'Administrator'";
            dataView.RowFilter = "Admin_Username not in ('administrator','Administrator')";
            dataView.Sort = "Admin_Username ASC";
            DataTable dataTable = dataView.ToTable();
            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToGridView(grvAdmin, dataTable);
        }
        #endregion

        protected void grvAdmin_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton image_del = (ImageButton)e.Row.FindControl("btn_delete");
                image_del.Attributes.Add("onclick", "javascript:return confirm('Bạn chắc chắn muốn xóa ??');");

            }
        }
        protected void grvAdmin_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string aId = e.CommandArgument.ToString();
            string aName = e.CommandName.ToLower();
            switch (aName)
            {
                case "user":
                    Response.Redirect("~/Admins/editadminaddroles/" + aId + "/Default.aspx");
                    break;
                case "edit":
                    Response.Redirect("~/Admins/editadmin/" + aId + "/Default.aspx");
                    break;
                case "delete":
                    AdminBSO adminBSO = new AdminBSO();
                    adminBSO.DeleteAdmin(aId);
                    ViewAdmin();
                    break;
            }
        }
        protected void grvAdmin_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        protected void btn_search_Click(object sender, EventArgs e)
        {

            int cId = Convert.ToInt32(ddlRoles.SelectedValue);
            AdminBSO adminBSO = new AdminBSO();
            //DataTable table = adminBSO.AdminGetAllRolesByID(cId);

            DataTable dataTable = new DataTable();
            commonBSO commonBSO = new commonBSO();
            DataTable table = adminBSO.GetAllAdminRoles();
            DataView dataView = new DataView(table);
            //dataView.RowFilter = "Admin_Username <> 'administrator' and Admin_Username <> 'Administrator'";

            if (cId == 0)
            {
                dataView.RowFilter = "Admin_Username not in ('administrator','Administrator')";
                dataTable = dataView.ToTable();
                commonBSO.FillToGridView(grvAdmin, dataTable);
            }
            else
            {
                AdminRolesBSO adminRolesBSO = new AdminRolesBSO();
                string strUser = adminRolesBSO.GetAdminUserName1(cId);
                if (strUser != "")
                {
                    DataTable table1 = adminBSO.GetAdminBystrName(strUser);
                    commonBSO.FillToGridView(grvAdmin, table1);
                }

            }



        }

    }
}