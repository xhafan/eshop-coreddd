using System.Linq;
using System.Threading.Tasks;
using Eshop.WpfMvvmApp.Products;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Products
{
    [TestFixture]
    public class when_updating_product_quantity_in_basket : ProductsViewModelWithProductAddedToBasketSetup
    {
        private BasketItemViewModel _basketItem;
        private BasketViewModel _basket;
        private const int UpdatedQuantity = 4;

        [SetUp]
        public override void Context()
        {
            base.Context();
            _basket = GetCurrentViewModelAsBasket();
            _basketItem = _basket.BasketItems.First(x => x.ProductId == ProductOneId);
            _basketItem.UpdatedQuantity = UpdatedQuantity;
            BasketControllerClient.Expect(x => x.UpdateProductQuantityAsync(ProductOneId, UpdatedQuantity)).Return(TaskEx.FromResult(0));

            _basket.UpdateProductQuantityCommand.Execute(ProductOneId);
        }

        [Test]
        public void execute_updates_product_quantity()
        {
            BasketControllerClient.VerifyAllExpectations();
        }

        [Test]
        public void product_quantity_is_updated()
        {
            _basketItem.Quantity.ShouldBe(UpdatedQuantity);
        }

        [Test]
        public void basket_subtotal_is_refreshed()
        {
            _basket.Subtotal.ShouldBe(311.4m);
        }
    }
}