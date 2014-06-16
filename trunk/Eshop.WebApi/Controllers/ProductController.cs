using System.Linq;
using System.Web.Http;
using CoreDdd.Queries;
using Eshop.Dtos;
using Eshop.Queries;

namespace Eshop.WebApi.Controllers
{
    public class ProductController : AuthenticatedController
    {
        private readonly IQueryExecutor _queryExecutor;

        public ProductController(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }

        [HttpGet]
        public ProductSummaryDto[] SearchProducts(string searchedText = "")
        {
            var productDtos = _queryExecutor.Execute<ProductsQuery, ProductSummaryDto>(new ProductsQuery { SearchText = searchedText });
            return productDtos.ToArray();
        }

        public ProductDto GetProduct(int productId) // todo: rename to get product details
        {
            var productDtos = _queryExecutor.Execute<ProductDetailsQuery, ProductDto>(new ProductDetailsQuery { ProductId = productId });
            return productDtos.Single();            
        }     
    }
}