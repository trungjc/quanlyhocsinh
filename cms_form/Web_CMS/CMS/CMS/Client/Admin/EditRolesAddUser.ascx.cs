using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ETO;
using BSO;
using Telerik.Web.UI;
using System.Data;

namespace CMS.Client.Admin
{
    public partial class EditRolesAddUser : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = 0;
            if (Page.RouteData.Values["Id"] != null)
                int.TryParse(Page.RouteData.Values["Id"].ToString().Replace(",", ""), out Id);
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());

            hddRoles.Value = Convert.ToString(Id);

            if (!IsPostBack)
            {
                RolesBSO rolesBSO = new RolesBSO();
                IRoles roles = rolesBSO.GetRolesById(Id);
                ltlTitle.Text = roles.RolesName;

                initControl(Id);
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

        #region initControl
        protected void initControl(int Id)
        {
            if (Id > 0)
            {
                ViewCateAll();
                VierUserRoles();
            }
            else
            {
                error.Text = "Lỗi: Lựa chọn Nhóm người dùng trước khi thêm tài khoản";
            }
        }
        #endregion

        #region ViewCateAll
        private void ViewCateAll()
        {
            AdminBSO adminBSO = new AdminBSO();
            DataTable datatable = adminBSO.GetAllAdmin();
            DataView dataView = new DataView(datatable);

            dataView.RowFilter = "Admin_Username not in ('administrator','Administrator')";
            dataView.Sort = "Admin_UserName Asc";
            DataTable table = dataView.ToTable();

            RadGrid1.DataSource = table;
            RadGrid1.DataBind();

        }
        #endregion

        protected void btn_add_Click(object sender, EventArgs e)
        {
            DataTable datatable = GetUserGrid();

            try
            {
                AdminRolesBSO adminRolesBSO = new AdminRolesBSO();
                DataTable table1 = adminRolesBSO.GetAdminRolesByRoles(Convert.ToInt32(hddRoles.Value));

                if (table1.Rows.Count > 0)
                    adminRolesBSO.DeleteAdminRolesRoles(Convert.ToInt32(hddRoles.Value));

                AdminRoles adminRoles = new AdminRoles();

                if (datatable.Rows.Count > 0)
                {
                    foreach (DataRow subrow in datatable.Rows)
                    {
                        adminRoles.AdminUserName = subrow["Admin_UserName"].ToString();
                        adminRoles.RolesID = Convert.ToInt32(hddRoles.Value);
                        adminRoles.UserName = Session["Admin_UserName"].ToString();
                        //adminRoles.Permission = subrow["Permission"].ToString();
                        adminRoles.Permission = "";
                        adminRoles.Created = DateTime.Now;

                        adminRolesBSO.CreateAdminRoles(adminRoles);
                        error.Text = String.Format(Resources.StringAdmin.AddNewsSuccessful);

                    }


                }


            }
            catch (Exception ex)
            {
                error.Text = ex.Message.ToString();
            }
        }

        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {

        }

        #region VierUserRoles
        private void VierUserRoles()
        {
            //PermissionBSO permissionBSO = new PermissionBSO();
            //DataTable table = permissionBSO.GetPermissionAll();
            //DataView dataView = new DataView(table);
            //dataView.Sort = "PermissionID ASC";
            //DataTable dataTable = dataView.ToTable();
            //commonBSO commonBSO = new commonBSO();

            AdminRolesBSO adminRolesBSO = new AdminRolesBSO();
            AdminRoles adminRoles = new AdminRoles();


            foreach (GridDataItem dataItem in RadGrid1.MasterTableView.Items)
            {
                //CheckBoxList chklist = (CheckBoxList)dataItem.FindControl("chklist");
                CheckBox chkId = (CheckBox)dataItem.FindControl("chkId");

                //commonBSO.FillToCheckBoxList(chklist, dataTable, "PermissionName", "Value");

                if (adminRolesBSO.CheckExitRolesUser(Convert.ToInt32(hddRoles.Value), dataItem["Admin_UserName"].Text))
                {
                    //Permission
                    //adminRoles = adminRolesBSO.GetAdminRoles(Convert.ToInt32(hddRoles.Value), dataItem["Admin_UserName"].Text);

                    //if (adminRoles != null)
                    //{
                    //    string sPermission = adminRoles.Permission;
                    //    if (!sPermission.Equals(""))
                    //    {
                    //        string[] sSlip = sPermission.Split(new char[] { ',' });
                    //        foreach (string s in sSlip)
                    //        {
                    //            foreach (ListItem items in chklist.Items)
                    //            {
                    //                if (items.Value == s)
                    //                    items.Selected = true;
                    //            }
                    //        }
                    //    }
                    //}

                    //Admin_ID
                    chkId.Checked = true;
                }

            }


        }
        #endregion

        #region GetUserGrid
        private DataTable GetUserGrid()
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("Admin_UserName");
            //datatable.Columns.Add("Permission");

            foreach (GridDataItem dataItem in RadGrid1.MasterTableView.Items)
            {
                CheckBox chkId = (CheckBox)dataItem.FindControl("chkId");
                //CheckBoxList chklist = (CheckBoxList)dataItem.FindControl("chklist");

                //string strID = "";
                //foreach (ListItem items in chklist.Items)
                //{
                //    if (items.Selected)
                //        strID += items.Value + ",";
                //}

                if (chkId.Checked)
                {
                    DataRow datarow = datatable.NewRow();
                    datarow["Admin_UserName"] = dataItem["Admin_UserName"].Text;
                    //datarow["Permission"] = strID;

                    datatable.Rows.Add(datarow);
                }

            }

            return datatable;
        }

        #endregion

    }
}