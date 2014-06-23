using Eshop.WpfMvvmApp.ControllerClients;
using Eshop.WpfMvvmApp.Products;
using Rhino.Mocks;

namespace Eshop.WpfMvvmApp.UnitTests.Products
{
    public class ProductsViewModelBuilder
    {
        private IProductControllerClient _productControllerClient;
        private IBasketControllerClient _basketControllerClient;
        private IDeliveryAddressControllerClient _deliveryAddressControllerClient;
        private IOrderControllerClient _orderControllerClient;

        public ProductsViewModelBuilder WithProductControllerClient(IProductControllerClient productControllerClient)
        {
            _productControllerClient = productControllerClient;
            return this;
        }

        public ProductsViewModelBuilder WithBasketControllerClient(IBasketControllerClient basketControllerClient)
        {
            _basketControllerClient = basketControllerClient;
            return this;
        }

        public ProductsViewModelBuilder WithDeliveryAddressControllerClient(IDeliveryAddressControllerClient deliveryAddressControllerClient)
        {
            _deliveryAddressControllerClient = deliveryAddressControllerClient;
            return this;
        }

        public ProductsViewModelBuilder WithOrderControllerClient(IOrderControllerClient orderControllerClient)
        {
            _orderControllerClient = orderControllerClient;
            return this;
        }

        public ProductsViewModel Build()
        {
            return new ProductsViewModel(
                _productControllerClient ?? MockRepository.GenerateStub<IProductControllerClient>(),
                _basketControllerClient ?? MockRepository.GenerateStub<IBasketControllerClient>(),
                _deliveryAddressControllerClient ?? MockRepository.GenerateStub<IDeliveryAddressControllerClient>(),
                _orderControllerClient ?? MockRepository.GenerateStub<IOrderControllerClient>()
                );
        }
    }
}