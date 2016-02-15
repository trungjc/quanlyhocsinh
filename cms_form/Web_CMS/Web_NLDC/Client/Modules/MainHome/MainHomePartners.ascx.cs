using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSO;
using System.Data;

namespace Web_NLDC.Client.Modules.MainHome
{
    public partial class MainHomePartners : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadDoiTac();
        }
        public void LoadDoiTac()
        {
            LinkBSO linkBSO = new LinkBSO();
            DataTable table = linkBSO.GetLinkAll();
            if (table.Rows.Count > 0)
            { 
            cdcatalog.DataSource=table;
            cdcatalog.DataBind();
            }
        }
    }
}