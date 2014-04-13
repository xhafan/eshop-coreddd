using NUnit.Framework;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Products.BasketViewModels
{
    [TestFixture]
    public class when_can_execute_update_product_quantity_command : BasketViewModelWithLoadedBasketItemsSetup
    {
        private bool _canExecute;

        [SetUp]
        public override void Context()
        {
            base.Context();

            _canExecute = ViewModel.UpdateProductQuantityCommand.CanExecute(ProductId);
        }

        [Test]
        public void can_always_execute()
        {
            _canExecute.ShouldBe(true);
        }
    }
}