using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Products.BasketViewModels
{
    [TestFixture]
    public class when_loading_basket_items : BasketViewModelWithLoadedBasketItemsSetup
    {
        [Test]
        public void basket_items_are_loaded()
        {
            ViewModel.BasketItems.Count.ShouldBe(1);
            ViewModel.BasketItems.First().ProductId.ShouldBe(ProductId);
        }
    }
}