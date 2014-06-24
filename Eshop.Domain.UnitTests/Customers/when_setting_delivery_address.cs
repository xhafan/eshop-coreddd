using NUnit.Framework;
using Shouldly;

namespace Eshop.Domain.UnitTests.Customers
{
    [TestFixture]
    public class when_setting_delivery_address : CustomerWithDeliveryAddressSetSetup
    {
        [Test]
        public void delivery_address_is_set()
        {
            Customer.DeliveryAddress.ShouldBe(DeliveryAddress);  
        }
    }
}