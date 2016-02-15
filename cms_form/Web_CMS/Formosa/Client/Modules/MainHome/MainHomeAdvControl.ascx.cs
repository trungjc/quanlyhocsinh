using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSO;
using System.Data;

namespace Fomusa.Client.Modules
{
    public partial class MainHomeAdvControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewAdv();
        }
        private void ViewAdv()
        {
            LinkBSO advBSO = new LinkBSO();
            DataTable table = advBSO.GetLinkAll();
            DataView dataView = new DataView(table);
            dataView.RowFilter = "LinkStatus = 'True' and LinkType=0";

            //  RadRotator1.RotatorType = RotatorType.AutomaticAdvance;

            RadRotator1.DataSource = dataView;
            RadRotator1.DataBind();
        }
    }
}