using CoreTest;
using Eshop.Domain;
using NUnit.Framework;
using Shouldly;

namespace Eshop.UnitTests.Domain.Products
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
