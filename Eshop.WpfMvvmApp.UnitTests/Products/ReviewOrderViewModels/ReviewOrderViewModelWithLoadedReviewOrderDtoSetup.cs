using System.Threading.Tasks;
using Eshop.Dtos;
using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.WpfMvvmApp.UnitTests.Products.ReviewOrderViewModels
{
    public abstract class ReviewOrderViewModelWithLoadedReviewOrderDtoSetup : ReviewOrderViewModelSetup
    {
        protected const string DeliveryAddress = "delivery address";

        [SetUp]
        public override async void Context()
        {
            base.Context();
            var basketItemDtos = new[]
            {
                new BasketItemDto
                {
                    ProductId = ProductOneId,
                    ProductPrice = 45.6m,
                    Quantity = 2
                },
                new BasketItemDto
                {
                    ProductId = ProductTwoId,
                    ProductPrice = 57.8m,
                    Quantity = 3
                },
            };
            var deliveryAddressDto = new DeliveryAddressDto { DeliveryAddress = DeliveryAddress };
            var reviewOrderDto = new ReviewOrderDto
            {
                BasketItems = basketItemDtos,
                DeliveryAddress = deliveryAddressDto
            };
            OrderControllerClient.Stubs(x => x.GetReviewOrderDtoAsync()).Returns(TaskEx.FromResult(reviewOrderDto));

            await ViewModel.LoadReviewOrderData();
        }
    }
}