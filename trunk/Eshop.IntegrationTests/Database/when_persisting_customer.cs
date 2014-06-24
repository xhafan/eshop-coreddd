using System.Linq;
using Eshop.Domain;
using Eshop.Tests.Common.Builders;
using NUnit.Framework;
using Shouldly;

namespace Eshop.IntegrationTests.Database
{
    [TestFixture]
    public class when_persisting_customer : BaseEshopSimplePersistenceTest
    {
        private Customer _customer;
        private Customer _retrievedCustomer;
        private Product _product;

        protected override void PersistenceContext()
        {
            _product = new ProductBuilder().Build();
            _customer = new CustomerBuilder()
                .WithProductInBasket(_product, 23)
                .Build();
            Save(_product, _customer);
        }

        protected override void PersistenceQuery()
        {
            _retrievedCustomer = Get<Customer>(_customer.Id);
        }

        [Test]
        public void properties_are_correctly_set()
        {
            _retrievedCustomer.ShouldBe(_customer);
            _retrievedCustomer.DeliveryAddress.ShouldBe(_customer.DeliveryAddress);
        }

        [Test]
        public void basket_items_are_retrieved_correctly()
        {
            _retrievedCustomer.BasketItems.Count().ShouldBe(1);
            var basketItem = _retrievedCustomer.BasketItems.First();
            basketItem.ShouldBe(_customer.BasketItems.First()); 
            basketItem.Customer.ShouldBe(_customer);
            basketItem.Product.ShouldBe(_product);
            basketItem.Quantity.ShouldBe(23);
        }
    }
}
