using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fomusa.Client.Modules.Contact
{
    public partial class ContactSucceed : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ltlSucceed1.Text = "Bạn đã gửi thông tin liên hệ đến chúng tôi. Chúng tôi sẽ liên lạc lại với bạn trong thời gian sớm nhất. Cám ơn bạn đã quan tâm. Nhấn vào đây để về ";
            ltlSucceed2.Text = "Trang chủ";
            title_cate.Text = CateNavigator();
            title_name.Text = "Thông tin liên hệ";
        }

        private string CateNavigator()
        {
            string url = "<img src='" + ResolveUrl("~/") + "images/menutop_homepage.png' width='16' class='icon_home'><a href='" + ResolveUrl("~/") + "Default.aspx' class='content_Text_Cat'>" + Resources.resource.Home + "</a> ";
            return url;
        }
    }
}