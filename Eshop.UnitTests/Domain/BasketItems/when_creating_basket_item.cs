using CoreTest;
using Eshop.Domain;
using NUnit.Framework;
using Shouldly;

namespace Eshop.UnitTests.Domain.BasketItems
{
    [TestFixture]
    public class when_creating_basket_item : BaseTest
    {
        private const int Count = 23;
        private BasketItem _basketItem;
        private Product _product;

        [SetUp]
        public void Context()
        {
            _product = Stub<Product>();

            _basketItem = new BasketItem(_product, Count);
        }

        [Test]
        public void properties_are_correctly_set()
        {
            _basketItem.Product.ShouldBe(_product);
            _basketItem.Count.ShouldBe(Count);
        }
    }
}
