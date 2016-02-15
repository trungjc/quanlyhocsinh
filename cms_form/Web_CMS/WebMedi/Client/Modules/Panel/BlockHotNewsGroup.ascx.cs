using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ETO;
using BSO;
using CMS;

namespace WebMedi.Client.Modules.Panel
{
    public partial class BlockHotNewsGroup : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int groupcate = Convert.ToInt32(hddValue.Value);
            FullHotNewsGetGroup(Language.language, groupcate);

            CateNewsGroupBSO cateGroupBSO = new CateNewsGroupBSO();
            CateNewsGroup cateGroup = cateGroupBSO.GetCateNewsGroupByGroupCate(groupcate);
            ltlTitle.Text = "<a href='" + ResolveUrl("~/") + "FullNewsg/" + groupcate + "/" + GetString(cateGroup.CateNewsGroupName) + "/default.aspx' class='block_text_title'>" + cateGroup.CateNewsGroupName + "</a>";
        }

        private void FullHotNewsGetGroup(string lang, int groupcate)
        {
            NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
            DataTable table = newsGroupBSO.GetNewsGroupHot(lang, Convert.ToInt32(hddRecord.Value), groupcate);
            rptListHotReport.DataSource = table;
            rptListHotReport.DataBind();
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