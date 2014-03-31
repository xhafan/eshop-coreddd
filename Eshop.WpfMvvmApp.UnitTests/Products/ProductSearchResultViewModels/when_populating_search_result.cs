using System.Linq;
using Eshop.Dtos;
using NUnit.Framework;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Products.ProductSearchResultViewModels
{
    [TestFixture]
    public class when_populating_search_result : ProductSearchResultViewModelSetup
    {
        private const int ProductId = 23;
        private const string ProductName = "product name";

        [SetUp]
        public override void Context()
        {
            base.Context();
            var dto = new ProductSummaryDto
                {
                    Id = ProductId,
                    Name = ProductName
                };

            ViewModel.PopulateSearchResult(new[] { dto });
        }

        [Test]
        public void products_are_set()
        {
            ViewModel.Products.Count.ShouldBe(1);
            var product = ViewModel.Products.First();
            product.Id.ShouldBe(ProductId);
            product.Name.ShouldBe(ProductName);
        }
    }
}