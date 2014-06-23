using System.Linq;
using Eshop.WpfMvvmApp.Products;
using NUnit.Framework;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Chicago.Products.ProductsViewModels
{
    public abstract class base_review_order_loaded_test : ProductsViewModelWithProductAddedToBasketSetup
    {
        [SetUp]
        public override void Context()
        {
            base.Context();
            StubReviewOrderDataOnControllerClient();
        }

        [Test]
        public void current_view_model_is_set()
        {
            ViewModel.CurrentViewModel.ShouldBeTypeOf<ReviewOrderViewModel>();
        }

        [Test]
        public void review_order_basket_items_are_loaded()
        {
            var basketItems = GetCurrentViewModelAsReviewOrder().BasketItems;
            basketItems.Count.ShouldBe(2);
            basketItems.First().ProductId.ShouldBe(ProductOneId);
            basketItems.ElementAt(1).ProductId.ShouldBe(ProductTwoId);
        }

        [Test]
        public void subtotal_is_refreshed()
        {
            GetCurrentViewModelAsReviewOrder().Subtotal.ShouldBe(242.4m);
        }

        [Test]
        public void delivery_address_is_loaded()
        {
            GetCurrentViewModelAsReviewOrder().DeliveryAddress.ShouldBe(DeliveryAddress);
        }
    }
}