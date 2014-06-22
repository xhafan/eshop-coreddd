using NUnit.Framework;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Chicago.Products.ProductsViewModels
{
    [TestFixture]
    public class when_can_set_delivery_address : ProductsViewModelWithProductAddedToBasketSetup
    {
        [SetUp]
        public override void Context()
        {
            base.Context();
            StubNoDeliveryAddressOnControllerClient();
            ProceedToCheckout();
        }

        [TestCase("delivery address", true)]
        [TestCase("", false)]
        [TestCase(" ", false)]
        [TestCase(null, false)]
        public void can_set_delivery_address(string deliveryAddress, bool expectedCanExecute)
        {
            var setDeliveryAddressCommand = GetCurrentViewModelAsDeliveryAddress().SetDeliveryAddressCommand;

            setDeliveryAddressCommand.CanExecute(deliveryAddress).ShouldBe(expectedCanExecute);
        }
    }
}