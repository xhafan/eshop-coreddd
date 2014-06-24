using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace Eshop.Domain.UnitTests.Customers
{
    [TestFixture]
    public class when_placing_order : CustomerWithDeliveryAddressSetSetup
    {
        private Order _order;

        [SetUp]
        public override void Context()
        {
            base.Context();

            _order = Customer.PlaceOrder();
        }

        [Test]
        public void order_items_are_copied_from_basket_items()
        {
            _order.OrderItems.Count().ShouldBe(1);
            var orderItem = _order.OrderItems.First();
            orderItem.Order.ShouldBe(_order);
            orderItem.Product.ShouldBe(Product);
            orderItem.Quantity.ShouldBe(Quantity);
        }
        
        [Test]
        public void delivery_address_is_set()
        {
            _order.DeliveryAddress.ShouldBe(DeliveryAddress);
        }

        [Test]
        public void basket_is_empty()
        {
            Customer.BasketItems.ShouldBeEmpty();
        }
    }
}