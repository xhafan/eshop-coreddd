using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace Eshop.Domain.UnitTests.Customers
{
    [TestFixture]
    public class when_adding_product_to_basket : CustomerWithProductAddedToBasketSetup
    {
        [Test]
        public void product_is_added()
        {
            Customer.BasketItems.Count().ShouldBe(1);
            var basketItem = Customer.BasketItems.First();
            basketItem.Customer.ShouldBe(Customer);
            basketItem.Product.ShouldBe(Product);
            basketItem.Quantity.ShouldBe(Quantity);
        }
    }
}
