using Eshop.Domain;
using NUnit.Framework;
using Shouldly;

namespace Eshop.IntegrationTests.Database
{
    [TestFixture]
    public class when_persisting_customer : BaseEshopSimplePersistenceTest
    {
        private Customer _customer;
        private Customer _retrievedCustomer;

        protected override void PersistenceContext()
        {
            _customer = new Customer();
            Save(_customer);
        }

        protected override void PersistenceQuery()
        {
            _retrievedCustomer = Get<Customer>(_customer.Id);
        }

        [Test]
        public void customer_is_retrieved()
        {
            _retrievedCustomer.ShouldBe(_customer);
        }
    }
}
