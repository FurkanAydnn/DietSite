using System.Web;
using System.Web.Optimization;

namespace MVCMyProject
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bliss").Include(
                "~/Theme/js/jquery-migrate-1.1.1.js",
                "~/Theme/js/script.js",
                "~/Theme/js/superfish.js",
                "~/Theme/js/jquery.equalheights.js",
                "~/Theme/js/jquery.mobilemenu.js",
                "~/Theme/js/jquery.easing.1.3.js",
                "~/Theme/js/tmStickUp.js",
                "~/Theme/js/jquery.ui.totop.js",
                "~/Theme/js/touchTouch.jquery.js"
                ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Theme/css/stuck.css",
                      "~/Theme/css/style.css",
                      "~/Theme/css/touchTouch.css"));
        }
    }
}
