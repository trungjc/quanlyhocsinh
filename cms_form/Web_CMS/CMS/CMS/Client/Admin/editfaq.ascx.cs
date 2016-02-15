using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ETO;
using BSO;

namespace CMS.Client.Admin
{
    public partial class editfaq : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = 0;
            if (Page.RouteData.Values["id"] != null)
                int.TryParse(Page.RouteData.Values["id"].ToString(), out Id);
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            if (!IsPostBack)
                initControl(Id);
        }

        #region NavigationTitle
        private void NavigationTitle(string url)
        {
            ModulesBSO modulesBSO = new ModulesBSO();
            Modules modules = modulesBSO.GetModulesByUrl(url);
            imgIcon.ImageUrl = "~/Upload/Admin_Theme/Icons/" + modules.ModulesIcon;
            litModules.Text = modules.ModulesName;
        }
        #endregion

        #region initControl
        private void initControl(int Id)
        {
            if (Id > 0)
            {
                btn_add.Visible = false;
                btn_edit.Visible = true;
                try
                {
                    FaqBSO faqBSO = new FaqBSO();
                    Faq faq = faqBSO.GetFaqById(Id);
                    hddFaqID.Value = Convert.ToString(faq.FaqID);
                    txtQuestion.Text = faq.Question;
                    txtRadAnswer.Html = faq.Answer;
                    txtRadPostDate.SelectedDate = faq.PostDate;
                    rdbStatus.SelectedValue = Convert.ToString(faq.Status);
                }
                catch (Exception ex)
                {
                    clientview.Text = ex.Message.ToString();
                }

            }
            else
            {
                txtRadPostDate.SelectedDate = DateTime.Now;
                btn_add.Visible = true;
                btn_edit.Visible = false;
            }
        }
        #endregion

        #region ReceiveHtml
        private Faq ReceiveHtml()
        {
            Faq faq = new Faq();
            faq.FaqID = (hddFaqID.Value != "") ? Convert.ToInt32(hddFaqID.Value) : 0;
            faq.Question = txtQuestion.Text;
            faq.Answer = txtRadAnswer.Html;
            faq.PostDate = txtRadPostDate.SelectedDate.Value;
            faq.Status = Convert.ToBoolean(rdbStatus.SelectedValue);
            faq.Language = Language.language;
            return faq;
        }
        #endregion

        protected void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                Faq faq = ReceiveHtml();
                FaqBSO faqBSO = new FaqBSO();
                faqBSO.CreateFaq(faq);
                clientview.Text = String.Format(Resources.StringAdmin.AddNewsSuccessful);
            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }
        protected void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                Faq faq = ReceiveHtml();
                FaqBSO faqBSO = new FaqBSO();
                faqBSO.UpdateFaq(faq);
                clientview.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "hỏi đáp", faq.Question);
            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }
    }
}