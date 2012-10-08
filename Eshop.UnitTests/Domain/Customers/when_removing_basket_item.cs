using CoreTest;
using Eshop.Domain;
using NUnit.Framework;
using Shouldly;

namespace Eshop.UnitTests.Domain.Customers
{
    [TestFixture]
    public class when_removing_basket_item : BaseTest
    {
        private Customer _customer;

        [SetUp]
        public void Context()
        {
            _customer = new Customer();
            var basketItem = Stub<BasketItem>();                
            _customer._basketItems.Add(basketItem);

            _customer.RemoveFromBasket(basketItem);
        }

        [Test]
        public void item_is_removed()
        {
            _customer.BasketItems.ShouldBeEmpty();  
        }
    }
}