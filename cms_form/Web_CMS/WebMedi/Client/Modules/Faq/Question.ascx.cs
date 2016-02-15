using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSO;
using ETO;
namespace WebMedi.Client.Modules.Faq
{
    
    public partial class Question : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region ReceiveHtml
        private ETO.Faq ReceiveHtml()
        {
            ETO.Faq faq = new ETO.Faq();
            faq.Name = txt_TennguoiDung.Value;
            faq.Question = ttr_NoiDung.Value;
            faq.Answer = "";
            faq.PostDate = DateTime.Now;
            faq.Status = true;
            faq.Language = Language.language;
            faq.Email = txt_Email.Value;
            return faq;
        }
        #endregion
       

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, EventArgs e)
        {
            ccJoin.ValidateCaptcha(txtCapcha.Text.Trim());
            if (!ccJoin.UserValidated)
            {
                ErrorMess.Visible = true;
                txtCapcha.Focus();
                lblError.Text = "Mã bảo mật chưa chính xác";
                return;
            }
            else
            {
                try
                {
                    ETO.Faq faq = ReceiveHtml();
                    FaqBSO faqBSO = new FaqBSO();
                    faqBSO.CreateFaq(faq);
                    clientview.Text = String.Format(Resources.Resource.AddNewsSuccessful);
                    lblSucess.Visible = true;
                    lblSucess.Text = "Gửi thắc mắc thành công";
                }
                catch (Exception ex)
                {
                    clientview.Text = ex.Message.ToString();
                }
            }
        }

        protected void btn_reset_Click(object sender, EventArgs e)
        {
            txt_TennguoiDung.Value = "";
            txtCapcha.Text = "";
            txt_Email.Value = "";
            ttr_NoiDung.Value = "";
        }
    }
}