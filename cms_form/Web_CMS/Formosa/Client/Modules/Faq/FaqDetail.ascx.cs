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
    public partial class FaqDetail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = 0;
            if (!String.IsNullOrEmpty(Request["Id"]))
                int.TryParse(Request["Id"], out Id);

            if (!IsPostBack)
                ViewFaqDetail(Id);
            OtherFaqGet(Id, Language.language);

            title_cate.Text = CateNavigator();
            title_name.Text = "Hỏi đáp";
        }
        private string CateNavigator()
        {
            string url = "<a href='" + ResolveUrl("~/") + "Default.aspx' class='content_Text_Cat'>" + Resources.resource.Home + "</a>  &nbsp;<img src='" + ResolveUrl("~/") + "images/icon_arrows1.png'>&nbsp;";
            return url;
        }
        private void ViewFaqDetail(int Id)
        {
            BSO.FaqBSO faqBSO = new FaqBSO();
            ETO.Faq faq = faqBSO.GetFaqById(Id);

            LiteralQuestion.Text = faq.Question;
            LiteralAnswer.Text = faq.Answer;


        }
        private void OtherFaqGet(int Id, string lang)
        {
            FaqBSO faqBSO = new FaqBSO();
            DataTable table = faqBSO.GetFaqOther(Id, lang);
            DataListOtherFaq.DataSource = table;
            DataListOtherFaq.DataBind();

        }
    }
}