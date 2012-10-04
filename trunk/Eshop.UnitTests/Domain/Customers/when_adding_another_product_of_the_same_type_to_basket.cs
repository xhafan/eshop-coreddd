using System.Linq;
using CoreTest;
using Eshop.Domain;
using NUnit.Framework;
using Shouldly;
using Rhino.Mocks;

namespace Eshop.UnitTests.Domain.Customers
{
    [TestFixture]
    public class when_adding_another_product_of_the_same_type_to_basket : BaseTest
    {
        private const int Count = 23;
        private Customer _customer;
        private Product _product;
        private BasketItem _basketItem;

        [SetUp]
        public void Context()
        {
            _product = Stub<Product>();
            _customer = new Customer();
            _basketItem = Mock<BasketItem>()
                .Stubs(x => x.Product).Returns(_product)
                .Stubs(x => x.Count).Returns(1);
            _customer._basketItems.Add(_basketItem);

            _customer.AddProductToBasket(_product, Count);
        }

        [Test]
        public void product_count_is_updated()
        {
            _customer.BasketItems.Count().ShouldBe(1);
            _basketItem.AssertWasCalled(x => x.AddCount(Count));
        }
    }
}