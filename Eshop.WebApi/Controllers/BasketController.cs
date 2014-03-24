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
            _commandExecutor.CommandExecuted += SetGeneratedCustomerIdToSessionContext;
            _commandExecutor.Execute(new AddProductToBasketCommand
                {
                    CustomerId = SessionContext != null ? SessionContext.CustomerId : default(int),
                    ProductId = productId,
                    Quantity = quantity
                });
        }

        private void SetGeneratedCustomerIdToSessionContext(object sender, CommandExecutedArgs commandExecutedArgs)
        {
            var generatedCustomerId = (int)commandExecutedArgs.Args;
            SessionContext = new SessionContext { CustomerId = generatedCustomerId };
        }

        public IEnumerable<BasketItemDto> GetBasketItems()
        {
            var productDtos = _queryExecutor.Execute<BasketItemsQuery, BasketItemDto>(new BasketItemsQuery { CustomerId = SessionContext.CustomerId });
            return productDtos.ToArray();
        }
    }
}