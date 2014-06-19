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
        protected IDeliveryAddressControllerClient DeliveryAddressControllerClient;
        protected IOrderControllerClient OrderControllerClient;

        [SetUp]
        public virtual void Context()
        {
            ProductControllerClient = Stub<IProductControllerClient>();
            BasketControllerClient = Mock<IBasketControllerClient>();
            DeliveryAddressControllerClient = Mock<IDeliveryAddressControllerClient>();
            OrderControllerClient = Mock<IOrderControllerClient>();

            ViewModel = new ProductsViewModel2(
                ProductControllerClient, 
                BasketControllerClient, 
                DeliveryAddressControllerClient,
                OrderControllerClient
                );
        }
    }
}