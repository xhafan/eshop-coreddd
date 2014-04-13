using NUnit.Framework;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Products.BasketItemViewModels
{
    [TestFixture]
    public class when_can_update_quantity : BasketItemViewModelSetup
    {
        [TestCase(34, false)]
        [TestCase(35, true)]
        public void can_update_quantity(int updatedQuantity, bool expectedCanUdateQuantity)
        {
            ViewModel.UpdatedQuantity = updatedQuantity;

            ViewModel.CanUpdateQuantity.ShouldBe(expectedCanUdateQuantity);
        }
    }
}