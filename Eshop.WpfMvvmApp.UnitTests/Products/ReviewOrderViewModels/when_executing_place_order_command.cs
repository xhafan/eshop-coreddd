using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.WpfMvvmApp.UnitTests.Products.ReviewOrderViewModels
{
    [TestFixture]
    public class when_executing_place_order_command : ReviewOrderViewModelWithLoadedBasketItemsSetup
    {
        [SetUp]
        public override void Context()
        {
            base.Context();
            OnPlacingOrder.Expect(x => x.OrderPlaced());

            ViewModel.PlaceOrderCommand.Execute(null);
        }

        [Test]
        public void on_placing_order_service_is_notified()
        {
            OnPlacingOrder.VerifyAllExpectations();
        }
    }
}