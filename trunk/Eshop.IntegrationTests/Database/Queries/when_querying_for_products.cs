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
        private const string ProductOneName = "product one name";
        private const string ProductTwoName = "product two name";

        protected override void PersistenceContext()
        {
            var productOne = new Product { Name = ProductOneName};
            var productTwo = new Product { Name = ProductTwoName };
            Save(productOne, productTwo);
        }

        protected override void PersistenceQuery()
        {
            var handler = new ProductsQueryHandler();
            _results = handler.Execute<ProductDto>(new ProductsQuery());
        }

        [Test]
        public void product_dtos_correctly_retrieved()
        {
            _results.Count().ShouldBe(2);
            _results.Any(x => x.Name == ProductOneName).ShouldBe(true);
            _results.Any(x => x.Name == ProductTwoName).ShouldBe(true);
        }
    }
}
