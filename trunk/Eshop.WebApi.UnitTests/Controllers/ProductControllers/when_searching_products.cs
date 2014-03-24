using System.Collections.Generic;
using Eshop.Dtos;
using Eshop.Queries;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace Eshop.WebApi.UnitTests.Controllers.ProductControllers
{
    [TestFixture]
    public class when_searching_products : ProductControllerSetup
    {
        private ProductSummaryDto[] _productSummaryDtos;
        private IEnumerable<ProductSummaryDto> _retrievedProducts;

        [SetUp]
        public override void Context()
        {
            base.Context();
            const string searchedText = "searched text";
            _productSummaryDtos = new[] { new ProductSummaryDto() };
            QueryExecutor.Stubs(x => x.Execute<ProductsQuery, ProductSummaryDto>(Arg<ProductsQuery>.Matches(p => p.SearchText == searchedText))).Returns(_productSummaryDtos);

            _retrievedProducts = Controller.SearchProducts(searchedText);
        }

        [Test]
        public void retrieved_products_are_correct()
        {
            _retrievedProducts.ShouldBe(_productSummaryDtos);
        }
    }
}