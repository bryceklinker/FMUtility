using System.Web.WebPages;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace App.FMUtility.AngularJS
{
    public class Application : HttpApplication
    {
        protected void Application_Start()
        {
            AddRoutes(RouteTable.Routes);
            AddBundles(BundleTable.Bundles);
        }

        private void AddBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/content/css/app").Include("~/app/css/app.css"));

            bundles.Add(new ScriptBundle("~/js/jquery").Include("~/app/thirdparty/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/js/angular")
                .Include("~/app/thirdparty/angular.js")
                .Include("~/app/thirdparty/angular-route.js"));

            bundles.Add(new ScriptBundle("~/js/app").Include(
                "~/app/thirdparty/angular-ui-router.js",
                "~/app/filters.js",
                "~/app/services.js",
                "~/app/directives.js",
                "~/app/controllers.js",
                "~/app/app.js"));
        }

        private void AddRoutes(RouteCollection routes)
        {
            routes.Add("Default", new DefaultRoute());
        }

        private class DefaultRoute : Route
        {
            public DefaultRoute()
                : base("{*path}", new DefaultRouteHandler())
            {
                RouteExistingFiles = false;
            }

            private class DefaultRouteHandler : IRouteHandler
            {
                public IHttpHandler GetHttpHandler(RequestContext requestContext)
                {
                    var filePath = requestContext.HttpContext.Request.AppRelativeCurrentExecutionFilePath;
                    if (filePath == "~/test")
                        return WebPageHttpHandler.CreateFromVirtualPath("~/app/test/test.html");
                    return WebPageHttpHandler.CreateFromVirtualPath("~/Views/Index.cshtml");
                }
            }
        }
    }
}
