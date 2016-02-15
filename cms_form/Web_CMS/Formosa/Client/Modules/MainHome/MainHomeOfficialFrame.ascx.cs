using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSO;
using System.Data;
using ETO;
using CMS;

namespace Fomusa.Client.Modules.MainHome
{
    public partial class MainHomeOfficialFrame : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int groupcate = Convert.ToInt32(hddValue.Value);

            GetOfficial(groupcate);
            CateNewsGroupBSO cateNewsgroupBSO = new CateNewsGroupBSO();

            ltlTitle.Text = "<a href='" + ResolveUrl("~/") + "FullNews/" + groupcate + "/" + GetString(cateNewsgroupBSO.GetCateNewsGroupByGroupCate(groupcate).CateNewsGroupName) + "/default.aspx' >" + cateNewsgroupBSO.GetCateNewsGroupByGroupCate(groupcate).CateNewsGroupName + "</a>";

        }

        private void GetOfficial(int groupcate)
        {
            OfficialBSO officialBSO = new OfficialBSO();
            DataTable table = officialBSO.GetOfficialNews(groupcate, "1");
            GridView1.DataSource = table;
            GridView1.DataBind();

            CateNewsBSO cateNewsBSO = new CateNewsBSO();
            DataTable table1 = cateNewsBSO.getCateClientGroup(0, Language.language, Convert.ToInt32(hddValue.Value), 3);


            rptCateNews.DataSource = table1;
            rptCateNews.DataBind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            //   FullNewsGet(Language.language);
        }


        protected string GetString(object _txt)
        {
            if (_txt != null)
            {
                Utils objUtil = new Utils();
                return objUtil.Getstring(_txt.ToString());
            }
            return "";
        }
    }
}