using NUnit.Framework;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Products.ProductSearchResultViewModels
{
    [TestFixture]
    public class when_can_execute_select_product_command : ProductSearchResultViewModelSetup
    {
        private bool _canExecute;
        private const int ProductId = 23;

        [SetUp]
        public override void Context()
        {
            base.Context();

            _canExecute = ViewModel.SelectProductCommand.CanExecute(ProductId);
        }

        [Test]
        public void can_always_execute()
        {
            _canExecute.ShouldBe(true);
        }
    }
}