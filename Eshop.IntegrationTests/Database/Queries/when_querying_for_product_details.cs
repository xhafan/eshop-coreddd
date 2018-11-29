using System.Collections.Generic;
using System.Linq;
using CoreDdd.Nhibernate.TestHelpers;
using Eshop.Domain;
using Eshop.Dtos;
using Eshop.Queries;
using Eshop.Tests.Common.Builders;
using NUnit.Framework;
using Shouldly;

namespace Eshop.IntegrationTests.Database.Queries
{
    [TestFixture]
    public class when_querying_for_product_details : BasePersistenceTest
    {
        private IEnumerable<ProductDto> _results;
        private Product _product;

        [SetUp]
        public void Context()
        {
            _product = new ProductBuilder().Build();
            UnitOfWork.Save(_product);


            var handler = new ProductDetailsQueryHandler(UnitOfWork);
            _results = handler.Execute<ProductDto>(new ProductDetailsQuery { ProductId = _product.Id });
        }

        [Test]
        public void dtos_correctly_retrieved()
        {
            _results.Count().ShouldBe(1);
            var dto = _results.First();
            dto.Id.ShouldBe(_product.Id);
            dto.Name.ShouldBe(ProductBuilder.Name);
            dto.Description.ShouldBe(ProductBuilder.Description);
            dto.Price.ShouldBe(ProductBuilder.Price);
        }
    }
}