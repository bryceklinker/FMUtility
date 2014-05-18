using System.Web.Mvc;
using System.Web.Routing;

namespace FMUtility.AngularJS
{
    public class Routes
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("Default", "{controller}/{action}/{id}", new
            {
                controller = "Home",
                action = "Index",
                id = string.Empty
            });
        }
    }
}