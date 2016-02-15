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
    public partial class editroles : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = 0;
            if (Page.RouteData.Values["Id"] != null)
                int.TryParse(Page.RouteData.Values["Id"].ToString().Replace(",", ""), out Id);
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            if (!IsPostBack)
            {
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
        protected void initControl(int ID)
        {
            if (ID > 0)
            {
                btn_add.Visible = false;
                btn_edit.Visible = true;
                hddRoles_ID.Value = Convert.ToString(ID);
                try
                {
                    RolesBSO rolesBSO = new RolesBSO();
                    IRoles roles = rolesBSO.GetRolesById(ID);
                    txtRolesName.Text = roles.RolesName;
                    ViewModules();
                    string sModules = roles.RolesModules;
                    if (!sModules.Equals(""))
                    {
                        string[] sSlip = sModules.Split(new char[] { ',' });
                        foreach (string s in sSlip)
                        {
                            foreach (ListItem items in chklist.Items)
                            {
                                if (items.Value == s)
                                    items.Selected = true;
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    error.Text = ex.Message.ToString();
                }
            }
            else
            {
                hddRoles_ID.Value = "";
                btn_add.Visible = true;
                btn_edit.Visible = false;
                ViewModules();
            }
        }
        #endregion

        #region Viewmodules
        public void ViewModules()
        {
            ModulesBSO modulesBSO = new ModulesBSO();
            DataTable table = modulesBSO.MixModules();
            DataView dataView = new DataView(table);
            // dataView.RowFilter = "Modules_Url <> 'listmodules' and Modules_Url <> 'editmodules' ";
            dataView.RowFilter = "Modules_Url not in ('listmodules','editmodules')";
            DataTable dataTable = dataView.ToTable();
            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToCheckBoxList(chklist, dataTable, "Modules_Name", "Modules_Url");


        }
        #endregion

        #region CheckedList
        public string CheckedList()
        {
            string strID = "";
            foreach (ListItem items in chklist.Items)
            {
                if (items.Selected)
                    strID += items.Value + ",";
            }
            return strID;
        }
        #endregion

        #region ReceiveHtml
        public IRoles ReceiveHtml()
        {
            IRoles roles = new IRoles();
            roles.RolesID = (hddRoles_ID.Value != "") ? Convert.ToInt32(hddRoles_ID.Value) : 0;
            roles.RolesName = (txtRolesName.Text != "") ? txtRolesName.Text.Trim() : "";
            roles.RolesModules = (CheckedList() != "") ? CheckedList() : "";

            return roles;
        }
        #endregion

        protected void btn_add_Click(object sender, EventArgs e)
        {
            RolesBSO rolesBSO = new RolesBSO();
            IRoles roles = ReceiveHtml();
            try
            {
                if (CheckedList().Equals(""))
                {
                    error.Text = "Loi : Xin hay lua chon it nhat 1 quyen";
                }
                else
                {
                    rolesBSO.CreateRoles(roles);
                    error.Text = String.Format(Resources.StringAdmin.AddNewsSuccessful);
                }

            }
            catch (Exception ex)
            {
                error.Text = ex.Message.ToString();
            }
        }

        protected void btn_edit_Click(object sender, EventArgs e)
        {
            RolesBSO rolesBSO = new RolesBSO();
            IRoles roles = ReceiveHtml();
            try
            {
                if (CheckedList().Equals(""))
                {
                    error.Text = "Loi : Xin hay lua chon it nhat 1 quyen";
                }
                else
                {
                    rolesBSO.UpdateRoles(roles);
                    error.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "Roles", roles.RolesName);
                }

            }
            catch (Exception ex)
            {
                error.Text = ex.Message.ToString();
            }
        }

    }
}