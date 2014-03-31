using NUnit.Framework;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Products.ProductDetailsViewModels
{
    [TestFixture]
    public class when_loading_product : ProductDetailsViewModelWithLoadedProductSetup
    {
        [Test]
        public void NameIsSet()
        {
            ViewModel.Name.ShouldBe(ProductName);
        }

        [Test]
        public void DescriptionIsSet()
        {
            ViewModel.Description.ShouldBe(ProductDescription);
        }
    }
}