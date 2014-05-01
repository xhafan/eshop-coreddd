using System.Threading.Tasks;
using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.WpfMvvmApp.UnitTests.Products.DeliveryAddressViewModels
{
    [TestFixture]
    public class when_executing_set_delivery_address_command : DeliveryAddressViewModelSetup
    {
        [SetUp]
        public override void Context()
        {
            base.Context();
            DeliveryAddressControllerClient.Expect(x => x.SetDeliveryAddressAsync("delivery address")).Return(TaskEx.FromResult(0));
            OnDeliveryAddressSet.Expect(x => x.DeliveryAddressSet("delivery address")).Return(TaskEx.FromResult(0));
            
            ViewModel.SetDeliveryAddressCommand.Execute("delivery address");
        }

        [Test]
        public void delivery_address_is_set()
        {
            DeliveryAddressControllerClient.VerifyAllExpectations();
        }

        [Test]
        public void on_delivery_address_set_service_is_notified()
        {
            OnDeliveryAddressSet.VerifyAllExpectations();
        }
    }
}