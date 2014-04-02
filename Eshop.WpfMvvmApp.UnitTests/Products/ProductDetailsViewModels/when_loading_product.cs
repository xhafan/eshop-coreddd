using NUnit.Framework;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Products.ProductDetailsViewModels
{
    [TestFixture]
    public class when_loading_product : ProductDetailsViewModelWithLoadedProductSetup
    {
        [Test]
        public void name_is_set()
        {
            ViewModel.Name.ShouldBe(ProductName);
        }

        [Test]
        public void description_is_set()
        {
            ViewModel.Description.ShouldBe(ProductDescription);
        }

        [Test]
        public void price_is_set()
        {
            ViewModel.Price.ShouldBe(ProductPrice);
        }
    }
}