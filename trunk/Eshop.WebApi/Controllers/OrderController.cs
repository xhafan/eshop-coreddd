using CoreDdd.Commands;
using CoreDdd.Queries;
using Eshop.Commands;

namespace Eshop.WebApi.Controllers
{
    public class OrderController : AuthenticatedController
    {
        private readonly IQueryExecutor _queryExecutor;
        private readonly ICommandExecutor _commandExecutor;

        public OrderController(IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            _queryExecutor = queryExecutor;
            _commandExecutor = commandExecutor;
        }

        public void PlaceOrder(object notUsed) // todo: allow HttpPost without parameters?
        {
            _commandExecutor.Execute(new PlaceOrderCommand { CustomerId = SessionContext.CustomerId });
        }
    }
}