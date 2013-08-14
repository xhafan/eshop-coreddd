using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace CoreWebApiClient
{
    public static class RoutesProvider
    {
        public static RouteCollection GetDefaultRoutes()
        {
            var routes = new RouteCollection();
            routes.MapRoute(
                name: "DefaultApi",
                url: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            return routes;
        }
    }
}
