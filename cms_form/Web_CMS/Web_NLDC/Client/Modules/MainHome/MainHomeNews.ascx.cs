using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSO;
using CMS;
using ETO;

namespace Web_NLDC.Client.Modules.MainHome
{
    public partial class MainHomeNews : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadNews(Language.lang);
            }
        }

        protected void LoadNews(string lang)
        {
            var newsBso = new NewsGroupBSO();
            var dt = newsBso.NewsGroupMainHomeModule(lang);
            //if (dt.Rows.Count % 3 == 0)
            //{
                rptNews.DataSource = dt;
                rptNews.DataBind();
            //}
        }

        public string ReturnUrl(string cateNewsGroup)
        {
            var cateNewsGroupBso = new CateNewsGroupBSO();
            var cateGroup = cateNewsGroupBso.GetCateNewsGroupByGroupCate(Convert.ToInt32(cateNewsGroup));
            var url = "";
            if (cateGroup.IsUrl)
                url = cateGroup.Url;
            else
            {
                url = cateGroup.IsPage ? Page.ResolveUrl("FullPagesg/" + cateNewsGroup + "/" + GetString(cateGroup.CateNewsGroupName) + "/default.aspx") : Page.ResolveUrl("FullNewsg/" + cateNewsGroup + "/" + GetString(cateGroup.CateNewsGroupName) + "/default.aspx");
            }
            return url;
        }

        protected string GetString(object txt)
        {
            if (txt != null)
            {
                var objUtil = new Utils();
                return objUtil.Getstring(txt.ToString());
            }
            return "";
        }
    }
}