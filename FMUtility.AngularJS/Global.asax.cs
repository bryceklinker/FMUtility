using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace FMUtility.AngularJS
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Routes.RegisterRoutes(RouteTable.Routes);
            Bundles.RegisterBundles(BundleTable.Bundles);
        }
    }
}