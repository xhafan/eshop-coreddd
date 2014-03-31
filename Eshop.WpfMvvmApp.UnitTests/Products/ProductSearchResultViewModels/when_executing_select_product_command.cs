using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.WpfMvvmApp.UnitTests.Products.ProductSearchResultViewModels
{
    [TestFixture]
    public class when_executing_select_product_command : ProductSearchResultViewModelSetup
    {
        private const int ProductId = 23;

        [SetUp]
        public override void Context()
        {
            base.Context();

            ViewModel.SelectProductCommand.Execute(ProductId);
        }

        [Test]
        public void product_selected_service_is_notified()
        {
            ProductSelected.AssertWasCalled(x => x.ProductSelected(ProductId));
        }
    }
}