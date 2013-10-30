using System.Collections.Generic;
using System.Linq;
using CoreTest;
using Eshop.Domain;
using Eshop.Dtos;
using Eshop.IntegrationTests.Database.ObjectMothers;
using Eshop.Queries;
using NUnit.Framework;
using Shouldly;

namespace Eshop.IntegrationTests.Database.Queries
{
    [TestFixture]
    public class when_querying_for_basket_items : BaseEshopSimplePersistenceTest
    {
        private IEnumerable<BasketItemDto> _results;
        private Customer _customer;
        private Product _productOne;
        private Product _productTwo;
        private const string ProductOneName = "product one name";
        private const string ProductTwoName = "product two name";
        private const int ProductOneCount = 23;
        private const int ProductTwoCount = 24;

        protected override void PersistenceContext()
        {
            _productOne = new ProductObjectMother().NewEntity(ProductOneName);
            _productTwo = new ProductObjectMother().NewEntity(ProductTwoName);
            _customer = new CustomerObjectMother().NewEntity();
            _customer.BasketItems.AsSet().AddAll(new[]
                                                    {
                                                        new BasketItemObjectMother().NewEntity(_customer, _productOne, ProductOneCount),
                                                        new BasketItemObjectMother().NewEntity(_customer, _productTwo, ProductTwoCount),
                                                    });
            var anotherCustomer = new CustomerObjectMother().NewEntity();
            anotherCustomer.BasketItems.AsSet().AddAll(new[] { new BasketItemObjectMother().NewEntity(anotherCustomer, _productOne, ProductOneCount) });

            Save(_productOne, _productTwo, _customer, anotherCustomer);
        }

        protected override void PersistenceQuery()
        {
            var handler = new BasketItemsQueryHandler();
            _results = handler.Execute<BasketItemDto>(new BasketItemsQuery { CustomerId = _customer.Id });
        }

        [Test]
        public void basket_item_dtos_correctly_retrieved()
        {
            _results.Count().ShouldBe(2);

            var result = _results.First();
            result.CustomerId.ShouldBe(_customer.Id);
            result.ProductId.ShouldBe(_productOne.Id);
            result.ProductName.ShouldBe(ProductOneName);
            result.Count.ShouldBe(ProductOneCount);
            
            result = _results.Last();
            result.CustomerId.ShouldBe(_customer.Id);
            result.ProductId.ShouldBe(_productTwo.Id);
            result.ProductName.ShouldBe(ProductTwoName);
            result.Count.ShouldBe(ProductTwoCount);
        }
    }
}