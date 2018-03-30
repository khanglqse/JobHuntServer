using System.Web;
using System.Web.Optimization;

namespace JobHunt.Web
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
            bundles.Add(new ScriptBundle("~/Content/layout").Include(
                "~/Content/css/bootstrap-grid.css",
                "~/Content/css/icons.css",
                "~/Content/css/animate.min.css",
                "~/Content/css/style.css",
                "~/Content/css/responsive.css",
                "~/Content/css/chosen.css",
                "~/Content/css/colors/colors.css"
                ));
            bundles.Add(new ScriptBundle("~/bundles/layout").Include(
                "~/Scripts/js/jquery.min.js",
                "~/Scripts/js/modernizr.js",
                "~/Scripts/js/script.js",
                "~/Scripts/js/wow.min.js",
                "~/Scripts/js/slick.min.js",
                "~/Scripts/js/parallax.js",
                "~/Scripts/js/select-chosen.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"));
        }
    }
}
