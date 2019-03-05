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
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui.min.js",
                        "~/Scripts/clockpicker.js"));

            bundles.Add(new StyleBundle("~/bundles/jqueryCss").Include(
                "~/Content/jquery-ui.min.css",
                "~/Content/clockpicker.css"));

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

            //Front end theme
            bundles.Add(new ScriptBundle("~/bundles/argonjs").Include(
                      "~/Content/themes/argon/vendor/popper/popper.min.js",
                      "~/Content/themes/argon/vendor/headroom/headroom.min.js",
                      "~/Content/themes/argon/js/argon.min.js",
                      "~/Scripts/jquery.bxslider.js",
                      "~/Scripts/scripts.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css",
                      "~/Content/themes/argon/vendor/nucleo/css/nucleo.css",
                      "~/Content/themes/argon/vendor/font-awesome/css/font-awesome.min.css",
                      "~/Content/themes/argon/css/argon.min.css",
                      "~/Content/jquery.bxslider.css",
                      "~/Content/themes/argon/css/docs.min.css"));

            //Admin theme
            bundles.Add(new ScriptBundle("~/bundles/bootstraplight").Include(
                "~/Content/themes/bootstraplight/assets/js/core/jquery.3.2.1.min.js",
                "~/Content/themes/bootstraplight/assets/js/core/popper.min.js",
                "~/Content/themes/bootstraplight/assets/js/core/bootstrap.min.js",
                "~/Content/themes/bootstraplight/assets/js/plugins/bootstrap-switch.js",
                "~/Content/themes/bootstraplight/assets/js/plugins/chartist.min.js",
                "~/Content/themes/bootstraplight/assets/js/plugins/bootstrap-notify.js",
                "~/Content/themes/bootstraplight/assets/js/light-bootstrap-dashboard.js?v=2.0.1",
                "~/Content/themes/bootstraplight/assets/js/plugins/bootstrap-notify.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstraplightStyles").Include(
                "~/Content/themes/bootstraplight/assets/css/bootstrap.min.css",
                "~/Content/themes/bootstraplight/assets/css/light-bootstrap-dashboard.css",
                "~/Areas/Admin/Content/Admin.css"));
        }
    }
}
