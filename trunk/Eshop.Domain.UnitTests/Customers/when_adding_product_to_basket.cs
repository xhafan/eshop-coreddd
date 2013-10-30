using System.Linq;
using CoreTest;
using NUnit.Framework;
using Shouldly;

namespace Eshop.Domain.UnitTests.Customers
{
    [TestFixture]
    public class when_adding_product_to_basket : BaseTest
    {
        private const int Count = 23;
        private Customer _customer;
        private Product _product;

        [SetUp]
        public void Context()
        {
            _product = Stub<Product>();
            _customer = new Customer();

            _customer.AddProductToBasket(_product, Count);
        }

        [Test]
        public void product_is_added()
        {
            _customer.BasketItems.Count().ShouldBe(1);
            var basketItem = _customer.BasketItems.First();
            basketItem.Customer.ShouldBe(_customer);
            basketItem.Product.ShouldBe(_product);
            basketItem.Count.ShouldBe(Count);
        }
    }
}
