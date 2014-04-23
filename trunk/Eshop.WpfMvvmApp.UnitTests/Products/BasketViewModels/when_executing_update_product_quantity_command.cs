using System.Linq;
using System.Threading.Tasks;
using Eshop.WpfMvvmApp.Products;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Products.BasketViewModels
{
    [TestFixture]
    public class when_executing_update_product_quantity_command : BasketViewModelWithLoadedBasketItemsSetup
    {
        private BasketItemViewModel _basketItem;
        private const int UpdatedQuantity = 67;

        [SetUp]
        public override void Context()
        {
            base.Context();
            _basketItem = ViewModel.BasketItems.First(x => x.ProductId == ProductOneId);
            _basketItem.UpdatedQuantity = UpdatedQuantity;
            BasketControllerClient.Expect(x => x.UpdateProductQuantityAsync(ProductOneId, UpdatedQuantity)).Return(TaskEx.FromResult(0));
            
            ViewModel.UpdateProductQuantityCommand.Execute(ProductOneId);
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
    }
}