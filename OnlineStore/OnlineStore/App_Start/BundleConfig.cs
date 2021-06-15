using System.Web;
using System.Web.Optimization;

namespace OnlineStore
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/vendor/jquery/jquery.min.js",
                        "~/vendor/bootstrap/js/bootstrap.bundle.min.js",
                        "~/vendor/jquery/jquery.min.js",
                        "~/vendor/bootstrap/js/bootstrap.bundle.min.js",
                        "~/assets/js/custom.js",
                        "~/assets/js/owl.js",
                        "~/assets/js/slick.js",
                        "~/assets/js/isotope.js",
                        "~/assets/js/accordions.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/vendor/bootstrap/css/bootstrap.min.css",
                      "~/assets/css/fontawesome.css",
                      "~/assets/css/templatemo-sixteen.css",
                      "~/assets/css/owl.css"));
        }
    }
}
