﻿using CoreTest;
using Eshop.WpfMvvmApp.Products;
using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.WpfMvvmApp.UnitTests.Products.ProductsViewModels
{
    public abstract class ProductsViewModelSetup : BaseTest
    {
        protected IProductSearchViewModelFactory ProductSearchViewModelFactory;
        protected IProductSearchResultViewModelFactory ProductSearchResultViewModelFactory;
        protected IProductDetailsViewModelFactory ProductDetailsViewModelFactory;
        protected ProductsViewModel ViewModel;
        protected ProductSearchViewModel ProductSearch;
        protected ProductSearchResultViewModel ProductSearchResult;
        protected ProductDetailsViewModel ProductDetails;
        protected BasketViewModel Basket;

        [SetUp]
        public virtual void Context()
        {
            ProductSearch = Stub<ProductSearchViewModel>();
            ProductSearchResult = Stub<ProductSearchResultViewModel>();
            ProductDetails = Stub<ProductDetailsViewModel>();

            ProductSearchViewModelFactory = Stub<IProductSearchViewModelFactory>()
                .Stubs(x => x.Create(Arg<IProductSearched>.Matches(p => p is ProductsViewModel))).Returns(ProductSearch);
            ProductSearchResultViewModelFactory = Stub<IProductSearchResultViewModelFactory>()
                .Stubs(x => x.Create(Arg<IProductSelected>.Matches(p => p is ProductsViewModel))).Returns(ProductSearchResult);
            ProductDetailsViewModelFactory = Stub<IProductDetailsViewModelFactory>()
                .Stubs(x => x.Create(Arg<IProductAddedToBasket>.Matches(p => p is ProductsViewModel))).Returns(ProductDetails);
            Basket = Stub<BasketViewModel>();
            
            ViewModel = new ProductsViewModel(
                ProductSearchViewModelFactory, 
                ProductSearchResultViewModelFactory, 
                ProductDetailsViewModelFactory, 
                Basket);
        }
    }
}