using CoreTest;
using Eshop.WpfMvvmApp.ControllerClients;
using Eshop.WpfMvvmApp.Products;
using NUnit.Framework;

namespace Eshop.WpfMvvmApp.UnitTests.Products.DeliveryAddressViewModels
{
    public abstract class DeliveryAddressViewModelSetup : BaseTest
    {
        protected IDeliveryAddressControllerClient DeliveryAddressControllerClient;
        protected IOnDeliveryAddressSet OnDeliveryAddressSet;
        protected DeliveryAddressViewModel ViewModel;

        [SetUp]
        public virtual void Context()
        {
            DeliveryAddressControllerClient = Mock<IDeliveryAddressControllerClient>();
            OnDeliveryAddressSet = Stub<IOnDeliveryAddressSet>();
            ViewModel = new DeliveryAddressViewModel(DeliveryAddressControllerClient, OnDeliveryAddressSet);
        }
    }
}