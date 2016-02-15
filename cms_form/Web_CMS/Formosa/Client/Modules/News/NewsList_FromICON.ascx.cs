using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS;

namespace Fomusa.Client.Modules.News
{
    public partial class NewsList_FromICON : System.Web.UI.UserControl
    {
        string url;

        #region Properties

        /// <summary>
        /// Get Go
        /// </summary>
        private string Go
        {
            get
            {
                if (Page.RouteData.Values["go"] != null)
                    return Page.RouteData.Values["go"].ToString().ToLower();
                else
                    return "";
            }
        }

        private string g
        {
            get
            {
                if (Page.RouteData.Values["g"] != null)
                    return Page.RouteData.Values["g"].ToString();
                else
                    return "";
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Go.ToString())
            {
                case "fullnews":
                    switch (g.ToString())
                    {
                        case "8":
                            LoadNews_ThiTruongDien();
                            break;
                        case "0":
                            LoadNews_TinNganhDien();
                            break;
                    }
                    break;
            }
        }

        protected void LoadNews_ThiTruongDien()
        {
            if (Request.QueryString["url"] == null)
            {
                url = "http://icon.com.vn/vn-83-638/Thi-truong-dien.aspx";
            }
            else
            {
                url = Request.QueryString["url"].ToString();
            }
            title_cate.Text = "<a href='" + ResolveUrl("~/") + "Default.aspx' class='content_Text_Cat'>" + Resources.resource.Home + "</a> &nbsp;<img src='" + ResolveUrl("~/") + "images/icon_arrows1.png'>&nbsp;";
            title_name.Text = "Thị trường điện";
            Page.Title = "Thị trường điện";
            Display(url);
        }

        protected void LoadNews_TinNganhDien()
        {
            if (Request.QueryString["url"] == null)
            {
                url = "http://icon.com.vn/vn-83-641/Tin-tuc.aspx";
            }
            else
            {
                url = Request.QueryString["url"].ToString();
            }
            title_cate.Text = "<a href='" + ResolveUrl("~/") + "Default.aspx' class='content_Text_Cat'>" + Resources.resource.Home + "</a> &nbsp;<img src='" + ResolveUrl("~/") + "images/icon_arrows1.png'>&nbsp;";
            title_name.Text = "Tin ngành điện";
            Page.Title = "Tin ngành điện";
            Display(url);
        }

        public void Display(string Url)
        {
            try
            {
                string content = Utils.GetHTML(url);
                int t = 0;
                int b = 0;
                t = content.IndexOf("<div id=\"dnn_ContentPane\" class=\"news_list_left_v2\">");
                if (t > 0)
                {
                    content = content.Substring(t + 52, content.Length - t - 53);
                }
                b = content.LastIndexOf("id=\"dnn_zone_contentmain_right\" class=\"news_list_right\"");
                content = content.Substring(0, b - 5);
                content = content.Replace("/DesktopModules", "http://icon.com.vn/DesktopModules");
                //xử lý khi click vào xem chi tiết
                //content = content.Replace("<a href=\"/vn-s83-", "<a href=\"" + ResolveUrl("~/") + "News/8/500/HB?url=http://icon.com.vn/vn-s83-");
                //xử lý khi click vào chuyển trang
                //content = content.Replace("<a href=\'?p", "<a href=\'Index.aspx?url=http://icon.com.vn/vn-83-638/Thi-truong-dien.aspx?p");

                content = content.Replace("<a href=\"/vn-s83-", "<a href=\"" + ResolveUrl("~/") + "Details.aspx?go=" + g.ToString() + "&url=http://icon.com.vn/vn-s83-");

                content = content.Replace("<a href=\'?p", "<a href=\'Details.aspx?go=" + g.ToString() + "url=http://icon.com.vn/vn-83-638/Thi-truong-dien.aspx?p");
                Label1.Text = content;
            }
            catch (Exception)
            {
            }
        }
    }
}