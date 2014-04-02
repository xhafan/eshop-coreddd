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
        private const string ProductDescription = "product description";
        private const decimal Price = 23.4m;

        [SetUp]
        public void Context()
        {
            _product = new Product(ProductName, ProductDescription, Price);
        }

        [Test]
        public void name_is_set()
        {
            _product.Name.ShouldBe(ProductName);
        }

        [Test]
        public void description_is_set()
        {
            _product.Description.ShouldBe(ProductDescription);
        }

        [Test]
        public void price_is_set()
        {
            _product.Price.ShouldBe(Price);
        }    
    }
}
