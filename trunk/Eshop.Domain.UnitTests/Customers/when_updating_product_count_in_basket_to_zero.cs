using CoreTest;
using NUnit.Framework;
using Shouldly;

namespace Eshop.Domain.UnitTests.Customers
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
            _customer.AddProductToBasket(product, 23);

            _customer.UpdateProductCountInBasket(product, 0);
        }

        [Test]
        public void basket_item_is_removed()
        {
            _customer.BasketItems.ShouldBeEmpty();
        }
    }
}