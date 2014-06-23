using System.Linq;
using Eshop.WpfMvvmApp.Products;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Products
{
    [TestFixture]
    public class when_adding_product_to_basket : ProductsViewModelWithProductAddedToBasketSetup
    {
        [Test]
        public void product_is_added_to_basket()
        {
            BasketControllerClient.VerifyAllExpectations();
        }

        [Test]
        public void current_view_model_is_set()
        {
            ViewModel.CurrentViewModel.ShouldBeTypeOf<BasketViewModel>();
        }

        [Test]
        public void basket_items_are_loaded()
        {
            var basketItems = GetCurrentViewModelAsBasket().BasketItems;
            basketItems.Count.ShouldBe(2);
            
            var basketItem = basketItems.First();
            basketItem.ProductId.ShouldBe(ProductOneId);
            basketItem.ProductName.ShouldBe(ProductOneName);
            basketItem.ProductPrice.ShouldBe(ProductOnePrice);
            basketItem.Quantity.ShouldBe(ProductOneQuantity);
            basketItem.UpdatedQuantity.ShouldBe(ProductOneQuantity);

            basketItem = basketItems.ElementAt(1);
            basketItem.ProductId.ShouldBe(ProductTwoId);
            basketItem.ProductName.ShouldBe(ProductTwoName);
            basketItem.ProductPrice.ShouldBe(ProductTwoPrice);
            basketItem.Quantity.ShouldBe(ProductTwoQuantity);
            basketItem.UpdatedQuantity.ShouldBe(ProductTwoQuantity);
        }

        [Test]
        public void basket_subtotal_is_refreshed()
        {
            GetCurrentViewModelAsBasket().Subtotal.ShouldBe(242.4m);
        }
    }
}