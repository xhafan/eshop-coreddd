using System.Linq;
using System.Threading.Tasks;
using Eshop.Dtos;
using Eshop.WpfMvvmApp.Products;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Chicago.Products.ProductsViewModels
{
    [TestFixture]
    public class when_proceeding_to_checkout_with_delivery_address_set : ProductsViewModelWithProductAddedToBasketSetup
    {
        private const string DeliveryAddress = "delivery address";

        [SetUp]
        public override void Context()
        {
            base.Context();
            DeliveryAddressControllerClient.Stubs(x => x.GetDeliveryAddressAsync()).Returns(TaskEx.FromResult(DeliveryAddress));
            OrderControllerClient.Stubs(x => x.GetReviewOrderDtoAsync()).Returns(TaskEx.FromResult(GetReviewOrderDto()));
            GetCurrentViewModelAsBasket().ProceedToCheckoutCommand.Execute(null);
        }

        [Test]
        public void current_view_model_is_set()
        {
            ViewModel.CurrentViewModel.ShouldBeTypeOf<ReviewOrderViewModel2>();
        }

        [Test]
        public void basket_items_are_loaded()
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

        private ReviewOrderDto GetReviewOrderDto()
        {
            var basketItemDtos = new[]
            {
                new BasketItemDto
                {
                    ProductId = ProductOneId,
                    ProductPrice = ProductOnePrice,
                    Quantity = ProductOneQuantity
                },
                new BasketItemDto
                {
                    ProductId = ProductTwoId,
                    ProductPrice = ProductTwoPrice,
                    Quantity = ProductTwoQuantity
                },
            };
            var deliveryAddressDto = new DeliveryAddressDto {DeliveryAddress = DeliveryAddress};
            var reviewOrderDto = new ReviewOrderDto
            {
                BasketItems = basketItemDtos,
                DeliveryAddress = deliveryAddressDto
            };
            return reviewOrderDto;
        }
    }
}