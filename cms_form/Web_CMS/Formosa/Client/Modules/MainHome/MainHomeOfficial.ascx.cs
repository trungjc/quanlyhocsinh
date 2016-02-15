using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSO;
using ETO;
using System.Data;

namespace Fomusa.Client.Modules.MainHome
{
    public partial class MainHomeOfficial : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FullNewsGet(Language.language);
        }
        private void FullNewsGet(string lang)
        {
            OfficialBSO officialBSO = new OfficialBSO();
            DataTable table = officialBSO.GetOfficialNews(10);
            GridView1.DataSource = table;
            GridView1.DataBind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            //   FullNewsGet(Language.language);
        }
    }
}