using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Client.Admin
{
    public partial class BlockWelCome : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            welcomAdmin.Text = "";
            if (!IsPostBack)
            {
                HttpCookie cookie = Request.Cookies["UserInfor_ES"];
                if (cookie != null && cookie["UserName"] != null && cookie["UserName"].Trim() != string.Empty)
                {
                    welcomAdmin.Text = cookie["UserName"].Trim();
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            HttpCookie cookie = HttpContext.Current.Request.Cookies["UserInfor_ES"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-10);
                cookie.Value = "";
                HttpContext.Current.Response.Cookies.Add(cookie);
            }

            Session.RemoveAll();
            Session.Abandon();

            Response.Redirect("~/Admin/login");
        }
    }
}