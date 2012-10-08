using CoreTest;
using Eshop.Domain;
using NUnit.Framework;
using Shouldly;

namespace Eshop.UnitTests.Domain.OrderItems
{
    [TestFixture]
    public class when_creating_order_item : BaseTest
    {
        private const int Count = 23;
        private OrderItem _orderItem;
        private Product _product;

        [SetUp]
        public void Context()
        {
            _product = Stub<Product>();

            _orderItem = new OrderItem(_product, Count);
        }

        [Test]
        public void properties_are_correctly_set()
        {
            _orderItem.Product.ShouldBe(_product);
            _orderItem.Count.ShouldBe(Count);
        }
    }
}
