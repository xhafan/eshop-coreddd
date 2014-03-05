using System.Web.Http;

namespace CoreWebApi
{
    public abstract class CoreAuthenticatedController : ApiController
    {
        public object SessionContextObject { get; set; }
    }
}