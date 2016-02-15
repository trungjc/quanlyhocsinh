using System;

namespace Web_NLDC
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                form1.Action = Request.RawUrl;
            }
        }
    }
}