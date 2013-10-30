using System.Linq;
using CoreTest;
using NUnit.Framework;
using Shouldly;

namespace Eshop.Domain.UnitTests.Customers
{
    [TestFixture]
    public class when_adding_another_product_of_the_same_type_to_basket : BaseTest
    {
        private Customer _customer;
        private Product _product;

        [SetUp]
        public void Context()
        {
            _product = Stub<Product>();
            _customer = new Customer();
            _customer.AddProductToBasket(_product, 1);

            _customer.AddProductToBasket(_product, 1);
        }

        [Test]
        public void product_count_is_updated()
        {
            _customer.BasketItems.Count().ShouldBe(1);
            _customer.BasketItems.First().Count.ShouldBe(2);
        }
    }
}