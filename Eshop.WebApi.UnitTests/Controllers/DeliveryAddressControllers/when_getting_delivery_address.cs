using Eshop.Dtos;
using Eshop.Queries;
using Eshop.WebApi.Controllers;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace Eshop.WebApi.UnitTests.Controllers.DeliveryAddressControllers
{
    [TestFixture]
    public class when_getting_delivery_address : DeliveryAddressControllerSetup
    {
        private string _deliveryAddress;
        private const int CustomerId = 45;

        [SetUp]
        public override void Context()
        {
            base.Context();
            Controller.SessionContext = new SessionContext { CustomerId = CustomerId };
            QueryExecutor
                .Stubs(x => x.Execute<DeliveryAddressQuery, DeliveryAddressDto>(Arg<DeliveryAddressQuery>.Matches(p => MatchingQuery(p))))
                    .Returns(new[] { new DeliveryAddressDto { DeliveryAddress = "delivery address"} });

            _deliveryAddress = Controller.GetDeliveryAddress();
        }

        [Test]
        public void delivery_address_is_retrieved()
        {
            _deliveryAddress.ShouldBe("delivery address");
        }

        private bool MatchingQuery(DeliveryAddressQuery query)
        {
            query.CustomerId.ShouldBe(CustomerId);
            return true;
        }
    }
}