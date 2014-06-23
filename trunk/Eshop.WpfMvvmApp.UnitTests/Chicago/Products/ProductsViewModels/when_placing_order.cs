using System.Threading.Tasks;
using Eshop.WpfMvvmApp.Products;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Chicago.Products.ProductsViewModels
{
    [TestFixture]
    public class when_placing_order : ProductsViewModelWithProductAddedToBasketSetup
    {
        [SetUp]
        public override void Context()
        {
            base.Context();
            StubExistingDeliveryAddressOnControllerClient();
            StubReviewOrderDataOnControllerClient();
            ProceedToCheckout();
            
            ExpectPlacingOrderOnControllerClient();

            GetCurrentViewModelAsReviewOrder().PlaceOrderCommand.Execute(null);
        }

        [Test]
        public void order_is_placed()
        {
            OrderControllerClient.VerifyAllExpectations();
        }

        [Test]
        public void current_view_model_is_set()
        {
            ViewModel.CurrentViewModel.ShouldBeTypeOf<OrderPlacedViewModel>();
        }

        private void ExpectPlacingOrderOnControllerClient()
        {
            OrderControllerClient.Expect(x => x.PlaceOrderAsync(Arg<object>.Is.Anything)).Return(TaskEx.FromResult(0));
        }
    }
}