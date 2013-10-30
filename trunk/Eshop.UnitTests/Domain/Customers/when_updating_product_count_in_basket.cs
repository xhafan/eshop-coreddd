using System.Linq;
using CoreTest;
using Eshop.Domain;
using NUnit.Framework;
using Shouldly;

namespace Eshop.UnitTests.Domain.Customers
{
    [TestFixture]
    public class when_updating_product_count_in_basket : BaseTest
    {
        private Customer _customer;
        private const int NewCount = 34;

        [SetUp]
        public void Context()
        {
            _customer = new Customer();
            var product = Stub<Product>();
            _customer.AddProductToBasket(product, 23);

            _customer.UpdateProductCountInBasket(product, NewCount);
        }

        [Test]
        public void count_is_updated_for_product()
        {
            _customer.BasketItems.First().Count.ShouldBe(NewCount);
        }
    }
}