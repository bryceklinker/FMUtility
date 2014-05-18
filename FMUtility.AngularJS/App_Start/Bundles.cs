using System.Web.Optimization;

namespace FMUtility.AngularJS
{
    public class Bundles
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/angular")
                .Include("~/Scripts/angular.js")
                .Include("~/Scripts/angular-animate.js")
                .Include("~/Scripts/angular-cookies.js")
                .Include("~/Scripts/angular-route.js")
                .Include("~/Scripts/angular-touch.js")
                .Include("~/Scripts/angular-sanitize.js")
                .Include("~/Scripts/angular-resource.js")
                .Include("~/Scripts/angular-loader.js")
                .Include("~/Scripts/angular-ui/ui-bootstrap-tpls.js")
                .Include("~/Scripts/angular-ui/ui-bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include("~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-1.10.2.js"));

            bundles.Add(new ScriptBundle("~/bundles/modern")
                .Include("~/Scripts/modernizer-2.6.2.js"));

            bundles.Add(new StyleBundle("~/Content/angular")
                .Include("~/Scripts/angular-csp.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/Site.css"));
        }
    }
}