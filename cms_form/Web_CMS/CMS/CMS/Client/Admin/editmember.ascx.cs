using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ETO;
using BSO;

namespace CMS.Client.Admin
{
    public partial class editmember : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userName = "";
            if (Page.RouteData.Values["Id"] != null)
                userName = Page.RouteData.Values["Id"].ToString();
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            if (!IsPostBack)
            {
                initControl(userName);
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
        protected void initControl(string userName)
        {
            if (userName != "")
            {
                hddUsername.Value = userName;
                btn_add.Visible = false;
                btn_edit.Visible = true;
                try
                {
                    MemberBSO memberBSO = new MemberBSO();
                    Member member = memberBSO.GetMemberById(userName);

                    hddMemberID.Value = Convert.ToString(member.MemberID);
                    txtUserName.Text = member.UserName;
                    txtUserName.ReadOnly = true;
                    txtEmail.Text = member.Email;
                    txtPassword.Text = member.Password;
                    txtFullName.Text = member.FullName;
                    txtAddress.Text = member.Address;
                    txtBirth.SelectedDate = member.Birth;
                    rdbSex.SelectedValue = member.Sex.ToString();
                    txtNickYahoo.Text = member.NickYahoo;
                    txtNickSkype.Text = member.NickSkype;
                    txtPhone.Text = member.Phone;

                    hddImageThumb.Value = member.Avatar;


                    rdbList.SelectedValue = member.Actived.ToString();
                }
                catch (Exception ex)
                {
                    error.Text = ex.Message.ToString();
                }
            }
            else if (userName == "")
            {
                hddUsername.Value = "";
                btn_add.Visible = true;
                btn_edit.Visible = false;
            }
        }
        #endregion

        #region ReceiveHtml
        public Member ReceiveHtml()
        {
            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(Language.language);
            int icon_w = Convert.ToInt32(config.New_icon_w);
            int icon_h = Convert.ToInt32(config.New_icon_h);


            SecurityBSO securityBSO = new SecurityBSO();
            Member member = new Member();

            string path = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/Avatar/";
            commonBSO commonBSO = new commonBSO();
            string image_thumb = commonBSO.UploadImage(txtAvatar, path, icon_w, icon_h);

            member.MemberID = (hddMemberID.Value != "") ? Convert.ToInt32(hddMemberID.Value) : 0;
            member.UserName = (txtUserName.Text != "") ? txtUserName.Text.Trim() : hddUsername.Value;
            member.Email = (txtEmail.Text != "") ? txtEmail.Text.Trim() : "";
            member.Password = (txtPassword.Text != "") ? securityBSO.EncPwd(txtPassword.Text.Trim()) : "";
            member.FullName = (txtFullName.Text != "") ? txtFullName.Text.Trim() : "";
            member.Address = (txtAddress.Text != "") ? txtAddress.Text.Trim() : "";
            member.Phone = (txtPhone.Text != "") ? txtPhone.Text.Trim() : "";
            member.NickYahoo = (txtNickYahoo.Text != "") ? txtNickYahoo.Text.Trim() : "";
            member.NickSkype = (txtNickSkype.Text != "") ? txtNickSkype.Text.Trim() : "";
            member.Avatar = (image_thumb != "") ? image_thumb : hddImageThumb.Value;
            member.Sex = Convert.ToBoolean(rdbSex.SelectedItem.Value);
            member.Birth = txtBirth.SelectedDate.Value;


            member.Actived = Convert.ToBoolean(rdbList.SelectedItem.Value);
            return member;
        }
        #endregion

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Member member = ReceiveHtml();
            try
            {
                MemberBSO memberBSO = new MemberBSO();
                if (memberBSO.CheckExist(member.UserName))
                {
                    error.Text = String.Format(Resources.StringAdmin.CheckExist, member.UserName);
                }
                else
                {
                    memberBSO.CreateMember(member);
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
            Member member = ReceiveHtml();
            try
            {
                MemberBSO memberBSO = new MemberBSO();
                memberBSO.UpdateMember(member);
                error.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "quản trị", member.UserName);
            }
            catch (Exception ex)
            {
                error.Text = ex.Message.ToString();
            }
        }

    }
}