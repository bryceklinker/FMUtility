using System.Web.Routing;
using App.FMUtility.AngularJS.Routing;

namespace App.FMUtility.AngularJS
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Add("Default", new DefaultRoute());
        }
    }
}
