using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSO;
using System.Data;

namespace Fomusa.Client.Modules.Panel
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

            DataList1.DataSource = table;
            DataList1.DataBind();

        }
    }
}