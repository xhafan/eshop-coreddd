using Eshop.Domain;
using NUnit.Framework;
using Shouldly;

namespace Eshop.Commands.UnitTests.CustomerFactories
{
    [TestFixture]
    public class when_creating_customer
    {
        private Customer _customer;

        [SetUp]
        public void Context()
        {
            var factory = new CustomerFactory();

            _customer = factory.Create();
        }

        [Test]
        public void customer_is_created()
        {
            _customer.ShouldNotBe(null);
        }
    }
}