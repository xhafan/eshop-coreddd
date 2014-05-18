using System.Threading.Tasks;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Products.ProductsViewModels
{
    [TestFixture]
    public class when_delivery_address_is_set : ProductsViewModelSetup
    {
        [SetUp]
        public async override void Context()
        {
            base.Context();
            ReviewOrder.Expect(x => x.LoadReviewOrderData()).Return(TaskEx.FromResult(0));

            await ViewModel.DeliveryAddressSet("delivery address");
        }

        [Test]
        public void review_order_loads_basket_items()
        {
            ReviewOrder.VerifyAllExpectations();
        }

        [Test]
        public void current_view_model_is_set()
        {
            ViewModel.CurrentViewModel.ShouldBe(ReviewOrder);
        }
    }
}