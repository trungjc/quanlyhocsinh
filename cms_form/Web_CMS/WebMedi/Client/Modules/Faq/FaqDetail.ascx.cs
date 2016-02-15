using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ETO;
using BSO;

namespace WebMedi.Client.Modules.Faq
{

    public partial class FaqDetail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = 0;
            if (Page.RouteData.Values["Id"].ToString() !=null)
                int.TryParse(Page.RouteData.Values["Id"].ToString(), out Id);

            if (!IsPostBack)
                ViewFaqDetail(Id);
            OtherFaqGet(Id, Language.language);

            title_cate.Text = CateNavigator();
            title_name.Text = "Hỏi đáp";
        }
        private string CateNavigator()
        {
            string url = "<a href='" + ResolveUrl("~/") + "Default.aspx' class='content_Text_Cat'>"+Resources.Resource.Home+"</a>  &nbsp;>&nbsp;";
            return url;
        }
        private void ViewFaqDetail(int Id)
        {
            FaqBSO faqBSO = new FaqBSO();
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