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
    public partial class MainHomeChildNews : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ltrTitle.Text = "<a href=\"" + ReturnUrl(hddValue.Value) + " \">" + hddTitle.Value + "</a>";
                GetNewsbyGroup(Language.lang, hddValue.Value);
            }
        }

        private void GetNewsbyGroup(string lang, string groupCate)
        {
            var newsGroupBso = new NewsGroupBSO();
            var table = newsGroupBso.GetNewsGroupHot(lang, Convert.ToInt32(hddRecord.Value), "1",
                                                     Convert.ToInt32(groupCate));
            rptNews.DataSource = table;
            rptNews.DataBind();
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