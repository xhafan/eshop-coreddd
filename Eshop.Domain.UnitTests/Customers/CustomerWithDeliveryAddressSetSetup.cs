using NUnit.Framework;

namespace Eshop.Domain.UnitTests.Customers
{
    public abstract class CustomerWithDeliveryAddressSetSetup : CustomerWithProductAddedToBasketSetup
    {
        protected const string DeliveryAddress = "delivery address";

        [SetUp]
        public override void Context()
        {
            base.Context();
            Customer.SetDeliveryAddress(DeliveryAddress);
        }
    }
}