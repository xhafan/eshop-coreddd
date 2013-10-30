using CoreTest;
using Eshop.Domain;
using NUnit.Framework;
using Shouldly;

namespace Eshop.UnitTests.Domain.BasketItems
{
    [TestFixture]
    public class when_constructing_basket_item : BaseTest
    {
        private const int Count = 23;
        private BasketItem _basketItem;
        private Product _product;
        private Customer _customer;

        [SetUp]
        public void Context()
        {
            _product = Stub<Product>();
            _customer = Stub<Customer>();

            _basketItem = new BasketItem(_customer, _product, Count);
        }

        [Test]
        public void properties_are_correctly_set()
        {
            _basketItem.Customer.ShouldBe(_customer);
            _basketItem.Product.ShouldBe(_product);
            _basketItem.Count.ShouldBe(Count);
        }
    }
}
