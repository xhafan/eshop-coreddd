using System.Linq;
using CoreTest;
using Eshop.Domain;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace Eshop.UnitTests.Domain.Orders
{
    [TestFixture]
    public class when_constructing_order : BaseTest
    {
        private Product _product;
        private Order _order;
        private const int Count = 23;
        private const string DeliveryAddress = "delivery address";

        [SetUp]
        public void Context()
        {
            _product = Stub<Product>();
            var basketItem = Stub<BasketItem>()
                .Stubs(x => x.Product).Returns(_product)
                .Stubs(x => x.Count).Returns(Count);
            _order = new Order(new[] { basketItem }, DeliveryAddress);
        }

        [Test]
        public void order_items_are_copied_from_basket_items()
        {
            _order.OrderItems.Count().ShouldBe(1);
            var orderItem = _order.OrderItems.First();
            orderItem.Order.ShouldBe(_order);
            orderItem.Product.ShouldBe(_product);
            orderItem.Count.ShouldBe(Count);
        }

        [Test]
        public void delivery_address_is_set()
        {
            _order.DeliveryAddress.ShouldBe(DeliveryAddress);
        }
    }
}
