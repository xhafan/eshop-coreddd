using Eshop.Dtos;
using Eshop.Queries;
using Eshop.WebApi.Controllers;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace Eshop.WebApi.UnitTests.Controllers.BasketControllers
{
    [TestFixture]
    public class when_getting_basket_items : BasketControllerSetup
    {
        private const int CustomerId = 23;
        private BasketItemDto[] _basketItemDtos;
        private BasketItemDto[] _retrievedBasketItems;

        [SetUp]
        public override void Context()
        {
            base.Context();
            Controller.SessionContext = new SessionContext {CustomerId = CustomerId};
            _basketItemDtos = new[] { new BasketItemDto() };
            QueryExecutor.Stub(x => x.Execute<BasketItemsQuery, BasketItemDto>(Arg<BasketItemsQuery>.Matches(p => p.CustomerId == CustomerId))).Return(_basketItemDtos);

            _retrievedBasketItems = Controller.GetBasketItems();
        }

        [Test]
        public void retrieved_basket_items_are_correct()
        {
            _retrievedBasketItems.ShouldBe(_basketItemDtos);
        }
    }
}