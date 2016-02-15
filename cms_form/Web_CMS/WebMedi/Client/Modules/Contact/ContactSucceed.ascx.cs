using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebMedi.Client.Modules.Contact
{
    public partial class ContactSucceed : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ltlSucceed1.Text = Resources.Resource.ContactSuccess;
            ltlSucceed2.Text = Resources.Resource.Home;
            title_cate.Text = "<a href='" + ResolveUrl("~/") + "Home' class='content_Text_Cat'>" + Resources.Resource.Home + "</a>";
            title_name.Text = Resources.Resource.register_contact;
        }
    }
}