using System.Linq;
using CoreTest;
using Eshop.Domain;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace Eshop.UnitTests.Domain.Customers
{
    [TestFixture]
    public class when_updating_product_count_in_basket : BaseTest
    {
        private Customer _customer;
        private BasketItem _basketItem;
        private const int NewCount = 34;

        [SetUp]
        public void Context()
        {
            _customer = new Customer();
            var product = Stub<Product>();
            _basketItem = Mock<BasketItem>().Stubs(x => x.Product).Returns(product);
            _customer.BasketItems.AsSet().Add(_basketItem);

            _customer.UpdateProductCountInBasket(product, NewCount);
        }

        [Test]
        public void count_is_updated_for_product()
        {
            _basketItem.AssertWasCalled(x => x.UpdateCount(NewCount));
        }
    }
}