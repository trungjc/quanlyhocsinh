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
    public partial class config : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ViewState["CauHinh_Viet"] = 1;
            initControl();
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
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
        protected void initControl()
        {

            ConfigBSO configBSO = new ConfigBSO();
            int Ngon_Ngu = Convert.ToInt32(ViewState["CauHinh_Viet"]);
            if (Ngon_Ngu == 1)
            {
                Config config = configBSO.GetAllConfig(Language.language);
                txttitleweb.Text = config.Titleweb;
                txtgoogle.Text = config.Google;
                txtIntro_desc.Html = config.Intro_desc;
                txtIntroduction.Html = config.Introduction;
                txtInfocompany.Html = config.Infocompany;
                new_icon_w.Text = config.New_icon_w;
                new_icon_h.Text = config.New_icon_h;
                new_thumb_w.Text = config.New_thumb_w;
                new_thumb_h.Text = config.New_thumb_h;
                new_large_w.Text = config.New_large_w;
                new_large_h.Text = config.New_large_h;

                product_icon_w.Text = config.Product_icon_w;
                product_icon_h.Text = config.Product_icon_h;
                product_thumb_w.Text = config.Product_thumb_w;
                product_thumb_h.Text = config.Product_thumb_h;
                product_large_w.Text = config.Product_large_w;
                product_large_h.Text = config.Product_large_h;

                txtNoproduct.Text = config.ProductNo;
                txtNoPage.Text = config.ProductNoPage;
                txtCurrency.Text = config.Currency;

                rdblistClose.SelectedItem.Value = config.Status.ToString();
                txtCloseComment.Text = config.Closecomment;

                txtRadSupport.Html = config.Support;
                txtRadContact.Html = config.Contact;

                txtEmailFrom.Text = config.Email_from;
                txtEmailTo.Text = config.Email_to;

                RadCounter.Html = config.Counter;
                RadInfo1.Html = config.Info1;
                RadInfo2.Html = config.Info2;

                txtWebName.Text = config.WebName;
                txtWebServerIP.Text = config.WebServerIP;
                txtWebDomain.Text = config.WebDomain;
                txtWebMailServer.Text = config.WebMailServer;

                rdbPopup.SelectedValue = Convert.ToString(config.IsPopup);
                radPopup.Html = config.Popup;
                radPopup2.Html = config.Popup2;
            }
            else
            {
                Config config = configBSO.GetAllConfig(Language.language_Eng);
                txttitleweb.Text = config.Titleweb;
                txtgoogle.Text = config.Google;
                txtIntro_desc.Html = config.Intro_desc;
                txtIntroduction.Html = config.Introduction;
                txtInfocompany.Html = config.Infocompany;
                new_icon_w.Text = config.New_icon_w;
                new_icon_h.Text = config.New_icon_h;
                new_thumb_w.Text = config.New_thumb_w;
                new_thumb_h.Text = config.New_thumb_h;
                new_large_w.Text = config.New_large_w;
                new_large_h.Text = config.New_large_h;

                product_icon_w.Text = config.Product_icon_w;
                product_icon_h.Text = config.Product_icon_h;
                product_thumb_w.Text = config.Product_thumb_w;
                product_thumb_h.Text = config.Product_thumb_h;
                product_large_w.Text = config.Product_large_w;
                product_large_h.Text = config.Product_large_h;

                txtNoproduct.Text = config.ProductNo;
                txtNoPage.Text = config.ProductNoPage;
                txtCurrency.Text = config.Currency;

                rdblistClose.SelectedItem.Value = config.Status.ToString();
                txtCloseComment.Text = config.Closecomment;

                txtRadSupport.Html = config.Support;
                txtRadContact.Html = config.Contact;

                txtEmailFrom.Text = config.Email_from;
                txtEmailTo.Text = config.Email_to;

                RadCounter.Html = config.Counter;
                RadInfo1.Html = config.Info1;
                RadInfo2.Html = config.Info2;

                txtWebName.Text = config.WebName;
                txtWebServerIP.Text = config.WebServerIP;
                txtWebDomain.Text = config.WebDomain;
                txtWebMailServer.Text = config.WebMailServer;

                rdbPopup.SelectedValue = Convert.ToString(config.IsPopup);
                radPopup.Html = config.Popup;
                radPopup2.Html = config.Popup2;
            }




        }
        #endregion

        #region ReceiveHtml
        protected Config ReceiveHtml()
        {
            Config config = new Config();
            int Ngon_Ngu = Convert.ToInt32(ViewState["CauHinh_Viet"]);
            if (Ngon_Ngu == 1)
            {
                config.Language = Language.language;
            }
            else
            {
                config.Language = Language.language_Eng;
            }


            config.Titleweb = txttitleweb.Text;
            config.Google = txtgoogle.Text;
            config.Intro_desc = txtIntro_desc.Html;
            config.Introduction = txtIntroduction.Html;
            config.Infocompany = txtInfocompany.Html;
            config.New_icon_w = new_icon_w.Text;
            config.New_icon_h = new_icon_h.Text;
            config.New_thumb_w = new_thumb_w.Text;
            config.New_thumb_h = new_thumb_h.Text;
            config.New_large_w = new_large_w.Text;
            config.New_large_h = new_large_h.Text;

            config.Product_icon_w = product_icon_w.Text;
            config.Product_icon_h = product_icon_h.Text;
            config.Product_thumb_w = product_thumb_w.Text;
            config.Product_thumb_h = product_thumb_h.Text;
            config.Product_large_w = product_large_w.Text;
            config.Product_large_h = product_large_h.Text;

            config.ProductNo = txtNoproduct.Text;
            config.ProductNoPage = txtNoPage.Text;
            config.Currency = txtCurrency.Text;

            config.Status = Convert.ToBoolean(rdblistClose.SelectedItem.Value);
            config.Closecomment = txtCloseComment.Text;

            config.Support = txtRadSupport.Html;
            config.Contact = txtRadContact.Html;
            config.Email_from = txtEmailFrom.Text;
            config.Email_to = txtEmailTo.Text;

            config.Counter = RadCounter.Html;
            config.Info1 = RadInfo1.Html;
            config.Info2 = RadInfo2.Html;

            config.WebDomain = txtWebDomain.Text;
            config.WebMailServer = txtWebMailServer.Text;
            config.WebName = txtWebName.Text;
            config.WebServerIP = txtWebServerIP.Text;

            config.IsPopup = Convert.ToBoolean(rdbPopup.SelectedValue);
            config.Popup = radPopup.Html;
            config.Popup2 = radPopup2.Html;

            return config;

        }
        #endregion

        #region UpdateConfig
        protected void UpdateConfig()
        {
            Config config = ReceiveHtml();
            ConfigBSO configBSO = new ConfigBSO();
            configBSO.UpdateConfig(config);
            initControl();
        }
        #endregion
        protected void btn_common_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateConfig();
                ltlcommon.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "thay đổi", "cấu hình chung");
            }
            catch (Exception ex)
            {
                ltlcommon.Text = ex.Message.ToString();
            }
        }
        protected void btnproduct_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateConfig();
                ltlproduct.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "thay đổi", "Server");
            }
            catch (Exception ex)
            {
                ltlproduct.Text = ex.Message.ToString();
            }
        }
        protected void btn_news_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateConfig();
                ltlnews.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "thay đổi", "Cấu hình tin");
            }
            catch (Exception ex)
            {
                ltlnews.Text = ex.Message.ToString();
            }
        }
        protected void btnCloseweb_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateConfig();
                ltlCloseweb.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "thay đổi", "Contact");
            }
            catch (Exception ex)
            {
                ltlCloseweb.Text = ex.Message.ToString();
            }
        }
        protected void btn_Support_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateConfig();
                litSupport.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "thay đổi", "Support");
            }
            catch (Exception ex)
            {
                litSupport.Text = ex.Message.ToString();
            }
        }
        protected void btn_Contact_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateConfig();
                litContact.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "thay đổi", "Contact ");
            }
            catch (Exception ex)
            {
                litContact.Text = ex.Message.ToString();

            }
        }
        protected void btnemail_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateConfig();
                ltlEmail.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "thay đổi", "Email liên hệ");
            }
            catch (Exception ex)
            {
                ltlEmail.Text = ex.Message.ToString();

            }
        }
        protected void btn_Other_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateConfig();
                ltlOther.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "thay đổi", "Thông tin khác");
            }
            catch (Exception ex)
            {
                ltlOther.Text = ex.Message.ToString();
            }
        }
        protected void btnServer_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateConfig();
                ltlServer.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "thay đổi", "Server");
            }
            catch (Exception ex)
            {
                ltlServer.Text = ex.Message.ToString();

            }
        }

        protected void btn_popup_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateConfig();
                ltlPopup.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "thay đổi", "Cấu hình popup");
            }
            catch (Exception ex)
            {
                ltlPopup.Text = ex.Message.ToString();
            }
        }
        protected void Viet_Check(object sender, EventArgs e)
        {
            ViewState["CauHinh_Viet"] = 1;
            initControl();
        }
        protected void Eng_Check(object sender, EventArgs e)
        {
            ViewState["CauHinh_Viet"] = 2;
            initControl();
        }
    }
}