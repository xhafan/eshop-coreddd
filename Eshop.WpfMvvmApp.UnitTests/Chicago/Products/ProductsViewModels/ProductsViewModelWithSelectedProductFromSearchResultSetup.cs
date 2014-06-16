using System.Threading.Tasks;
using Eshop.Dtos;
using Eshop.WpfMvvmApp.Products;
using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.WpfMvvmApp.UnitTests.Chicago.Products.ProductsViewModels
{
    public abstract class ProductsViewModelWithSelectedProductFromSearchResultSetup : ProductsViewModelWithSearchedProductsSetup
    {
        protected const string ProductOneDescription = "product one description";
        protected const decimal ProductOnePrice = 34.5m;

        [SetUp]
        public override void Context()
        {
            base.Context();
            StubGetProductDetailsFromControllerClient();

            SelectProduct();
        }

        private void SelectProduct()
        {
            GetCurrentViewModelAsProductSearchResult().SelectProductCommand.Execute(ProductOneId);
        }

        private void StubGetProductDetailsFromControllerClient()
        {
            var productDto = new ProductDto
            {
                Id = ProductOneId,
                Name = ProductOneName,
                Description = ProductOneDescription,
                Price = ProductOnePrice
            };

            ProductControllerClient.Stubs(x => x.GetProductAsync(ProductOneId)).Returns(TaskEx.FromResult(productDto));
        }

        protected ProductDetailsViewModel2 GetCurrentViewModelAsProductDetails()
        {
            return (ProductDetailsViewModel2)ViewModel.CurrentViewModel;
        }
    }
}