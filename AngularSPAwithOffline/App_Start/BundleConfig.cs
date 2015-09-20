using System.Web;
using System.Web.Optimization;

namespace AngularSPAwithOffline
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                                  "~/Content/bootstrap.min.css",
                                  "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/jquery-2.1.4.min.js",
                      "~/Scripts/angular.min.js",
                      "~/Scripts/angular-ui-router.min.js",
                      "~/Scripts/angular-ui/ui-bootstrap-tpls.min.js",
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/AwesomeAngularMVCApp")
                .IncludeDirectory("~/Scripts/Controllers", "*.js")
                .IncludeDirectory("~/Scripts/Factories", "*.js")
                .Include("~/Scripts/AwesomeAngularMVCApp.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
