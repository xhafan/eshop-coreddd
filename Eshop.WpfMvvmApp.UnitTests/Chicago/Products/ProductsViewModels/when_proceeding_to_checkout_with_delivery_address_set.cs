using System.Threading.Tasks;
using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.WpfMvvmApp.UnitTests.Chicago.Products.ProductsViewModels
{
    [TestFixture]
    public class when_proceeding_to_checkout_with_delivery_address_set : base_review_order_loaded_test
    {
        [SetUp]
        public override void Context()
        {
            base.Context();
            StubExistingDeliveryAddressOnControllerClient();

            ProceedToCheckout();
        }

        private void StubExistingDeliveryAddressOnControllerClient()
        {
            DeliveryAddressControllerClient.Stubs(x => x.GetDeliveryAddressAsync()).Returns(TaskEx.FromResult(DeliveryAddress));
        }
    }
}