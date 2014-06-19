using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Eshop.WpfMvvmApp.Products;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Chicago.Products.ProductsViewModels
{
    [TestFixture]
    public class when_updating_product_quantity_in_basket_to_zero : ProductsViewModelWithProductAddedToBasketSetup
    {
        private BasketItemViewModel _basketItem;
        private ObservableCollection<BasketItemViewModel> _basketItems;
        private const int UpdatedQuantity = 0;

        [SetUp]
        public override void Context()
        {
            base.Context();
            var basket = GetCurrentViewModelAsBasket();
            _basketItems = basket.BasketItems;
            _basketItem = _basketItems.First(x => x.ProductId == ProductOneId);
            _basketItem.UpdatedQuantity = UpdatedQuantity;
            BasketControllerClient.Expect(x => x.UpdateProductQuantityAsync(ProductOneId, UpdatedQuantity)).Return(TaskEx.FromResult(0));

            basket.UpdateProductQuantityCommand.Execute(ProductOneId);
        }

        [Test]
        public void execute_updates_product_quantity()
        {
            BasketControllerClient.VerifyAllExpectations();
        }

        [Test]
        public void product_is_removed()
        {
            _basketItems.ShouldNotContain(_basketItem);
        }
    }
}