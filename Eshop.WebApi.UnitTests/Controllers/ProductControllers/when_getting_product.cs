using Eshop.Dtos;
using Eshop.Queries;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace Eshop.WebApi.UnitTests.Controllers.ProductControllers
{
    [TestFixture]
    public class when_getting_product : ProductControllerSetup
    {
        private ProductDto _retrievedProduct;
        private ProductDto _productDto;
        private const int ProductId = 23;

        [SetUp]
        public override void Context()
        {
            base.Context();
            _productDto = new ProductDto();
            QueryExecutor.Stub(x => x.Execute<ProductDetailsQuery, ProductDto>(Arg<ProductDetailsQuery>.Matches(p => p.ProductId == ProductId))).Return(new[] { _productDto });

            _retrievedProduct = Controller.GetProduct(ProductId);
        }

        [Test]
        public void retrieved_product_is_correct()
        {
            _retrievedProduct.ShouldBe(_productDto);
        }
    }
}