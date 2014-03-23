using System.Collections.Generic;
using System.Web.Http;
using CoreDdd.Commands;
using CoreDdd.Queries;
using Eshop.Dtos;

namespace Eshop.WebApi2.Controllers
{
    public class BasketController : AuthenticatedController
    {
        public BasketController(IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
        }

        public void AddProductToBasket([FromBody]int productId, int quantity)
        {
        }

        public IEnumerable<BasketItemDto> GetBasketItems()
        {
            return null;
        }
    }
}