using System.Threading.Tasks;
using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.WpfMvvmApp.UnitTests.Products.ProductDetailsViewModels
{
    [TestFixture]
    public class when_executing_add_to_basket_command : ProductDetailsViewModelWithLoadedProductSetup
    {
        [SetUp]
        public override void Context()
        {
            base.Context();
            BasketControllerClient.Expect(x => x.AddProductToBasketAsync(ProductId, Quantity)).Return(TaskEx.FromResult(0));

            ViewModel.AddToBasketCommand.Execute(Quantity);
        }

        [Test]
        public void execute_adds_product_to_basket()
        {
            BasketControllerClient.VerifyAllExpectations();
        }

        [Test]
        public void product_added_to_basket_service_is_notified()
        {
            ProductAddedToBasket.AssertWasCalled(x => x.ProductAddedToBasket());
        }
    }
}