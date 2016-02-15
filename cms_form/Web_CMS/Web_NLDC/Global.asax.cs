using System;
using System.Web.Routing;
using CMS;

namespace Web_NLDC
{
    public class Global : System.Web.HttpApplication
    {
        static void RegisterRouter(RouteCollection router)
        {
            router.MapPageRoute("Home", "", "~/Default.aspx");
            router.MapPageRoute("Home1", "home", "~/Default.aspx");
            router.MapPageRoute("MainHme", "{go}/default.aspx", "~/Default.aspx");
            router.MapPageRoute("MainHme1", "{go}/{g}/{title}/default.aspx", "~/Default.aspx");
            router.MapPageRoute("MainHme2", "{go}/{g}/{h}/{title}/default.aspx", "~/Default.aspx");
            router.MapPageRoute("AlbumsView", "AlbumsView/{cId}/albums.aspx", "~/Client/Modules/Albums/AlbumsView.aspx");
            router.MapPageRoute("Video", "{go}/{id}/video.aspx", "~/Default.aspx");
            router.MapPageRoute("QuestionsDetail", "{go}/{id}/default.aspx", "~/Default.aspx");
        }

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RegisterRouter(RouteTable.Routes);
            Application["CurrentUsers"] = 0;
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started
            Application["CurrentUsers"] = Convert.ToInt32(Application["CurrentUsers"]) + 1;
            long siteHitCounter = 100;

            WebHitCounter webhitcounter = new WebHitCounter();
            siteHitCounter = webhitcounter.GetHitCounter();

            webhitcounter.UpdateHitCounter(siteHitCounter + 1);
        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.
            Application["CurrentUsers"] = Convert.ToInt32(Application["CurrentUsers"]) - 1;
        }

    }
}
