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
    public partial class Login : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie cookie = Request.Cookies["UserInfor_ES"];
                if (cookie != null && cookie["UserName"] != null && cookie["UserName"].Trim() != string.Empty)
                {
                    Response.Redirect("~/Admin/home/default.aspx");
                }
            }
        }

        #region CheckLogin
        public bool CheckLogin()
        {
            AdminBSO adminBSO = new AdminBSO();
            return adminBSO.CheckLoginAdmin(txtAdminUser.Text.Trim(), txtAdminPass.Text.Trim());
        }
        #endregion

        #region CheckUserName
        public bool CheckUserName()
        {
            AdminBSO adminBSO = new AdminBSO();
            return adminBSO.CheckUserName(txtAdminUser.Text.Trim());
        }
        #endregion

        protected void btn_sumit1_Click(object sender, ImageClickEventArgs e)
        {
            if (!Convert.ToBoolean(rdbCheck.SelectedValue))
            {
                if (CheckUserName() == true)
                {
                    AdminBSO adminBSO = new AdminBSO();
                    ETO.Admin admin = adminBSO.GetAdminById(txtAdminUser.Text.Trim());


                    if (CheckLogin() == true)
                    {

                        Session["Admin_Username"] = txtAdminUser.Text.Trim();


                        HttpCookie cookie = Request.Cookies["UserInfor_ES"];
                        if (cookie == null)
                        {
                            cookie = new HttpCookie("UserInfor_ES");
                            cookie["UserName"] = txtAdminUser.Text.Trim();
                            //cookie["Password"]= MD5.Create(txtAdminPass.Text);
                            cookie.Expires = DateTime.Now.AddDays(1);
                            Response.Cookies.Add(cookie);
                            adminBSO.UpdateAdminLog(cookie["UserName"].ToString(), DateTime.Now);
                            Response.Redirect("~/Admin/home/default.aspx");
                        }
                        else
                        {

                            adminBSO.UpdateAdminLog(cookie["UserName"].ToString(), DateTime.Now);
                            Response.Redirect("~/Admin/home/default.aspx");
                        }
                    }
                    else
                    {
                        Tool.Message(this.Page, "Lỗi: Tài khoản hoặc mật khẩu không đúng! Xin vui lòng nhập lại");
                        return;
                    }
                }
                else
                {
                    Tool.Message(this.Page, "Lỗi: Tài khoản không tồn tại! Xin vui lòng nhập lại");
                    return;

                }
            }
        }
    }
}