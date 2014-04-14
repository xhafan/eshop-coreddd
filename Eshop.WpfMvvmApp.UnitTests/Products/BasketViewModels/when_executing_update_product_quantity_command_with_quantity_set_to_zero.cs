using System.Linq;
using System.Threading.Tasks;
using Eshop.WpfMvvmApp.Products;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Products.BasketViewModels
{
    [TestFixture]
    public class when_executing_update_product_quantity_command_with_quantity_set_to_zero : BasketViewModelWithLoadedBasketItemsSetup
    {
        private BasketItemViewModel _basketItem;
        private const int UpdatedQuantity = 0;

        [SetUp]
        public override void Context()
        {
            base.Context();
            _basketItem = ViewModel.BasketItems.First(x => x.ProductId == ProductId);
            _basketItem.UpdatedQuantity = UpdatedQuantity;
            BasketControllerClient.Expect(x => x.UpdateProductQuantityAsync(ProductId, UpdatedQuantity)).Return(TaskEx.FromResult(0));
            
            ViewModel.UpdateProductQuantityCommand.Execute(ProductId);
        }

        [Test]
        public void execute_updates_product_quantity()
        {
            BasketControllerClient.VerifyAllExpectations();
        }

        [Test]
        public void product_is_removed()
        {
            ViewModel.BasketItems.ShouldNotContain(_basketItem);
        }
    }
}