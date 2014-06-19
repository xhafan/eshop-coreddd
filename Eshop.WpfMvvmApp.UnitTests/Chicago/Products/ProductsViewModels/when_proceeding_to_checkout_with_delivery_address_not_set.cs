using System.Threading.Tasks;
using Eshop.WpfMvvmApp.Products;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Chicago.Products.ProductsViewModels
{
    [TestFixture]
    public class when_proceeding_to_checkout_with_delivery_address_not_set : ProductsViewModelWithProductAddedToBasketSetup
    {
        [SetUp]
        public override void Context()
        {
            base.Context();
            DeliveryAddressControllerClient.Stubs(x => x.GetDeliveryAddressAsync()).Returns(TaskEx.FromResult(""));

            GetCurrentViewModelAsBasket().ProceedToCheckoutCommand.Execute(null);
        }

        [Test]
        public void current_view_model_is_set()
        {
            ViewModel.CurrentViewModel.ShouldBeTypeOf<DeliveryAddressViewModel2>();
        }
    }
}