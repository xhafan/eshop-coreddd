using CoreTest;
using Eshop.Domain;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace Eshop.UnitTests.Domain.Customers
{
    [TestFixture]
    public class when_updating_product_count_in_basket_to_zero : BaseTest
    {
        private Customer _customer;

        [SetUp]
        public void Context()
        {
            _customer = new Customer();
            var product = Stub<Product>();
            var basketItem = Stub<BasketItem>().Stubs(x => x.Product).Returns(product);
            _customer.BasketItems.AsSet().Add(basketItem);

            _customer.UpdateProductCountInBasket(product, 0);
        }

        [Test]
        public void basket_item_is_removed()
        {
            _customer.BasketItems.ShouldBeEmpty();
        }
    }
}