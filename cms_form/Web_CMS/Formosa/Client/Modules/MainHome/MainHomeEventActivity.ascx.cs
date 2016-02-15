using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSO;
using System.Data;
using ETO;

namespace Fomusa.Client.Modules.MainHome
{
    public partial class MainHomeEventActivity : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                ViewAnnounce();
        }

        private void ViewAnnounce()
        {
            string strCate = CateParentIDArray(0);

            NewsGroupBSO newsGroupBSO = new NewsGroupBSO();

            DataTable table = newsGroupBSO.GetNewsGroupByCateIsHomeAll(10, strCate, "1", 5);

            GridView1.DataSource = table;
            GridView1.DataBind();


        }
        private string CateParentIDArray(int Id)
        {
            string strArrayID = Convert.ToString(Id) + ",";
            CateNewsBSO catenewsBSO = new CateNewsBSO();
            DataTable table = catenewsBSO.GetCateParentGroupAll(Id, Language.language, 5);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                strArrayID += table.Rows[i]["CateNewsID"].ToString() + ",";
            }

            return strArrayID;
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
        }
    }
}