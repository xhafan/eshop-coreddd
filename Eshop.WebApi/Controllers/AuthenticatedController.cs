using CoreWebApi;

namespace Eshop.WebApi.Controllers
{
    [Authentication(typeof(SessionContext))]
    public abstract class AuthenticatedController : CoreAuthenticatedController<SessionContext>
    {
    }
}