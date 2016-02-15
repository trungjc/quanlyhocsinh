using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Client.Admin
{
    public partial class Header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin_Username"] != null)
            {
                lblLogin.Text = "Quản trị";
            }
            else
            {
                lblLogin.Text = "Đăng nhập";
            }

            if (Page.RouteData.Values["dll"] != null)
            {
                if (Page.RouteData.Values["dll"].Equals("login"))
                    div_welcome.Visible = false;
                else
                    div_welcome.Visible = true;
            }
            else
                div_welcome.Visible = false;
        }
    }
}