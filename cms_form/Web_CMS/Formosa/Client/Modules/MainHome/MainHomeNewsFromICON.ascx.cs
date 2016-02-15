using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Text;

namespace Fomusa.Client.Modules.MainHome
{
    public partial class MainHomeNewsFromICON : System.Web.UI.UserControl
    {
        string url;
        string Content;
        protected void Page_Load(object sender, EventArgs e)
        {
            url = "http://icon.com.vn/";
            Content = GetHTML(url);
            Display(Content);
        }

        protected string GetHTML(string url)
        {
            try
            {
                if (string.IsNullOrEmpty(url))
                    return "";
                string html = "";
                //Gửi 1 yêu cầu truy cập vào url truyền vào
                HttpWebRequest rquest = (HttpWebRequest)HttpWebRequest.Create(url);
                //Tạo một đối tượng trả về
                HttpWebResponse respone = (HttpWebResponse)rquest.GetResponse();
                Stream responeStream = respone.GetResponseStream();
                StreamReader reader = new StreamReader(responeStream, Encoding.UTF8);
                html = reader.ReadToEnd();
                respone.Close();
                reader.Close();
                return html;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        protected void Display(string content)
        {
            try
            {
                int top = 0;
                int bottom = 0;
                top = content.IndexOf("<!-- Start_Module_486 -->");
                if (top > 0)
                {
                    content = content.Substring(top + 25, content.Length - top - 26);
                }
                bottom = content.LastIndexOf("<!-- End_Module_486 -->");
                content = content.Substring(0, bottom - 25);
                content = content + "</div></div>";
                content = content.Replace("/DesktopModules", "http://icon.com.vn/DesktopModules");
                //content = content.Replace("<a href=\"/vn-s83-", "<a href=\"News/8/500/HB?url=http://icon.com.vn/vn-s83-");
                //content = content.Replace("<a href=\"\">", "<a href=\"News/8/500/HB?url=http://icon.com.vn/vn-83-638/Thi-truong-dien.aspx\">");
                content = content.Replace("<a href=\"/vn-s83-", "<a href=\"Details.aspx?url=http://icon.com.vn/vn-s83-");
                content = content.Replace("<a href=\"\">", "<a href=\"Details.aspx?url=http://icon.com.vn/vn-83-638/Thi-truong-dien.aspx\">");

                Label1.Text = content;
            }
            catch (Exception)
            {
            }
        }
    }
}