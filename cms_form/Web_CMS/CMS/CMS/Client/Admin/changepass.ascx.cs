using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ETO;
using DAO;
using BSO;

namespace CMS.Client.Admin
{
    public partial class changepass : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
                initControl();

            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
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
        protected void initControl()
        {
            string adminName = Session["Admin_Username"].ToString();
            AdminBSO adminBSO = new AdminBSO();
            ETO.Admin admin = adminBSO.GetAdminById(adminName);
            if (admin.AdminLoginType)
            {
                News_Pass.ReadOnly = false;
                Re_Pass.ReadOnly = false;
            }
            else
            {
                News_Pass.ReadOnly = true;
                Re_Pass.ReadOnly = true;
                CompareValidator1.Visible = false;
                CompareValidator2.Visible = false;
                RequiredFieldValidator1.Visible = false;
                RequiredFieldValidator2.Visible = false;
            }
            hddAdminLoginType.Value = Convert.ToString(admin.AdminLoginType);

            txtAdminUser.Text = adminName;
            txtAdminEmail.Text = admin.AdminEmail;
            hddRoles_ID.Value = admin.RolesID.ToString();
            hddActied.Value = admin.AdminActive.ToString();
            txtFullName.Text = admin.AdminFullName;
            hdd_Created.Value = admin.AdminCreated.ToString();
            hdd_log.Value = admin.AdminLog.ToString();
            hddPermission.Value = admin.AdminPermission;

            hddAddress.Value = admin.AdminAddress;
            hddBirth.Value = admin.AdminBirth.ToString();
            hddSex.Value = admin.AdminSex.ToString();
            hddNickYahoo.Value = admin.AdminNickYahoo;
            hddNickSkype.Value = admin.AdminNickSkype;
            hddPhone.Value = admin.AdminPhone;
            hddImageThumb.Value = admin.AdminAvatar;



        }

        #region ReceiveHtml
        protected ETO.Admin ReceiveHtml()
        {
            SecurityBSO securityBSO = new SecurityBSO();
            ETO.Admin admin = new ETO.Admin();
            admin.AdminName = txtAdminUser.Text;
            admin.AdminEmail = txtAdminEmail.Text;
            admin.AdminLoginType = Convert.ToBoolean(hddAdminLoginType.Value);
            if (admin.AdminLoginType)
            {
                admin.AdminPass = securityBSO.EncPwd(News_Pass.Text.Trim());
            }
            else
            {
                admin.AdminPass = "";
            }
            admin.AdminPass = securityBSO.EncPwd(News_Pass.Text.Trim());
            admin.RolesID = Convert.ToInt32(hddRoles_ID.Value);
            admin.AdminActive = Convert.ToBoolean(hddActied.Value);

            admin.AdminFullName = (txtFullName.Text != "") ? txtFullName.Text.Trim() : "";

            admin.AdminCreated = Convert.ToDateTime(hdd_Created.Value);
            admin.AdminLog = Convert.ToDateTime(hdd_log.Value);
            admin.AdminPermission = (hddPermission.Value != "") ? hddPermission.Value : "";

            admin.AdminAddress = hddAddress.Value;
            admin.AdminPhone = hddPhone.Value;
            admin.AdminNickYahoo = hddNickYahoo.Value;
            admin.AdminNickSkype = hddNickSkype.Value;
            admin.AdminAvatar = hddImageThumb.Value;
            admin.AdminSex = Convert.ToBoolean(hddSex.Value);
            admin.AdminBirth = Convert.ToDateTime(hddBirth.Value);



            return admin;
        }
        #endregion

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                ETO.Admin admin = ReceiveHtml();
                AdminBSO adminBSO = new AdminBSO();
                adminBSO.UpdateAdmin(admin);
                clientview.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "thay đổi quản trị", admin.AdminName);
                Response.Redirect("~/Admin/changepasssucc/Default.aspx");
            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }
    }
}