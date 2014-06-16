using CoreTest;
using Eshop.WpfMvvmApp.ControllerClients;
using Eshop.WpfMvvmApp.Products;
using NUnit.Framework;

namespace Eshop.WpfMvvmApp.UnitTests.Chicago.Products.ProductsViewModels
{
    public abstract class ProductsViewModelSetup : BaseTest
    {
        protected ProductsViewModel2 ViewModel;
        protected IProductControllerClient ProductControllerClient;
        protected IBasketControllerClient BasketControllerClient;

        [SetUp]
        public virtual void Context()
        {
            ProductControllerClient = Stub<IProductControllerClient>();
            BasketControllerClient = Mock<IBasketControllerClient>();

            ViewModel = new ProductsViewModel2(ProductControllerClient, BasketControllerClient);
        }
    }
}