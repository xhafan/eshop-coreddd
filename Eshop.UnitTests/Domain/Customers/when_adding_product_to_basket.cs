using System.Linq;
using CoreTest;
using Eshop.Domain;
using NUnit.Framework;
using Shouldly;

namespace Ehop.UnitTests.Domain.Customers
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
            basketItem.Product.ShouldBeSameAs(_product);
            basketItem.Count.ShouldBe(Count);
        }
    }
}
