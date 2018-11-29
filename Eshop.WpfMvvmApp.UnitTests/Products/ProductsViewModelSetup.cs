using Eshop.WpfMvvmApp.ControllerClients;
using Eshop.WpfMvvmApp.Products;
using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.WpfMvvmApp.UnitTests.Products
{
    public abstract class ProductsViewModelSetup
    {
        protected ProductsViewModel ViewModel;
        protected IProductControllerClient ProductControllerClient;
        protected IBasketControllerClient BasketControllerClient;
        protected IDeliveryAddressControllerClient DeliveryAddressControllerClient;
        protected IOrderControllerClient OrderControllerClient;

        [SetUp]
        public virtual void Context()
        {
            ProductControllerClient = MockRepository.GenerateStub<IProductControllerClient>();
            BasketControllerClient = MockRepository.GenerateMock<IBasketControllerClient>();
            DeliveryAddressControllerClient = MockRepository.GenerateMock<IDeliveryAddressControllerClient>();
            OrderControllerClient = MockRepository.GenerateMock<IOrderControllerClient>();

            ViewModel = new ProductsViewModelBuilder()
                .WithProductControllerClient(ProductControllerClient)
                .WithBasketControllerClient(BasketControllerClient)
                .WithDeliveryAddressControllerClient(DeliveryAddressControllerClient)
                .WithOrderControllerClient(OrderControllerClient)
                .Build();
        }
    }
}