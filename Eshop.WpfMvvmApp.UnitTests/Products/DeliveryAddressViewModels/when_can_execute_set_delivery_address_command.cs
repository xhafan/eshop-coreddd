using NUnit.Framework;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Products.DeliveryAddressViewModels
{
    [TestFixture]
    public class when_can_execute_set_delivery_address_command : DeliveryAddressViewModelSetup
    {
        [TestCase("delivery address", true)]
        [TestCase("", false)]
        [TestCase(" ", false)]
        [TestCase(null, false)]
        public void can_execute(string deliveryAddress, bool expectedCanExecute)
        {
            ViewModel.SetDeliveryAddressCommand.CanExecute(deliveryAddress).ShouldBe(expectedCanExecute);
        }
    }
}