using System.Linq;
using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.WpfMvvmApp.UnitTests.Products.BasketViewModels
{
    [TestFixture]
    public class when_executing_update_product_quantity_command : BasketViewModelWithLoadedBasketItemsSetup
    {
        private const int UpdatedQuantity = 67;

        [SetUp]
        public override void Context()
        {
            base.Context();
            ViewModel.BasketItems.First(x => x.ProductId == ProductId).UpdatedQuantity = UpdatedQuantity;
            
            ViewModel.UpdateProductQuantityCommand.Execute(ProductId);
        }

        [Test]
        public void execute_updates_product_quantity()
        {
            BasketControllerClient.AssertWasCalled(x => x.UpdateProductQuantityAsync(ProductId, UpdatedQuantity));
        }
    }
}