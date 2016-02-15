using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fomusa.Client
{
    public partial class Banner : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Click_LangVi(object sender, EventArgs e)
        {
            Session["Lang"] = "vi-VN";
            Page.Response.Redirect("~/Default.aspx");
        }
        protected void Click_LangEn(object sender, EventArgs e)
        {
            Session["Lang"] = "en-US";
            Page.Response.Redirect("~/Default.aspx");
        }

        //protected void HyperLink7_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect(ResolveUrl("~/") + "WebNLDC/DefaultDesktop.aspx");
        //}

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }
        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            //Response.Redirect("http://10.8.32.20:818/DefaultDesktop.aspx");
            Response.Redirect("~/Homepage.aspx");
        }
        protected void imgBtnLang_Click(object sender, ImageClickEventArgs e)
        {
            Session["Lang"] = "vi-VN";
            Response.Redirect("~/Default.aspx");
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session["Lang"] = "en-US";
            Response.Redirect("~/Default.aspx");
        }
    }
}