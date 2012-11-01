using CoreTest;
using Eshop.Domain;
using NUnit.Framework;
using Shouldly;

namespace Eshop.UnitTests.Domain.BasketItems
{
    [TestFixture]
    public class when_updating_count : BaseTest
    {
        private BasketItem _basketItem;

        [SetUp]
        public void Context()
        {
            _basketItem = new BasketItem(Stub<Customer>(), Stub<Product>(), 1);

            _basketItem.UpdateCount(23);
        }

        [Test]
        public void count_is_updated()
        {
            _basketItem.Count.ShouldBe(23);
        }
    }
}