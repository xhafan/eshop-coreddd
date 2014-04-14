using NUnit.Framework;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Products.BasketItemViewModels
{
    [TestFixture]
    public class when_getting_update_action : BasketItemViewModelSetup
    {
        [TestCase(0, "Remove")]
        [TestCase(35, "Update")]
        public void update_action(int updatedQuantity, string expectedUpdateAction)
        {
            ViewModel.UpdatedQuantity = updatedQuantity;

            ViewModel.UpdateAction.ShouldBe(expectedUpdateAction);
        }
    }
}