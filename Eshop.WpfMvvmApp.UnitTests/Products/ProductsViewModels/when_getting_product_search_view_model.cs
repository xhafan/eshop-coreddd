using Eshop.WpfMvvmApp.Products;
using NUnit.Framework;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Products.ProductsViewModels
{
    [TestFixture]
    public class when_getting_product_search_view_model : ProductsViewModelSetup
    {
        private ProductSearchViewModel _retrievedProductSearch;

        [SetUp]
        public override void Context()
        {
            base.Context();

            _retrievedProductSearch = ViewModel.ProductSearch;
        }

        [Test]
        public void product_search_result_is_populated()
        {
            _retrievedProductSearch.ShouldBe(ProductSearch);
        }
    }
}