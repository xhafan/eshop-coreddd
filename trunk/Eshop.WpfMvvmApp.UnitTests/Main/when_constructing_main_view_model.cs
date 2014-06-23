using CoreTest;
using Eshop.WpfMvvmApp.Main;
using Eshop.WpfMvvmApp.Products;
using Eshop.WpfMvvmApp.UnitTests.Products;
using NUnit.Framework;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Main
{
    [TestFixture]
    public class when_constructing_main_view_model : BaseTest
    {
        private MainViewModel _viewModel;
        private ProductsViewModel _productsViewModel;

        [SetUp]
        public void Context()
        {
            _productsViewModel = new ProductsViewModelBuilder().Build();

            _viewModel = new MainViewModel(_productsViewModel);
        }

        [Test]
        public void current_view_model_is_set()
        {
            _viewModel.CurrentViewModel.ShouldBe(_productsViewModel);
        }
    }
}