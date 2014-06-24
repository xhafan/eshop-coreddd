using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace Eshop.Domain.UnitTests.Customers
{
    [TestFixture]
    public class when_updating_product_quantity_in_basket : CustomerWithProductAddedToBasketSetup
    {
        private const int NewQuantity = 34;

        [SetUp]
        public override void Context()
        {
            base.Context();

            Customer.UpdateProductQuantityInBasket(Product, NewQuantity);
        }

        [Test]
        public void quantity_is_updated_for_product()
        {
            Customer.BasketItems.First(x => x.Product == Product).Quantity.ShouldBe(NewQuantity);
        }
    }
}