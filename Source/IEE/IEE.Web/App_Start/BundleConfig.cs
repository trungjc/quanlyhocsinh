﻿using System.Web;
using System.Web.Optimization;

namespace IEE.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css",
                "~/Content/dist/css/AdminLTE.min.css",
                "~/Content/dist/css/skins/_all-skins.min.css",
                "~/Content/plugins/iCheck/flat/blue.css",
                "~/Content/plugins/datepicker/datepicker3.css",
                "~/Content/plugins/daterangepicker/daterangepicker-bs3.css",
                "~/Content/plugins/fullcalendar/fullcalendar.min.css"));

            bundles.Add(new StyleBundle("~/Content/kendo/css").Include(
                  "~/Content/kendo/2014.1.318/kendo.common.min.css",
                  "~/Content/kendo/2014.1.318/kendo.default.min.css",
                  "~/Content/kendo/2014.1.318/kendo.dataviz.min.css",
                  "~/Content/kendo/2014.1.318/kendo.bootstrap.min.css",
                  "~/Content/kendo/2014.1.318/kendo.dataviz.default.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                      "~/Scripts/kendo/2014.1.318/kendo.all.min.js",
                      "~/Scripts/kendo/kendo.timezones.min.js",
                      "~/Scripts/kendo/2014.1.318/kendo.aspnetmvc.min.js"));
        }
    }
}
