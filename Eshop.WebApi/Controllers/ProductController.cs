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
    public class ProductController : ApiController
    {
        private readonly IQueryExecutor _queryExecutor;
        private readonly ICommandExecutor _commandExecutor;

        public ProductController(IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            _queryExecutor = queryExecutor;
            _commandExecutor = commandExecutor;
        }

        public IEnumerable<ProductSummaryDto> Get(string searchText = "")
        {
            var productDtos = _queryExecutor.Execute<ProductsQuery, ProductSummaryDto>(new ProductsQuery { SearchText = searchText });
            return productDtos.ToArray();
        }

        public ProductDto Get(int productId)
        {
            var productDtos = _queryExecutor.Execute<ProductDetailsQuery, ProductDto>(new ProductDetailsQuery { ProductId = productId });
            return productDtos.Single();
        }

        public void AddProductToBasket([FromBody]int productId, int quantity)
        {            
            _commandExecutor.Execute(new AddProductToBasketCommand
                {
                    ProductId = productId,
                    Quantity = quantity
                });
        }
//
//        public string Get(int id, bool flag)
//        {
//            return string.Format("id:{0} flag:{1}", id, flag);
//        }
//
//        public void Post1([FromBody]string value)
//        {
//        }
//
//        public void Post2(ProductDto product)
//        {
//        }
//
//        public ProductDto Post4([FromBody]ProductDto product, string value)
//        {
//            return new ProductDto
//                {
//                    Id = product.Id + 1,
//                    Name = product.Name + "X"
//                };
//        }        
    }
}