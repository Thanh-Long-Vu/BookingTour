using System.Web;
using System.Web.Optimization;

namespace Booking_Tour
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

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/popper.min.js",
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/OwlCarousel2-2.2.1/owl.carousel.js",
                      "~/Scripts/easing/easing.js",
                      "~/Scripts/custom/custom.js"

                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap/bootstrap.min.css",
                      "~/Content/css/home/main_style.css",
                      "~/Content/css/home/responsive.css",
                      "~/Content/css/plugins/OwlCarousel2-2.2.1/owl.carousel.css",
                      "~/Content/css/plugins/OwlCarousel2-2.2.1/owl.theme.default.css",
                      "~/Content/css/plugins/OwlCarousel2-2.2.1/animate.css",
                      "~/Content/fontawesome-all.min.css"));
        }
    }
}
