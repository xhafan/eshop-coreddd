using System.Linq;
using Eshop.Domain;
using Eshop.Tests.Common.Builders;
using NUnit.Framework;
using Shouldly;

namespace Eshop.IntegrationTests.Database
{
    [TestFixture]
    public class when_persisting_order : BaseEshopSimplePersistenceTest
    {
        private Order _order;
        private Order _retrievedOrder;
        private Product _product;

        protected override void PersistenceContext()
        {
            _product = new ProductBuilder().Build();
            var customer = new CustomerBuilder().Build();
            _order = new OrderBuilder()
                .WithCustomer(customer)
                .WithProduct(_product)
                .Build();
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
            _retrievedOrder.DeliveryAddress.ShouldBe(OrderBuilder.DeliveryAddress);
        }

        [Test]
        public void order_items_are_retrieved_correctly()
        {
            _retrievedOrder.OrderItems.Count().ShouldBe(1);
            var orderItem = _retrievedOrder.OrderItems.First();
            orderItem.ShouldBe(_order.OrderItems.First());
            orderItem.Order.ShouldBe(_order);
            orderItem.Product.ShouldBe(_product);
            orderItem.Quantity.ShouldBe(BasketItemBuilder.Quantity);
        }
    }
}