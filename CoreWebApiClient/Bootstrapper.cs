using System.Web.Routing;
using CoreWebApiClient.WebApiHelpers;

namespace CoreWebApiClient
{
    public static class Bootstrapper
    {
        public static RouteCollection Routes;

        public static void Run()
        {
            Routes = new RouteCollection();
            WebApiConfig.RegisterRoute(Routes);
        }
    }
}
