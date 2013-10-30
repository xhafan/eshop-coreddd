using CoreTest;
using NUnit.Framework;
using Shouldly;

namespace Eshop.Domain.UnitTests.Products
{
    [TestFixture]
    public class when_constructing_product : BaseTest
    {
        private Product _product;
        private const string ProductName = "product name";

        [SetUp]
        public void Context()
        {
            _product = new Product(ProductName);
        }

        [Test]
        public void name_is_set()
        {
            _product.Name.ShouldBe(ProductName);
        }
    }
}
