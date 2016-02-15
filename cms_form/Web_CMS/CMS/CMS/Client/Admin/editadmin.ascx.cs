using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ETO;
using BSO;
using DAO;
using System.Data;


namespace CMS.Client.Admin
{
    public partial class editadmin : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string aName = "";
            if (Page.RouteData.Values["Id"] != null)
                aName = Page.RouteData.Values["Id"].ToString();
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            if (!IsPostBack)
            {
                initControl(aName);
                //ViewRoles();
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
        protected void initControl(string adminName)
        {
            if (adminName != "")
            {
                hddAdmin_Username.Value = adminName;
                btn_add.Visible = false;
                btn_edit.Visible = true;




                try
                {
                    AdminBSO adminBSO = new AdminBSO();
                    ETO.Admin admin = adminBSO.GetAdminById(adminName);

                    txtAdminName.Text = admin.AdminName;
                    txtAdminName.Enabled = false;
                    hddPass.Value = admin.AdminPass;


                    txtFullName.Text = admin.AdminFullName;
                    txtAdminEmail.Text = admin.AdminEmail;

                    rdbList.SelectedValue = admin.AdminActive.ToString();
                    hdd_Created.Value = admin.AdminCreated.ToString();
                    hdd_log.Value = admin.AdminLog.ToString();

                    ViewPermission();
                    string sPermission = admin.AdminPermission;
                    if (!sPermission.Equals(""))
                    {
                        string[] sSlip = sPermission.Split(new char[] { ',' });
                        foreach (string s in sSlip)
                        {
                            foreach (ListItem items in chklist.Items)
                            {
                                if (items.Value == s)
                                    items.Selected = true;
                            }
                        }
                    }

                    txtAddress.Text = admin.AdminAddress;
                    txtBirth.SelectedDate = admin.AdminBirth;
                    rdbSex.SelectedValue = admin.AdminSex.ToString();
                    txtNickYahoo.Text = admin.AdminNickYahoo;
                    txtNickSkype.Text = admin.AdminNickSkype;
                    txtPhone.Text = admin.AdminPhone;

                    rdbLoginType.SelectedValue = admin.AdminLoginType.ToString();
                    rdbLoginType.Enabled = false;


                    hddImageThumb.Value = admin.AdminAvatar;
                    uploadPreview.Src = ResolveUrl("~/Upload/Avatar/") + admin.AdminAvatar;

                }
                catch (Exception ex)
                {
                    error.Text = ex.Message.ToString();
                }
            }
            else if (adminName == "")
            {

                hddAdmin_Username.Value = "";
                hdd_Created.Value = DateTime.Now.ToString();
                hdd_log.Value = DateTime.Now.ToString();
                btn_add.Visible = true;
                btn_edit.Visible = false;

                ViewPermission();
            }
        }
        #endregion



        #region ViewPermission
        public void ViewPermission()
        {
            PermissionBSO permissionBSO = new PermissionBSO();
            DataTable table = permissionBSO.GetPermissionAll();
            DataView dataView = new DataView(table);
            dataView.Sort = "PermissionID ASC";
            DataTable dataTable = dataView.ToTable();
            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToCheckBoxList(chklist, dataTable, "PermissionName", "Value");


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
        public ETO.Admin ReceiveHtml()
        {
            ConfigBSO configBSO = new ConfigBSO();
            ETO.Config config = configBSO.GetAllConfig(Language.language);
            int icon_w = Convert.ToInt32(config.New_icon_w);
            int icon_h = Convert.ToInt32(config.New_icon_h);



            SecurityBSO securityBSO = new SecurityBSO();
            ETO.Admin admin = new ETO.Admin();

            string path = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/Avatar/";
            commonBSO commonBSO = new commonBSO();
            string image_thumb = commonBSO.UploadImage(txtAvatar, path, icon_w, icon_h);

            admin.AdminLoginType = Convert.ToBoolean(rdbLoginType.SelectedItem.Value);



            //if (rdbLoginType.SelectedItem.Value.Equals("True"))
            //{
            admin.AdminPass = (txtAdminPass.Text != "") ? securityBSO.EncPwd(txtAdminPass.Text.Trim()) : hddPass.Value;
            admin.AdminName = (txtAdminName.Text != "") ? txtAdminName.Text.Trim() : hddAdmin_Username.Value;
            admin.AdminEmail = (txtAdminEmail.Text != "") ? txtAdminEmail.Text.Trim() : "";

            //}


            // admin.RolesID = (ddlRoles.SelectedValue != "") ? Convert.ToInt32(ddlRoles.SelectedValue) : 0;
            admin.RolesID = 1;
            admin.AdminActive = Convert.ToBoolean(rdbList.SelectedItem.Value);
            admin.AdminFullName = (txtFullName.Text != "") ? txtFullName.Text.Trim() : "";

            admin.AdminCreated = Convert.ToDateTime(hdd_Created.Value);
            admin.AdminLog = Convert.ToDateTime(hdd_log.Value);
            //admin.AdminPermission = "";
            admin.AdminPermission = (CheckedList() != "") ? CheckedList() : "";

            admin.AdminAddress = (txtAddress.Text != "") ? txtAddress.Text.Trim() : "";
            admin.AdminPhone = (txtPhone.Text != "") ? txtPhone.Text.Trim() : "";
            admin.AdminNickYahoo = (txtNickYahoo.Text != "") ? txtNickYahoo.Text.Trim() : "";
            admin.AdminNickSkype = (txtNickSkype.Text != "") ? txtNickSkype.Text.Trim() : "";
            admin.AdminAvatar = (image_thumb != "") ? image_thumb : hddImageThumb.Value;
            admin.AdminSex = Convert.ToBoolean(rdbSex.SelectedItem.Value);
            admin.AdminBirth = txtBirth.SelectedDate.Value;


            return admin;
        }
        #endregion

        protected void btn_add_Click(object sender, EventArgs e)
        {
            ETO.Admin admin = ReceiveHtml();
            try
            {
                AdminBSO adminBSO = new AdminBSO();
                if (adminBSO.CheckExist(admin.AdminName))
                {
                    error.Text = String.Format(Resources.StringAdmin.CheckExist, admin.AdminName);
                }
                else
                    if (adminBSO.CheckExistEmail(admin.AdminEmail))
                    {
                        error.Text = "<font color = 'red'>Địa chỉ Email đã được đăng ký. Vui lòng đăng ký lại</font>";
                    }
                    else
                    {
                        if (CheckedList().Equals(""))
                        {
                            error.Text = "Loi : Xin hay lua chon it nhat 1 quyen";
                        }
                        else
                        {
                            adminBSO.CreateAdmin(admin);

                            RolesBSO rolesBSO = new RolesBSO();
                            IRoles roles = rolesBSO.GetRolesByName("Guest");
                            AdminRolesBSO adminRolesBSO = new AdminRolesBSO();
                            AdminRoles adminRoles = new AdminRoles();

                            adminRoles.AdminUserName = admin.AdminName;
                            adminRoles.RolesID = roles.RolesID;
                            adminRoles.UserName = Session["Admin_UserName"].ToString();
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
        protected void btn_edit_Click(object sender, EventArgs e)
        {
            ETO.Admin admin = ReceiveHtml();
            try
            {
                if (CheckedList().Equals(""))
                {
                    error.Text = "Loi : Xin hay lua chon it nhat 1 quyen";
                }
                else
                {
                    AdminBSO adminBSO = new AdminBSO();
                    adminBSO.UpdateAdmin(admin);
                    error.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "quản trị", admin.AdminName);
                }
            }
            catch (Exception ex)
            {
                error.Text = ex.Message.ToString();
            }
        }
        protected void rdbLoginType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = rdbLoginType.SelectedValue;
            //if (value.Equals("True"))
            //{
            //    divCMS.Visible = true;
            //    divDomain.Visible = false;

            //}
            //if (value.Equals("False"))
            //{
            //    divCMS.Visible = false;
            //    divDomain.Visible = true;


            //        BindToRadCombo();

            //}
        }
    }
}