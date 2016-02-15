using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
using CMS;

namespace Fomusa
{
    public class Global : System.Web.HttpApplication
    {
        void RegisterRouter(RouteCollection router)
        {
            router.MapPageRoute("Home", "", "~/Default.aspx");
            router.MapPageRoute("Home1", "home", "~/Default.aspx");
            router.MapPageRoute("MainHme", "{go}/default.aspx", "~/Default.aspx");
            router.MapPageRoute("MainHme1", "{go}/{g}/{title}/default.aspx", "~/Default.aspx");
            router.MapPageRoute("MainHme2", "{go}/{g}/{h}/{title}/default.aspx", "~/Default.aspx");
            router.MapPageRoute("AlbumsView", "AlbumsView/{cId}/default.aspx", "~/Client/Modules/Albums/AlbumsView.aspx");
            router.MapPageRoute("Video", "{go}/{id}/video.aspx", "~/Default.aspx");
            router.MapPageRoute("QuestionsDetail", "{go}/{id}/default.aspx", "~/Default.aspx");
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRouter(RouteTable.Routes);
            Application["CurrentUsers"] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Application["CurrentUsers"] = Convert.ToInt32(Application["CurrentUsers"]) + 1;
            long SiteHitCounter = 100;

            WebHitCounter webhitcounter = new WebHitCounter();
            SiteHitCounter = webhitcounter.GetHitCounter();

            webhitcounter.UpdateHitCounter(SiteHitCounter + 1);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application["CurrentUsers"] = Convert.ToInt32(Application["CurrentUsers"]) - 1;
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}