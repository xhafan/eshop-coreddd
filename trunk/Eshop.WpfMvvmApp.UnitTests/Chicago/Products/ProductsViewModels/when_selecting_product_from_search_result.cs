using Eshop.WpfMvvmApp.Products;
using NUnit.Framework;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Chicago.Products.ProductsViewModels
{
    [TestFixture]
    public class when_selecting_product_from_search_result : ProductsViewModelWithSelectedProductFromSearchResultSetup
    {
        [Test]
        public void current_view_model_is_set()
        {
            ViewModel.CurrentViewModel.ShouldBeTypeOf<ProductDetailsViewModel>();
        }

        [Test]
        public void product_details_view_model_is_populated_with_selected_product_details()
        {
            var productDetails = GetCurrentViewModelAsProductDetails();
            productDetails.Name.ShouldBe(ProductOneName);
            productDetails.Description.ShouldBe(ProductOneDescription);
            productDetails.Price.ShouldBe(ProductOnePrice);
        }
    }
}