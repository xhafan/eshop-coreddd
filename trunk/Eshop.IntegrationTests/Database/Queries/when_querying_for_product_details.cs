﻿using System.Collections.Generic;
using System.Linq;
using Eshop.Domain;
using Eshop.Dtos;
using Eshop.IntegrationTests.Database.ObjectMothers;
using Eshop.Queries;
using NUnit.Framework;
using Shouldly;

namespace Eshop.IntegrationTests.Database.Queries
{
    [TestFixture]
    public class when_querying_for_product_details : BaseEshopSimplePersistenceTest
    {
        private IEnumerable<ProductDto> _results;
        private Product _product;
        private const string ProductName = "product name";
        private const string ProductDescription = "product name";

        protected override void PersistenceContext()
        {
            _product = new ProductObjectMother().NewEntity(ProductName, ProductDescription);
            Save(_product);
        }

        protected override void PersistenceQuery()
        {
            var handler = new ProductDetailsQueryHandler();
            _results = handler.Execute<ProductDto>(new ProductDetailsQuery { ProductId = _product.Id });
        }

        [Test]
        public void dtos_correctly_retrieved()
        {
            _results.Count().ShouldBe(1);
            var dto = _results.First();
            dto.Id.ShouldBe(_product.Id);
            dto.Name.ShouldBe(ProductName);
            dto.Description.ShouldBe(ProductDescription);
        }
    }
}