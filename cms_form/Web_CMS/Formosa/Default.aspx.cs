using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;
using BSO;
using ETO;
using CMS;

namespace Fomusa
{
    public partial class Default : System.Web.UI.Page
    {
        #region Properties
        private string Go
        {
            get
            {
                if (Page.RouteData.Values["go"] != null)
                    return Page.RouteData.Values["go"].ToString().ToLower().Trim();
                else
                    return "";
            }
        }

        private string g
        {
            get
            {
                if (Page.RouteData.Values["g"] != null)
                    return Page.RouteData.Values["g"].ToString().Trim();
                else
                    return "";
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Lang"] == null)
                Session["Lang"] = "vi-VN";
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

            switch (Go.ToString())
            {
                case "albums":
                    PlaceHolder.Controls.Add(LoadControl("Client/Modules/Albums/AlbumsList.ascx"));
                    break;
                case "video":
                    PlaceHolder.Controls.Add(LoadControl("Client/Modules/Video/VideoList.ascx"));
                    break;
                case "question":
                    PlaceHolder.Controls.Add(LoadControl("Client/Modules/Faq/Question.ascx"));
                    break;
                case "faq":
                    PlaceHolder.Controls.Add(LoadControl("Client/Modules/Faq/Faq.ascx"));
                    break;
                case "faqdetail":
                    PlaceHolder.Controls.Add(LoadControl("Client/Modules/Faq/FaqDetail.ascx"));
                    break;
                case "sendemailnewsg":
                    PlaceHolder.Controls.Add(LoadControl("Client/Modules/News/SendEmailNewsg.ascx"));
                    break;
                case "search":
                    PlaceHolder.Controls.Add(LoadControl("Client/Modules/Search/SearchResult.ascx"));
                    break;
                case "singlepage":
                    PlaceHolder.Controls.Add(LoadControl("Client/Modules/News/SinglePageDetail.ascx"));
                    break;
                case "contact":
                    PlaceHolder.Controls.Add(LoadControl("Client/Modules/Contact/Contact.ascx"));
                    break;
                case "succeed":
                    PlaceHolder.Controls.Add(LoadControl("Client/Modules/Contact/ContactSucceed.ascx"));
                    break;
                case "sitemap":
                    PlaceHolder.Controls.Add(LoadControl("Client/Modules/SiteMap/Sitemap.ascx"));
                    break;
                case "hrms":
                    PlaceHolder.Controls.Add(LoadControl("Client/Modules/HRMS/HRMSView.ascx"));
                    break;
                case "phonebook":
                    PlaceHolder.Controls.Add(LoadControl("Client/Modules/PhoneBook/ListPhoneBook.ascx"));
                    break;

                case "fullnews":
                    switch (g.ToString())
                    {
                        case "4":
                            PlaceHolder.Controls.Add(LoadControl("Client/Modules/Official/OfficialListGroup.ascx"));
                            break;
                        case "8":
                            PlaceHolder.Controls.Add(LoadControl("Client/Modules/News/NewsList_FromICON.ascx"));
                            break;
                        case "0":
                            PlaceHolder.Controls.Add(LoadControl("Client/Modules/News/NewsList_FromICON.ascx"));
                            break;
                        //case "2":
                        //    PlaceHolder.Controls.Add(LoadControl("Client/Modules/Company/CompanyList.ascx"));
                        //    break;
                        default:
                            PlaceHolder.Controls.Add(LoadControl("Client/Modules/News/NewsgListGroup.ascx"));
                            break;
                    }
                    break;
                case "category":
                    switch (g.ToString())
                    {
                        case "4":
                            PlaceHolder.Controls.Add(LoadControl("Client/Modules/Official/OfficialList.ascx"));
                            break;
                        //case "2":
                        //    PlaceHolder.Controls.Add(LoadControl("Client/Modules/Company/CompanyList.ascx"));
                        //    break;
                        default:
                            PlaceHolder.Controls.Add(LoadControl("Client/Modules/News/NewsgList.ascx"));
                            break;
                    }
                    break;
                case "news":
                    switch (g.ToString())
                    {
                        case "4":
                            PlaceHolder.Controls.Add(LoadControl("Client/Modules/Official/OfficialDetail.ascx"));
                            break;
                        default:
                            PlaceHolder.Controls.Add(LoadControl("Client/Modules/News/NewsgDetail.ascx"));
                            break;
                    }
                    break;

                case "fullpagesg":
                    PlaceHolder.Controls.Add(LoadControl("Client/Modules/Company/CompanyListGroup.ascx"));
                    break;

                case "catepagesg":
                    PlaceHolder.Controls.Add(LoadControl("Client/Modules/Company/CompanyListGroup.ascx"));
                    break;

                case "pagesg":
                    PlaceHolder.Controls.Add(LoadControl("Client/Modules/Company/CompanyDetailGroup.ascx"));
                    break;

                default:
                    PlaceHolder.Controls.Add(LoadControl("Client/MainHomePage.ascx"));
                    break;
            }
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