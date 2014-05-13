using Eshop.WpfMvvmApp.Products;
using NUnit.Framework;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Products.ProductsViewModels
{
    [TestFixture]
    public class when_order_is_placed : ProductsViewModelSetup
    {
        [SetUp]
        public async override void Context()
        {
            base.Context();

            await ViewModel.OrderPlaced();
        }

        [Test]
        public void current_view_model_is_set()
        {
            ViewModel.CurrentViewModel.ShouldBeTypeOf<OrderPlacedViewModel>();
        }
    }
}