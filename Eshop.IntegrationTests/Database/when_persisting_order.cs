using System.Linq;
using CoreTest;
using Eshop.Domain;
using NUnit.Framework;
using Shouldly;

namespace Eshop.IntegrationTests.Database
{
    [TestFixture]
    public class when_persisting_order : BaseEshopSimplePersistenceTest
    {
        private const string DeliveryAddress = "delivery address";
        private const int Count = 23;
        private Order _order;
        private Order _retrievedOrder;
        private Product _product;
        private OrderItem _orderItem;

        protected override void PersistenceContext()
        {
            _product = new Product();
            _order = new Order { DeliveryAddress = DeliveryAddress };
            _orderItem = new OrderItem(_order, _product, Count);
            _order.OrderItems.AsSet().Add(_orderItem);
            Save(_product, _order);
        }

        protected override void PersistenceQuery()
        {
            _retrievedOrder = Get<Order>(_order.Id);
        }

        [Test]
        public void properties_are_correctly_set()
        {
            _retrievedOrder.ShouldBe(_order);
            _retrievedOrder.DeliveryAddress.ShouldBe(_order.DeliveryAddress);
        }

        [Test]
        public void order_items_are_retrieved_correctly()
        {
            _retrievedOrder.OrderItems.Count().ShouldBe(1);
            var orderItem = _retrievedOrder.OrderItems.First();
            orderItem.ShouldBe(_orderItem);
            orderItem.Order.ShouldBe(_order);
            orderItem.Product.ShouldBe(_product);
            orderItem.Count.ShouldBe(Count);
        }
    }
}