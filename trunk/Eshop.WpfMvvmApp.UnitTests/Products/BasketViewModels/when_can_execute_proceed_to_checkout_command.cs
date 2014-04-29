using NUnit.Framework;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Products.BasketViewModels
{
    [TestFixture]
    public class when_can_execute_proceed_to_checkout_command : BasketViewModelWithLoadedBasketItemsSetup
    {
        private bool _canExecute;

        [SetUp]
        public override void Context()
        {
            base.Context();

            _canExecute = ViewModel.ProceedToCheckoutCommand.CanExecute(null);
        }

        [Test]
        public void can_always_execute()
        {
            _canExecute.ShouldBe(true);
        }
    }
}