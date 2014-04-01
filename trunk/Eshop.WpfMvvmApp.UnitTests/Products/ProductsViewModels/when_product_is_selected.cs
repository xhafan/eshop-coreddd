using System.Threading.Tasks;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Products.ProductsViewModels
{
    [TestFixture]
    public class when_product_is_selected : ProductsViewModelSetup
    {
        private const int ProductId = 23;

        [SetUp]
        public async override void Context()
        {
            base.Context();
            ProductDetails.Expect(x => x.LoadProduct(ProductId)).Return(TaskEx.FromResult(0));

            await ViewModel.ProductSelected(ProductId);
        }

        [Test]
        public void product_details_loads_product()
        {
            ProductDetails.VerifyAllExpectations();
        }

        [Test]
        public void current_view_model_is_set()
        {
            ViewModel.CurrentViewModel.ShouldBe(ProductDetails);
        }
    }
}