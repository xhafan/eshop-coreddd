﻿using System.Linq;
using CoreTest;
using Eshop.Domain;
using NUnit.Framework;
using Shouldly;

namespace Eshop.IntegrationTests.Database
{
    [TestFixture]
    public class when_persisting_customer : BaseEshopSimplePersistenceTest
    {
        private const string DeliveryAddress = "delivery address";
        private Customer _customer;
        private Customer _retrievedCustomer;
        private Product _product;
        private BasketItem _basketItem;
        private const int Count = 23;

        protected override void PersistenceContext()
        {
            _product = new Product();
            _customer = new Customer { DeliveryAddress = DeliveryAddress };
            _basketItem = new BasketItem(_customer, _product, Count);
            _customer.BasketItems.AsSet().Add(_basketItem);
            Save(_product, _customer);
        }

        protected override void PersistenceQuery()
        {
            _retrievedCustomer = Get<Customer>(_customer.Id);
        }

        [Test]
        public void properties_are_correctly_set()
        {
            _retrievedCustomer.ShouldBe(_customer);
            _retrievedCustomer.DeliveryAddress.ShouldBe(_customer.DeliveryAddress);
        }

        [Test]
        public void basket_items_are_retrieved_correctly()
        {
            _retrievedCustomer.BasketItems.Count().ShouldBe(1);
            var basketItem = _retrievedCustomer.BasketItems.First();
            basketItem.ShouldBe(_basketItem);
            basketItem.Customer.ShouldBe(_customer);
            basketItem.Product.ShouldBe(_product);
            basketItem.Count.ShouldBe(Count);
        }
    }
}