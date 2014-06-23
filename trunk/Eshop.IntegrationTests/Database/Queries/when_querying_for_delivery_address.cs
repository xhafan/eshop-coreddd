using System.Collections.Generic;
using System.Linq;
using Eshop.Domain;
using Eshop.Dtos;
using Eshop.IntegrationTests.Database.ObjectMothers;
using Eshop.Queries;
using NUnit.Framework;
using Shouldly;

namespace Eshop.IntegrationTests.Database.Queries
{
    [TestFixture]
    public class when_querying_for_delivery_address : BaseEshopSimplePersistenceTest
    {
        private Customer _customerTwo;
        private IEnumerable<DeliveryAddressDto> _results;

        protected override void PersistenceContext()
        {
            var customerOne = new CustomerObjectMother().NewEntity();
            _customerTwo = new CustomerObjectMother().NewEntity();
            _customerTwo.SetDeliveryAddress("delivery address");
            
            Save(customerOne, _customerTwo);
        }

        protected override void PersistenceQuery()
        {
            var handler = new DeliveryAddressQueryHandler();
            _results = handler.Execute<DeliveryAddressDto>(new DeliveryAddressQuery { CustomerId = _customerTwo.Id });
        }

        [Test]
        public void basket_item_dtos_correctly_retrieved()
        {
            _results.Count().ShouldBe(1);

            var result = _results.First();
            result.CustomerId.ShouldBe(_customerTwo.Id);
            result.DeliveryAddress.ShouldBe("delivery address");
        }
    }
}