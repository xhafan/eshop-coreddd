using Eshop.Dtos;
using Eshop.Queries;
using Eshop.WebApi.Controllers;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace Eshop.WebApi.UnitTests.Controllers.OrderControllers
{
    [TestFixture]
    public class when_getting_review_order_dto : OrderControllerSetup
    {
        private ReviewOrderDto _reviewOrderDto;
        private BasketItemDto[] _basketItemDtos;
        private DeliveryAddressDto _deliveryAddressDto;
        private const int CustomerId = 45;

        [SetUp]
        public override void Context()
        {
            base.Context();
            Controller.SessionContext = new SessionContext { CustomerId = CustomerId };
            _basketItemDtos = new[] { new BasketItemDto() };
            _deliveryAddressDto = new DeliveryAddressDto();
            QueryExecutor
                .Stub(x => x.Execute<BasketItemsQuery, BasketItemDto>(Arg<BasketItemsQuery>.Matches(p => p.CustomerId == CustomerId)))
                    .Return(_basketItemDtos);
            QueryExecutor
                .Stub(x => x.Execute<DeliveryAddressQuery, DeliveryAddressDto>(Arg<DeliveryAddressQuery>.Matches(p => p.CustomerId == CustomerId)))
                    .Return(new[] { _deliveryAddressDto });

            _reviewOrderDto = Controller.GetReviewOrderDto();
        }

        [Test]
        public void review_order_dto_contains_basket_items()
        {
            _reviewOrderDto.BasketItems.ShouldBe(_basketItemDtos);
        }

        [Test]
        public void review_order_dto_contains_delivery_address()
        {
            _reviewOrderDto.DeliveryAddress.ShouldBe(_deliveryAddressDto);
        }
    }
}