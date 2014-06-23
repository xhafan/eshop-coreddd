using NUnit.Framework;

namespace Eshop.WpfMvvmApp.UnitTests.Products
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
    }
}