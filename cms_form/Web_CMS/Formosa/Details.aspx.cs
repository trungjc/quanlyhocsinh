using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS;

namespace Fomusa
{
    public partial class Details : System.Web.UI.Page
    {
        string url;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["url"] != null)
            {
                url = Request.QueryString["url"].ToString();
                string content = Utils.GetHTML(url);
                LoadContent(content);
                Page.Title = Request.QueryString["url"].Substring(37);
            }

            title_cate.Text = "<a href='" + ResolveUrl("~/") + "Default.aspx' class='content_Text_Cat'>" + Resources.resource.Home + "</a> &nbsp;<img src='" + ResolveUrl("~/") + "images/icon_arrows1.png'>&nbsp; ";

            if (Request["go"] != null)
            {
                switch (Request["go"].ToString())
                {
                    case "8":
                        title_name.Text = "<a href='" + ResolveUrl("~/") + "FullNews/8/Thi-truong-dien/default.aspx' class='content_Text_Cat'>Thị trường điện</a>";
                        break;
                    case "0":
                        title_name.Text = "<a href='" + ResolveUrl("~/") + "FullNews/0/tin-nganh-dien/default.aspx' class='content_Text_Cat'>Tin ngành điện</a>";
                        break;
                }
            }
        }

        public void LoadContent(string content)
        {
            int t = 0;
            int b = 0;
            t = content.IndexOf("<div class=\"content_news_home_1\">");
            if (t > 0)
            {
                content = content.Substring(t + 33, content.Length - t - 34);
            }
            b = content.LastIndexOf("<!-- End_Module_454 -->");
            content = content.Substring(0, b - 29);
            content = content + "}</style>";
            content = content.Replace("/Portals", "http://icon.com.vn/Portals");
            content = content.Replace("/DesktopModules", "http://icon.com.vn/DesktopModules");
            if (Request["go"] != null)
                content = content.Replace("<a href=\"/vn-s83-", "<a href=\"Details.aspx?go=" + Request["go"].ToString() + "&url=http://icon.com.vn/vn-s83-");
            else
                content = content.Replace("<a href=\"/vn-s83-", "<a href=\"Details.aspx?url=http://icon.com.vn/vn-s83-");
            content = content.Replace("<a href=\"#\">", "");
            Label1.Text = content;
        }
    }
}