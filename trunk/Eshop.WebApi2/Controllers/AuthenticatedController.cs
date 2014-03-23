using CoreWebApi;

namespace Eshop.WebApi2.Controllers
{
    [Authentication(typeof(SessionContext))]
    public abstract class AuthenticatedController : CoreAuthenticatedController<SessionContext>
    {
    }
}