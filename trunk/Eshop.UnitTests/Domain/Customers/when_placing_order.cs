using System.Linq;
using CoreTest;
using Eshop.Domain;
using NUnit.Framework;
using Shouldly;

namespace Eshop.UnitTests.Domain.Customers
{
    [TestFixture]
    public class when_placing_order : BaseTest
    {
        private const string DeliveryAddress = "delivery address";
        private Customer _customer;
        private Order _order;

        [SetUp]
        public void Context()
        {
            var basketItem = Stub<BasketItem>();
            _customer = new Customer();
            _customer.BasketItems.AsSet().Add(basketItem);
            _customer.SetDeliveryAddress(DeliveryAddress);

            _order = _customer.PlaceOrder();
        }

        [Test]
        public void order_contains_basket_items()
        {
            _order.OrderItems.Count().ShouldBe(1);
        }
        
        [Test]
        public void delivery_address_is_set()
        {
            _order.DeliveryAddress.ShouldBe(DeliveryAddress);
        }

        [Test]
        public void basket_is_empty()
        {
            _customer.BasketItems.ShouldBeEmpty();
        }
    }
}