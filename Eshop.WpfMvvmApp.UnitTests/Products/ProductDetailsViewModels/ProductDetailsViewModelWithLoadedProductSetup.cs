using System.Threading.Tasks;
using CoreTest;
using Eshop.Dtos;
using Eshop.WpfMvvmApp.ControllerClients;
using Eshop.WpfMvvmApp.Products;
using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.WpfMvvmApp.UnitTests.Products.ProductDetailsViewModels
{
    public abstract class ProductDetailsViewModelWithLoadedProductSetup : BaseTest
    {
        protected const int ProductId = 23;
        protected const int Quantity = 34;
        protected const string ProductName = "product name";
        protected const string ProductDescription = "product description";
        protected IBasketControllerClient BasketControllerClient;
        protected IProductControllerClient ProductControllerClient;
        protected IProductAddedToBasket ProductAddedToBasket;
        protected ProductDetailsViewModel ViewModel;

        [SetUp]
        public virtual async void Context()
        {
            var productDto = new ProductDto
                {
                    Id = ProductId,
                    Name = ProductName,
                    Description = ProductDescription
                };
            ProductControllerClient = Stub<IProductControllerClient>().Stubs(x => x.GetProductAsync(ProductId)).Returns(TaskEx.FromResult(productDto));
            BasketControllerClient = Mock<IBasketControllerClient>();
            ProductAddedToBasket = Mock<IProductAddedToBasket>();
            ViewModel = new ProductDetailsViewModel(ProductControllerClient, BasketControllerClient, ProductAddedToBasket);
            await ViewModel.LoadProduct(ProductId);
        }
    }
}