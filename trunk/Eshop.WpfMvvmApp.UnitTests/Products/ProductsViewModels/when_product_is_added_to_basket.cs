using System.Threading.Tasks;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Products.ProductsViewModels
{
    [TestFixture]
    public class when_product_is_added_to_basket : ProductsViewModelSetup
    {
        [SetUp]
        public async override void Context()
        {
            base.Context();
            Basket.Expect(x => x.LoadBasketItems()).Return(TaskEx.FromResult(0));

            await ViewModel.ProductAddedToBasket();
        }

        [Test]
        public void basket_loads_basket_items()
        {
            Basket.VerifyAllExpectations();
        }

        [Test]
        public void current_view_model_is_set()
        {
            ViewModel.CurrentViewModel.ShouldBe(Basket);
        }
    }
}