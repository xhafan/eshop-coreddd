using NUnit.Framework;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Products.BasketItemViewModels
{
    [TestFixture]
    public class when_constructing : BasketItemViewModelSetup
    {
        [Test]
        public void product_id_is_set()
        {
            ViewModel.ProductId.ShouldBe(ProductId);
        }

        [Test]
        public void product_name_is_set()
        {
            ViewModel.ProductName.ShouldBe(ProductName);
        }

        [Test]
        public void price_is_set()
        {
            ViewModel.ProductPrice.ShouldBe(ProductPrice);
        }

        [Test]
        public void quantity_is_set()
        {
            ViewModel.Quantity.ShouldBe(Quantity);
        }

        [Test]
        public void update_quantity_is_set()
        {
            ViewModel.UpdatedQuantity.ShouldBe(Quantity);
        }
    }
}