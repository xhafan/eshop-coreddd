using System.Collections.Generic;
using System.Linq;
using Eshop.Domain;
using Eshop.Dtos;
using Eshop.Queries;
using NUnit.Framework;
using Shouldly;

namespace Eshop.IntegrationTests.Database.Queries
{
    [TestFixture]
    public class when_querying_for_products : BaseEshopSimplePersistenceTest
    {
        private IEnumerable<ProductDto> _results;

        protected override void PersistenceContext()
        {
            var productOne = new Product { Name = "product one name"};
            var productTwo = new Product { Name = "product two name" };
            Save(productOne, productTwo);
        }

        protected override void PersistenceQuery()
        {
            var handler = new ProductsQueryHandler();
            _results = handler.Execute<ProductDto>(new ProductsQuery());
        }

        [Test]
        public void product_dto_correctly_retrieved()
        {
            _results.Count().ShouldBe(2);
            _results.Any(x => x.Name == "product one name").ShouldBe(true);
            _results.Any(x => x.Name == "product two name").ShouldBe(true);
        }
    }
}
