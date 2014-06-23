using CoreTest;
using Eshop.WpfMvvmApp.ControllerClients;
using Eshop.WpfMvvmApp.Products;
using NUnit.Framework;

namespace Eshop.WpfMvvmApp.UnitTests.Products
{
    public abstract class ProductsViewModelSetup : BaseTest
    {
        protected ProductsViewModel ViewModel;
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

            ViewModel = new ProductsViewModelBuilder()
                .WithProductControllerClient(ProductControllerClient)
                .WithBasketControllerClient(BasketControllerClient)
                .WithDeliveryAddressControllerClient(DeliveryAddressControllerClient)
                .WithOrderControllerClient(OrderControllerClient)
                .Build();
        }
    }
}