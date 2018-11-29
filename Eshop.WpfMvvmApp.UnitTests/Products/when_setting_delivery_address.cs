using System.Threading.Tasks;
using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.WpfMvvmApp.UnitTests.Products
{
    [TestFixture]
    public class when_setting_delivery_address : base_review_order_loaded_test
    {
        [SetUp]
        public override void Context()
        {
            base.Context();
            StubNoDeliveryAddressOnControllerClient();
            ProceedToCheckout();
            ExpectDeliveryAddressIsSetOnControllerClient();

            SetDeliveryAddress();
        }

        private void SetDeliveryAddress()
        {
            GetCurrentViewModelAsDeliveryAddress().SetDeliveryAddressCommand.Execute(DeliveryAddress);
        }

        private void ExpectDeliveryAddressIsSetOnControllerClient()
        {
            DeliveryAddressControllerClient.Expect(x => x.SetDeliveryAddressAsync(DeliveryAddress)).Return(Task.FromResult(0));
        }

        [Test]
        public void delivery_address_is_set()
        {
            DeliveryAddressControllerClient.VerifyAllExpectations();
        }


    }
}