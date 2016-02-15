using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ETO;
using BSO;
using System.Data;

namespace Fomusa.Client.Modules.Faq
{
    public partial class Faq : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewFaq(Language.language);
            title_cate.Text = CateNavigator();
        }
        private string CateNavigator()
        {
            string url = "<a href='" + ResolveUrl("~/") + "Default.aspx' class='content_Text_Cat'>" + Resources.resource.Home + "</a> &nbsp;<img src='" + ResolveUrl("~/") + "images/icon_arrows1.png'>&nbsp;";
            return url;
        }
        private void ViewFaq(string lang)
        {
            FaqBSO faqBSO = new FaqBSO();
            DataTable table = faqBSO.GetFaqAll(lang);
            DataListFaq.DataSource = table;
            DataListFaq.DataBind();
        }

        public string Question { get; set; }
    }
}