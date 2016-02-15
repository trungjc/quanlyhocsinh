using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSO;

namespace Web_NLDC.Client.Modules.MainHome
{
    public partial class MainHomeLinks : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadLinks();
            }
        }

        private  void LoadLinks()
        {
            var menuLinksBSO = new MenuLinksBSO();
            var table = menuLinksBSO.GetHotMenuLinks();
            rptLinks.DataSource = table;
            rptLinks.DataBind();
        }
    }
}