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
    public class when_querying_for_basket_items : BaseEshopSimplePersistenceTest
    {
        private IEnumerable<BasketItemDto> _results;
        private Customer _customer;
        private Product _productOne;
        private Product _productTwo;
        private const string ProductOneName = "product one name";
        private const string ProductTwoName = "product two name";
        private const int ProductOneQuantity = 23;
        private const int ProductTwoQuantity = 24;
        private const decimal ProductOnePrice = 45.6m;
        private const decimal ProductTwoPrice = 56.7m;

        protected override void PersistenceContext()
        {
            _productOne = new ProductBuilder()
                .WithName(ProductOneName)
                .WithPrice(ProductOnePrice)
                .Build();
            _productTwo = new ProductBuilder()
                .WithName(ProductTwoName)
                .WithPrice(ProductTwoPrice)
                .Build();
            _customer = new CustomerBuilder()
                .WithProductInBasket(_productOne, ProductOneQuantity)
                .WithProductInBasket(_productTwo, ProductTwoQuantity)
                .Build();
            var anotherCustomer = new CustomerBuilder()
                .WithProductInBasket(_productOne, ProductOneQuantity)
                .Build();

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
            result.ProductPrice.ShouldBe(ProductOnePrice);
            result.Quantity.ShouldBe(ProductOneQuantity);
            
            result = _results.Last();
            result.CustomerId.ShouldBe(_customer.Id);
            result.ProductId.ShouldBe(_productTwo.Id);
            result.ProductName.ShouldBe(ProductTwoName);
            result.ProductPrice.ShouldBe(ProductTwoPrice);
            result.Quantity.ShouldBe(ProductTwoQuantity);
        }
    }
}