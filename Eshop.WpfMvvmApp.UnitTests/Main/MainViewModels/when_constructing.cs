﻿using CoreTest;
using Eshop.WpfMvvmApp.Main;
using Eshop.WpfMvvmApp.Products;
using NUnit.Framework;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Main.MainViewModels
{
    [TestFixture]
    public class when_constructing : BaseTest
    {
        private MainViewModel _viewModel;
        private ProductsViewModel _productsViewModel;

        [SetUp]
        public void Context()
        {
            _productsViewModel = Stub<ProductsViewModel>();

            _viewModel = new MainViewModel(_productsViewModel);
        }

        [Test]
        public void current_view_model_is_set()
        {
            _viewModel.CurrentViewModel.ShouldBe(_productsViewModel);
        }
    }
}