using NUnit.Framework;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Products.ProductDetailsViewModels
{
    [TestFixture]
    public class when_can_execute_add_to_basket_command : ProductDetailsViewModelWithLoadedProductSetup
    {
        private bool _canExecute;

        [SetUp]
        public override void Context()
        {
            base.Context();

            _canExecute = ViewModel.AddToBasketCommand.CanExecute(Quantity);
        }

        [Test]
        public void can_always_execute()
        {
            _canExecute.ShouldBe(true);
        }
    }
}