using CoreTest;
using Eshop.Domain;
using NUnit.Framework;
using Shouldly;

namespace Eshop.UnitTests.Domain.BasketItems
{
    [TestFixture]
    public class when_adding_count : BaseTest
    {
        private BasketItem _basketItem;

        [SetUp]
        public void Context()
        {
            _basketItem = new BasketItem(Stub<Product>(), 1);

            _basketItem.AddCount(1);
        }

        [Test]
        public void count_is_updated()
        {
            _basketItem.Count.ShouldBe(2);
        }
    }
}