using System.Threading.Tasks;
using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.WpfMvvmApp.UnitTests.Products.ReviewOrderViewModels
{
    [TestFixture]
    public class when_executing_place_order_command : ReviewOrderViewModelWithLoadedReviewOrderDtoSetup
    {
        [SetUp]
        public override void Context()
        {
            base.Context();
            OnPlacingOrder.Expect(x => x.OrderPlaced());
            OrderControllerClient.Expect(x => x.PlaceOrderAsync(Arg<object>.Is.Anything)).Return(TaskEx.FromResult(0));

            ViewModel.PlaceOrderCommand.Execute(null);
        }

        [Test]
        public void order_is_placed()
        {
            OrderControllerClient.VerifyAllExpectations();
        }

        [Test]
        public void on_placing_order_service_is_notified()
        {
            OnPlacingOrder.VerifyAllExpectations();
        }
    }
}