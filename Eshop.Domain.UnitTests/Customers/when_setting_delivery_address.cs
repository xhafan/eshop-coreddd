using CoreTest;
using NUnit.Framework;
using Shouldly;

namespace Eshop.Domain.UnitTests.Customers
{
    [TestFixture]
    public class when_setting_delivery_address : BaseTest
    {
        private const string DeliveryAddress = "delivery address";
        private Customer _customer;

        [SetUp]
        public void Context()
        {
            _customer = new Customer();

            _customer.SetDeliveryAddress(DeliveryAddress);
        }

        [Test]
        public void delivery_address_is_set()
        {
            _customer.DeliveryAddress.ShouldBe(DeliveryAddress);  
        }
    }
}