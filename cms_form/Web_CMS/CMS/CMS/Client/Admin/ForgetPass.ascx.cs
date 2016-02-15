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
    public partial class ForgetPass : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                labMassege.Text = "";
        }
        protected void btn_GetPass_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            AdminBSO adminBSO = new AdminBSO();
            DataTable table = adminBSO.GetAllAdmin();

            DataView dataView = new DataView(table);
            dataView.RowFilter = "Admin_Email = '" + email + "'";
            if (dataView.Count > 0)
            {
                SecurityBSO securityBSO = new SecurityBSO();
                DataTable dataTable = dataView.ToTable();
                string oldpass = dataTable.Rows[0]["Admin_Password"].ToString();
                string newpass = securityBSO.DecPwd(oldpass);

                ConfigBSO configBSO = new ConfigBSO();
                Config config = configBSO.GetAllConfig(Language.language);

                MailBSO mailBSO = new MailBSO();
                mailBSO.EmailFrom = config.Email_from;

                string subject = "Web Support EVNIT - Phục hồi lại mật khẩu đăng nhập hệ thống";
                string body = "Chào bạn :  " + dataTable.Rows[0]["Admin_FullName"].ToString() + "<br>";
                body += "Tài khoản Email đăng nhập của bạn :  " + dataTable.Rows[0]["Admin_Email"].ToString() + "<br>";
                body += "Mật khẩu đăng nhập hệ thống của bạn :  " + newpass;

                if (mailBSO.SendMail(email, subject, body) == true)
                    labMassege.Text = "Mật khẩu đăng nhập đã được gửi tới Email của bạn !";
                else
                    labMassege.Text = "Hệ thống không thể gửi Email";
            }
            else
            {
                labMassege.Text = "Xin lỗi! Chúng tôi không tìm thấy tài khoản của bạn trong hệ thống.";
            }
        }

    }
}