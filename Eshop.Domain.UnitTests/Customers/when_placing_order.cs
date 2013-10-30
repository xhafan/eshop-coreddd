using System.Linq;
using CoreTest;
using NUnit.Framework;
using Shouldly;

namespace Eshop.Domain.UnitTests.Customers
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
            _customer = new Customer();
            _customer.AddProductToBasket(Stub<Product>(), 1);                
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