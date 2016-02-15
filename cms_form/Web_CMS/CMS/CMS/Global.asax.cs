using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;

namespace CMS
{
    public class Global : System.Web.HttpApplication
    {
        static void RegisterRouter(RouteCollection router)
        {
            router.MapPageRoute("Admin", "Homepage.aspx", "~/Admin/login");
            router.MapPageRoute("Admin0", "Admin/{dll}", "~/Homepage.aspx");
            router.MapPageRoute("Admin dll", "Admin/{dll}/Default.aspx", "~/Homepage.aspx");
            router.MapPageRoute("Admin dll id", "Admin/{dll}/{id}/Default.aspx", "~/Homepage.aspx");
            router.MapPageRoute("Admin s dll id", "Admins/{dll}/{id}/Default.aspx", "~/Homepage.aspx");
            router.MapPageRoute("Admin dll grp", "Admin/{dll}/{group}/Default.aspx", "~/Homepage.aspx");
            router.MapPageRoute("Admin Grp dll grp", "Admin/Group/{dll}/{group}/Default.aspx", "~/Homepage.aspx");
            router.MapPageRoute("Admin Grp dll id grp", "Admin/Group/{dll}/{id}/{group}/Default.aspx", "~/Homepage.aspx");
            router.MapPageRoute("Admin dll grp id", "Admin/{dll}/{group}/{id}/Default.aspx", "~/Homepage.aspx");
            router.MapPageRoute("Admin s dll grp id", "Admin/s/{dll}/{group}/{id}/Default.aspx", "~/Homepage.aspx");
            router.MapPageRoute("Admin p dll p", "Admin/p/{dll}/{p}/Default.aspx", "~/Homepage.aspx");
            router.MapPageRoute("Admin s dll id sid", "Admin/s/{dll}/{id}/{subid}/Default.aspx", "~/Homepage.aspx");
            router.Ignore("{resource}.axd/{*pathInfo}");
        }

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RegisterRouter(RouteTable.Routes);
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

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
