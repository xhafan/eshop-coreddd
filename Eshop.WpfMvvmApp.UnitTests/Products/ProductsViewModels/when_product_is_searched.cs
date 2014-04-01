using Eshop.Dtos;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Products.ProductsViewModels
{
    [TestFixture]
    public class when_product_is_searched : ProductsViewModelSetup
    {
        private ProductSummaryDto[] _productSummaryDtos;

        [SetUp]
        public override void Context()
        {
            base.Context();
            _productSummaryDtos = new[] {new ProductSummaryDto()};

            ViewModel.ProductSearched(_productSummaryDtos);
        }

        [Test]
        public void product_search_result_is_populated()
        {
            ProductSearchResult.AssertWasCalled(x => x.PopulateSearchResult(_productSummaryDtos));
        }

        [Test]
        public void current_view_model_is_set()
        {
            ViewModel.CurrentViewModel.ShouldBe(ProductSearchResult);
        }
    }
}