using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace Eshop.Domain.UnitTests.Customers
{
    [TestFixture]
    public class when_adding_another_product_of_the_same_type_to_basket : CustomerWithProductAddedToBasketSetup
    {
        [SetUp]
        public override void Context()
        {
            base.Context();
            Customer.AddProductToBasket(Product, 2);
        }

        [Test]
        public void product_quantity_is_updated()
        {
            Customer.BasketItems.Count().ShouldBe(1);
            Customer.BasketItems.First().Quantity.ShouldBe(25);
        }
    }
}