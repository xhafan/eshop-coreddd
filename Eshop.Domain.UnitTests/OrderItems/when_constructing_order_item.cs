using CoreTest;
using NUnit.Framework;
using Shouldly;

namespace Eshop.Domain.UnitTests.OrderItems
{
    [TestFixture]
    public class when_constructing_order_item : BaseTest
    {
        private const int Count = 23;
        private OrderItem _orderItem;
        private Product _product;
        private Order _order;

        [SetUp]
        public void Context()
        {
            _product = Stub<Product>();
            _order = Stub<Order>();

            _orderItem = new OrderItem(_order, _product, Count);
        }

        [Test]
        public void properties_are_correctly_set()
        {
            _orderItem.Order.ShouldBe(_order);
            _orderItem.Product.ShouldBe(_product);
            _orderItem.Count.ShouldBe(Count);
        }
    }
}
