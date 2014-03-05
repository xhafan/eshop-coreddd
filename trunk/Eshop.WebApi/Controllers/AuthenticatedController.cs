using CoreDdd.Commands;
using CoreWebApi;

namespace Eshop.WebApi.Controllers
{
    [Authentication(typeof(SessionContext))]
    public abstract class AuthenticatedController : CoreAuthenticatedController<SessionContext>
    {
        protected void SetCustomerIdToSessionContext(ICommandExecutor commandExecutor)
        {
            if (SessionContext == null)
            {
                commandExecutor.CommandExecuted += (sender, args) =>
                {
                    var newCustomerId = (int)args.Args;
                    SessionContext = new SessionContext { CustomerId = newCustomerId };
                };
            }
        }
    }
}