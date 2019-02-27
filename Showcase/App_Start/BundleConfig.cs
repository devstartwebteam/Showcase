using System.Web;
using System.Web.Optimization;

namespace Showcase
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

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
              "~/Scripts/knockout-{version}.js",
              "~/Scripts/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/argonjs").Include(
                      "~/Content/assets/argon/vendor/popper/popper.min.js",
                      "~/Content/assets/argon/vendor/headroom/headroom.min.js",
                      "~/Content/assets/argon/js/argon.min.js",
                      "~/Scripts/jquery.bxslider.js",
                      "~/Scripts/scripts.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css",
                      "~/Content/assets/argon/vendor/nucleo/css/nucleo.css",
                      "~/Content/assets/argon/vendor/font-awesome/css/font-awesome.min.css",
                      "~/Content/assets/argon/css/argon.min.css",
                      "~/Content/jquery.bxslider.css",
                      "~/Content/assets/argon/css/docs.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/adminatorScripts").Include(
                "~/Content/assets/adminator/scripts/index.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/adminatorStyles").Include(
                "~/Content/assets/adminator/styles/admin.css"
                ));
        }
    }
}
