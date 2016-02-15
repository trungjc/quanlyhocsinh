using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using BSO;
using CMS;
using ETO;

namespace Web_NLDC
{
    public partial class Default : System.Web.UI.Page
    {
        #region Properties
        private string Go
        {
            get {
                return Page.RouteData.Values["go"] != null ? Page.RouteData.Values["go"].ToString().ToLower() : "";
            }
        }

        private string g
        {
            get {
                return Page.RouteData.Values["g"] != null ? Page.RouteData.Values["g"].ToString() : "";
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            #region Config
            if (Session["Lang"] == null)
                Session["Lang"] = Language.language;
            Language.lang = Session["Lang"].ToString();
            var configBso = new ConfigBSO();
            var config = configBso.GetAllConfig(Language.lang);
            Page.Title = config.Titleweb;
            if (Session["HitCounter"] == null)
            {
                long siteHitCounter = 100;
                var webhitcounter = new WebHitCounter();
                siteHitCounter = webhitcounter.GetHitCounter();

                webhitcounter.UpdateHitCounter(siteHitCounter + 1);
                Session["HitCounter"] = Convert.ToString(siteHitCounter + 1);
            }
            #endregion

            switch (Go)
            {
                case "listalbums":
                    phLeft.Controls.Add(LoadControl("Client/Modules/Albums/AlbumsList.ascx"));
                    break;
                case "listvideo":
                    phLeft.Controls.Add(LoadControl("Client/Modules/Video/VideoList.ascx"));
                    break;
                case "faq":
                    phLeft.Controls.Add(LoadControl("Client/Modules/Faq/Faq.ascx"));
                    break;
                case "questions":
                    phLeft.Controls.Add(LoadControl("Client/Modules/Faq/Question.ascx"));
                    break;
                case "faqdetail":
                    phLeft.Controls.Add(LoadControl("Client/Modules/Faq/FaqDetail.ascx"));
                    break;
                case "contact":
                    phLeft.Controls.Add(LoadControl("Client/Modules/Contact/Contact.ascx"));
                    break;
                case "contactsucceed":
                    phLeft.Controls.Add(LoadControl("Client/Modules/Contact/ContactSucceed.ascx"));
                    break;
                case "fullnewsg":
                    switch (g)
                    {
                        case "4":
                            phLeft.Controls.Add(LoadControl("Client/Modules/Official/OfficialListGroup.ascx"));
                            break;
                        default:
                            phLeft.Controls.Add(LoadControl("Client/Modules/News/NewsgListGroup.ascx"));
                            break;
                    }
                    break;
                case "catenewsg":
                    switch (g)
                    {
                        case "4":
                            phLeft.Controls.Add(LoadControl("Client/Modules/Official/OfficialList.ascx"));
                            break;
                        default:
                            phLeft.Controls.Add(LoadControl("Client/Modules/News/NewsgList.ascx"));
                            break;
                    }
                    break;
                case "newsg":
                    switch (g)
                    {
                        case "4":
                            phLeft.Controls.Add(LoadControl("Client/Modules/Official/OfficialDetail.ascx"));
                            break;
                        default:
                            phLeft.Controls.Add(LoadControl("Client/Modules/News/NewsgDetail.ascx"));
                            break;
                    }
                    break;
                default:
                    phLeft.Controls.Add(LoadControl("Client/MainHomePage.ascx"));
                    phRight.Visible = false;
                    break;
            }

            if (!String.IsNullOrEmpty(Go))
                phRight.Controls.Add(LoadControl("Client/PanelRightModules.ascx"));
        }

        protected override void InitializeCulture()
        {
            var lang = (Session["Lang"] != null) ? Session["Lang"].ToString() : "vi-VN";
            if (lang == "") return;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
        }

        private void GetHitCounter()
        {
            var hitcounterBso = new HitCounterBSO();
            var hitcounter = hitcounterBso.GetHitCounter();
            hitcounterBso.UpdateHitCounter(hitcounter + 1);
        }
    }
}