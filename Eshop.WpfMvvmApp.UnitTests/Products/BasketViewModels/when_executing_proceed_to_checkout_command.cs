using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.WpfMvvmApp.UnitTests.Products.BasketViewModels
{
    [TestFixture]
    public class when_executing_proceed_to_checkout_command : BasketViewModelWithLoadedBasketItemsSetup
    {
        [SetUp]
        public override void Context()
        {
            base.Context();
            
            ViewModel.ProceedToCheckoutCommand.Execute(null);
        }

        [Test]
        public void on_proceeded_to_checkout_service_is_notified()
        {
            OnProceedingToCheckout.AssertWasCalled(x => x.ProceededToCheckout());
        }
    }
}