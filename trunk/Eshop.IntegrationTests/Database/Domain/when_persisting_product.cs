using Eshop.Domain;
using Eshop.Tests.Common.Builders;
using NUnit.Framework;
using Shouldly;

namespace Eshop.IntegrationTests.Database.Domain
{
    [TestFixture]
    public class when_persisting_product : BaseEshopSimplePersistenceTest
    {
        private Product _product;
        private Product _retrievedProduct;

        protected override void PersistenceContext()
        {
            _product = new ProductBuilder().Build();
            Save(_product);
        }

        protected override void PersistenceQuery()
        {
            _retrievedProduct = Get<Product>(_product.Id);
        }

        [Test]
        public void retrieved_product_is_the_same()
        {
            _retrievedProduct.ShouldBe(_product);
            _retrievedProduct.Name.ShouldBe(ProductBuilder.Name);
            _retrievedProduct.Description.ShouldBe(ProductBuilder.Description);
            _retrievedProduct.Price.ShouldBe(ProductBuilder.Price);
        }
    }
}