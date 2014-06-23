using System.Linq;
using Eshop.WpfMvvmApp.Products;
using NUnit.Framework;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Products
{
    [TestFixture]
    public class when_searching_product : ProductsViewModelWithSearchedProductsSetup
    {
        [Test]
        public void current_view_model_is_set()
        {
            ViewModel.CurrentViewModel.ShouldBeTypeOf<ProductSearchResultViewModel>();
        }

        [Test]
        public void product_search_result_view_model_is_populated_with_search_result()
        {
            var productSearchResult = GetCurrentViewModelAsProductSearchResult();
            var searchedProducts = productSearchResult.Products;
            searchedProducts.Count.ShouldBe(1);
            var searchedProduct = searchedProducts.First();
            searchedProduct.Id.ShouldBe(ProductOneId);
            searchedProduct.Name.ShouldBe(ProductOneName);
        }
    }
}