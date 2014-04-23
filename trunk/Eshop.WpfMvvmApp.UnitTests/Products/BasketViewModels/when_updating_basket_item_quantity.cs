using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Products.BasketViewModels
{
    [TestFixture]
    public class when_updating_basket_item_quantity : BasketViewModelWithLoadedBasketItemsSetup
    {
        public override void Context()
        {
            base.Context();

            var basketItem = ViewModel.BasketItems.First();
            basketItem.UpdatedQuantity = 4;
            basketItem.UpdateQuantity();
        }

        [Test]
        public void subtotal_is_refreshed()
        {
            ViewModel.Subtotal.ShouldBe(355.8m);
        }
    }
}