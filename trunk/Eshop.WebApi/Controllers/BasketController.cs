using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CoreDdd.Commands;
using CoreDdd.Queries;
using Eshop.Commands;
using Eshop.Dtos;
using Eshop.Queries;

namespace Eshop.WebApi.Controllers
{
    public class BasketController : AuthenticatedController
    {
        private readonly IQueryExecutor _queryExecutor;
        private readonly ICommandExecutor _commandExecutor;

        public BasketController(IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            _queryExecutor = queryExecutor;
            _commandExecutor = commandExecutor;
        }

        public void AddProductToBasket([FromBody]int productId, int quantity)
        {
            SetCustomerIdToSessionContext(_commandExecutor);
            _commandExecutor.Execute(new AddProductToBasketCommand
                {
                    ProductId = productId,
                    Quantity = quantity
                });
        }

        public IEnumerable<BasketItemDto> GetBasketItems()
        {
            var productDtos = _queryExecutor.Execute<BasketItemsQuery, BasketItemDto>(new BasketItemsQuery { CustomerId = SessionContext.CustomerId });
            return productDtos.ToArray();
        }
    }
}