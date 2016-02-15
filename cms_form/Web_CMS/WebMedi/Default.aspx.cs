using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ETO;
using BSO;
using CMS;
using System.Threading;
using System.Globalization;

namespace WebMedi
{
    public partial class Default : System.Web.UI.Page
    {
        #region Properties
        private string Go
        {
            get
            {
                if (Page.RouteData.Values["go"] != null)
                    return Page.RouteData.Values["go"].ToString().ToLower();
                else
                    return "";
            }
        }

        private string g
        {
            get
            {
                if (Page.RouteData.Values["g"] != null)
                    return Page.RouteData.Values["g"].ToString();
                else
                    return "";
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            #region Config
            if (Session["Lang"] == null)
                Session["Lang"] = Language.language;
            Language.lang = Session["Lang"].ToString();
            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(Language.lang);
            Page.Title = config.Titleweb;
            if (Session["HitCounter"] == null)
            {
                long SiteHitCounter = 100;
                WebHitCounter webhitcounter = new WebHitCounter();
                SiteHitCounter = webhitcounter.GetHitCounter();

                webhitcounter.UpdateHitCounter(SiteHitCounter + 1);
                Session["HitCounter"] = Convert.ToString(SiteHitCounter + 1);
            } 
            #endregion

            switch (Go.ToString())
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
                case "medidangky":
                    phLeft.Controls.Add(LoadControl("Client/Modules/DangKy_TraCuu/MeDi_PhieuXetNghiem.ascx"));
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
                    switch (g.ToString())
                    { 
                        case "4":
                            phLeft.Controls.Add(LoadControl("Client/Modules/Official/OfficialListGroup.ascx"));
                            break;
                        default:
                            phLeft.Controls.Add(LoadControl("Client/Modules/News/NewsgListGroup.ascx"));
                            break;
                    }
                    break;
                case  "mediremoteheath":
                    phLeft.Controls.Add(LoadControl("Client/Modules/Remoteheath/MeDi_remoteheath.ascx"));
                    break;
                case "catenewsg":
                    switch (g.ToString())
                    {
                        case "4":
                            phLeft.Controls.Add(LoadControl("Client/Modules/Official/OfficialList.ascx"));
                            break;
                        case"2":
                            phLeft.Controls.Add(LoadControl("Client/Modules/DangKy_TraCuu/MeDi_TraCuu.ascx"));
                            break;

                        default:
                            phLeft.Controls.Add(LoadControl("Client/Modules/News/NewsgList.ascx"));
                            break;
                    }
                    break;
                case "newsg":
                    switch (g.ToString())
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
            string lang = (Session["Lang"] != null) ? Session["Lang"].ToString() : "vi-VN";
            if (lang != null && lang != "")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
            }
        }

        private void GetHitCounter()
        {
            HitCounterBSO hitcounterBSO = new HitCounterBSO();
            long hitcounter = hitcounterBSO.GetHitCounter();
            hitcounterBSO.UpdateHitCounter(hitcounter + 1);
        }
    }
}