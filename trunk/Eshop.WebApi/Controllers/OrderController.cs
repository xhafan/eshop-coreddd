using CoreDdd.Commands;
using CoreDdd.Queries;

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

        public void PlaceOrder(object obj) // todo: allow HttpPost without parameters
        {
        }
    }
}