using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace CoreWebApiClient.WebApiHelpers
{
    public static class WebApiConfig
    {
        public static void RegisterRoute(RouteCollection routes) // todo: do something about this (MapHttpRoute, routeTemplate in web api config)
        {
            routes.MapRoute(
                name: "DefaultApi",
                url: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}