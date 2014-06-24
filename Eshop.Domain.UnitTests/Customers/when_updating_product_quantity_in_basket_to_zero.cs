using NUnit.Framework;
using Shouldly;

namespace Eshop.Domain.UnitTests.Customers
{
    [TestFixture]
    public class when_updating_product_quantity_in_basket_to_zero : CustomerWithProductAddedToBasketSetup
    {
        [SetUp]
        public override void Context()
        {
            base.Context();

            Customer.UpdateProductQuantityInBasket(Product, 0);
        }

        [Test]
        public void basket_item_is_removed()
        {
            Customer.BasketItems.ShouldBeEmpty();
        }
    }
}