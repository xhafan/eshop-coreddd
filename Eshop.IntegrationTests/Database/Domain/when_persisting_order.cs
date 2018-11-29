using System.Linq;
using CoreDdd.Nhibernate.TestHelpers;
using Eshop.Domain;
using Eshop.Tests.Common.Builders;
using NUnit.Framework;
using Shouldly;

namespace Eshop.IntegrationTests.Database.Domain
{
    [TestFixture]
    public class when_persisting_order : BasePersistenceTest
    {
        private const int ProductQuantity = 23;
        private Order _order;
        private Order _retrievedOrder;
        private Product _product;

        [SetUp]
        public void Context()
        {
            _product = new ProductBuilder().Build();
            var customer = new CustomerBuilder()
                .WithProductInBasket(_product, ProductQuantity)
                .WithDeliveryAddress()
                .Build();
            _order = new OrderBuilder()
                .WithCustomer(customer)
                .Build();
            UnitOfWork.Save(_product);
            UnitOfWork.Save(_order);


            _retrievedOrder = UnitOfWork.Get<Order>(_order.Id);
        }

        [Test]
        public void properties_are_correctly_set()
        {
            _retrievedOrder.ShouldBe(_order);
            _retrievedOrder.DeliveryAddress.ShouldBe(CustomerBuilder.DeliveryAddress);
        }

        [Test]
        public void order_items_are_retrieved_correctly()
        {
            _retrievedOrder.OrderItems.Count().ShouldBe(1);
            var orderItem = _retrievedOrder.OrderItems.First();
            orderItem.ShouldBe(_order.OrderItems.First());
            orderItem.Order.ShouldBe(_order);
            orderItem.Product.ShouldBe(_product);
            orderItem.Quantity.ShouldBe(ProductQuantity);
        }
    }
}