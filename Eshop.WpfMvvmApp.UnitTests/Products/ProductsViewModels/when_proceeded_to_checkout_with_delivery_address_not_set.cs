using System.Threading.Tasks;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Products.ProductsViewModels
{
    [TestFixture]
    public class when_proceeded_to_checkout_with_delivery_address_not_set : ProductsViewModelSetup
    {
        [SetUp]
        public async override void Context()
        {
            base.Context();
            DeliveryAddressControllerClient.Stubs(x => x.GetDeliveryAddressAsync()).Returns(TaskEx.FromResult(""));

            await ViewModel.ProceededToCheckout();
        }

        [Test]
        public void current_view_model_is_set()
        {
            ViewModel.CurrentViewModel.ShouldBe(DeliveryAddress);
        }
    }
}