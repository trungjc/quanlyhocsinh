using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ETO;
using BSO;
using DAO;
using Telerik.Web.UI;
using System.Data;

namespace CMS.Client.Admin
{
    public partial class EditCateNewsPermission : System.Web.UI.UserControl
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
                VierPermissionID();
            }
            else
            {
                error.Text = "Lỗi: Lựa chọn Nhóm người dùng trước khi phân quyền";
            }
        }
        #endregion

        #region ViewCateAll
        private void ViewCateAll()
        {
            CateNewsBSO catenewsBSO = new CateNewsBSO();
            DataTable table = catenewsBSO.GetCateNewsName(Language.language, Session["Admin_UserName"].ToString());
            RadGrid1.DataSource = table;
            RadGrid1.DataBind();
        }
        #endregion

        protected void btn_add_Click(object sender, EventArgs e)
        {
            DataTable datatable = CateNewsID();

            try
            {
                CateNewsPermissionBSO catenewPermissionBSO = new CateNewsPermissionBSO();

                DataTable table1 = catenewPermissionBSO.GetCateNewsPermissionByRoles(Convert.ToInt32(hddRoles.Value));

                if (table1.Rows.Count > 0)
                    catenewPermissionBSO.DeleteCateNewsPermissionRoles(Convert.ToInt32(hddRoles.Value));

                CateNewsPermission cateNewsPermission = new CateNewsPermission();

                if (datatable.Rows.Count > 0)
                {
                    foreach (DataRow subrow in datatable.Rows)
                    {
                        cateNewsPermission.CateNewsID = Convert.ToInt32(subrow["CateNewsID"].ToString());
                        cateNewsPermission.RolesID = Convert.ToInt32(hddRoles.Value);
                        //      cateNewsPermission.Permission = subrow["Permission"].ToString();
                        cateNewsPermission.Permission = "";
                        cateNewsPermission.UserName = Session["Admin_UserName"].ToString();
                        cateNewsPermission.Created = DateTime.Now;

                        catenewPermissionBSO.CreateCateNewsPermission(cateNewsPermission);
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

        #region VierPermissionID
        private void VierPermissionID()
        {
            //PermissionBSO permissionBSO = new PermissionBSO();
            //DataTable table = permissionBSO.GetPermissionAll();
            //DataView dataView = new DataView(table);
            //dataView.Sort = "PermissionID ASC";
            //DataTable dataTable = dataView.ToTable();
            //commonBSO commonBSO = new commonBSO();

            CateNewsPermissionBSO cateNewsPermissionBSO = new CateNewsPermissionBSO();
            CateNewsPermission cateNewsPermission = new CateNewsPermission();

            foreach (GridDataItem dataItem in RadGrid1.MasterTableView.Items)
            {
                //CheckBoxList chklist = (CheckBoxList)dataItem.FindControl("chklist");
                CheckBox chkId = (CheckBox)dataItem.FindControl("chkId");

                //commonBSO.FillToCheckBoxList(chklist, dataTable, "PermissionName", "Value");
                int cateNewsId = 0;
                Int32.TryParse(dataItem["CateNewsID"].Text, out cateNewsId);
                if (cateNewsId != 0)
                    if (cateNewsPermissionBSO.CheckExitPermission(Convert.ToInt32(hddRoles.Value), Convert.ToInt32(dataItem["CateNewsID"].Text)))
                    {

                        //Permission
                        //cateNewsPermission = cateNewsPermissionBSO.GetCateNewsPermission(Convert.ToInt32(hddRoles.Value), Convert.ToInt32(dataItem["CateNewsID"].Text));

                        //if (cateNewsPermission != null)
                        //{
                        //    string sPermission = cateNewsPermission.Permission;
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

                        //CateID
                        chkId.Checked = true;
                    }

            }
        }
        #endregion

        #region CateNewsID
        private DataTable CateNewsID()
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("CateNewsID");
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
                    datarow["CateNewsID"] = dataItem["CateNewsID"].Text;
                    //datarow["Permission"] = strID;

                    datatable.Rows.Add(datarow);
                }

            }

            return datatable;
        }

        #endregion
    }
}