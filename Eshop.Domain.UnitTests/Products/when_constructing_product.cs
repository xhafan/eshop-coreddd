using Eshop.Tests.Common.Builders;
using NUnit.Framework;
using Shouldly;

namespace Eshop.Domain.UnitTests.Products
{
    [TestFixture]
    public class when_constructing_product
    {
        private Product _product;

        [SetUp]
        public void Context()
        {
            _product = new ProductBuilder().Build();
        }

        [Test]
        public void name_is_set()
        {
            _product.Name.ShouldBe(ProductBuilder.Name);
        }

        [Test]
        public void description_is_set()
        {
            _product.Description.ShouldBe(ProductBuilder.Description);
        }

        [Test]
        public void price_is_set()
        {
            _product.Price.ShouldBe(ProductBuilder.Price);
        }    
    }
}
