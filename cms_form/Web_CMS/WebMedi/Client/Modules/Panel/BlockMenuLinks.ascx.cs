using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BSO;

namespace WebMedi.Client.Modules.Panel
{
    public partial class BlockMenuLinks : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindMenuLinks();
        }

        private void BindMenuLinks()
        {
            MenuLinksBSO menulinksBSO = new MenuLinksBSO();
            DataTable table = menulinksBSO.GetHotMenuLinks(18);

            Repeater1.DataSource = table;
            Repeater1.DataBind();
        }
    }
}