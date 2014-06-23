using System.Collections.Generic;
using System.Linq;
using Eshop.Domain;
using Eshop.Dtos;
using Eshop.Queries;
using Eshop.Tests.Common.Builders;
using NUnit.Framework;
using Shouldly;

namespace Eshop.IntegrationTests.Database.Queries
{
    [TestFixture]
    public class when_querying_for_products : BaseEshopSimplePersistenceTest
    {
        private IEnumerable<ProductSummaryDto> _results;
        private Product _productOne;
        private Product _productTwo;
        private const string ProductOneName = "product one name";
        private const string ProductTwoName = "product two name";

        protected override void PersistenceContext()
        {
            _productOne = new ProductBuilder().WithName(ProductOneName).Build();
            _productTwo = new ProductBuilder().WithName(ProductTwoName).Build();
            Save(_productOne, _productTwo);
        }

        protected override void PersistenceQuery()
        {
            var handler = new ProductsQueryHandler();
            _results = handler.Execute<ProductSummaryDto>(new ProductsQuery { SearchText = "one" });
        }

        [Test]
        public void dtos_correctly_retrieved()
        {
            _results.Count().ShouldBe(1);
            var dto = _results.First();
            dto.Id.ShouldBe(_productOne.Id);
            dto.Name.ShouldBe(ProductOneName);
        }
    }
}
