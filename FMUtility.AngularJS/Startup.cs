using Owin;

[assembly: Microsoft.Owin.OwinStartup(typeof(App.FMUtility.AngularJS.Startup))]
namespace App.FMUtility.AngularJS
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
