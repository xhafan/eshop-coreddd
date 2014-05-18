using System.Linq;
using CoreDdd.Commands;
using CoreDdd.Queries;
using Eshop.Commands;
using Eshop.Dtos;
using Eshop.Queries;

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

        public ReviewOrderDto GetReviewOrderDto()
        {
            var basketItems = _queryExecutor.Execute<BasketItemsQuery, BasketItemDto>(new BasketItemsQuery { CustomerId = SessionContext.CustomerId });
            var deliveryAddress = _queryExecutor.Execute<DeliveryAddressQuery, DeliveryAddressDto>(new DeliveryAddressQuery { CustomerId = SessionContext.CustomerId });
            return new ReviewOrderDto
                {
                    BasketItems = basketItems.ToArray(),
                    DeliveryAddress = deliveryAddress.Single()
                };
        }
    }
}