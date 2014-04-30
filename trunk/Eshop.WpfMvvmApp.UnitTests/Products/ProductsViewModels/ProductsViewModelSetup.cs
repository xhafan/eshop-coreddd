using CoreTest;
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
        protected IBasketViewModelFactory BasketViewModelFactory;
        protected IReviewOrderViewModelFactory ReviewOrderViewModelFactory;

        protected ProductsViewModel ViewModel;
        protected ProductSearchViewModel ProductSearch;
        protected ProductSearchResultViewModel ProductSearchResult;
        protected ProductDetailsViewModel ProductDetails;
        protected BasketViewModel Basket;
        protected ReviewOrderViewModel ReviewOrder;

        [SetUp]
        public virtual void Context()
        {
            ProductSearch = Stub<ProductSearchViewModel>();
            ProductSearchResult = Stub<ProductSearchResultViewModel>();
            ProductDetails = Stub<ProductDetailsViewModel>();
            Basket = Stub<BasketViewModel>();
            ReviewOrder = Stub<ReviewOrderViewModel>();

            ProductSearchViewModelFactory = Stub<IProductSearchViewModelFactory>()
                .Stubs(x => x.Create(Arg<IProductSearched>.Matches(p => p is ProductsViewModel))).Returns(ProductSearch);
            ProductSearchResultViewModelFactory = Stub<IProductSearchResultViewModelFactory>()
                .Stubs(x => x.Create(Arg<IProductSelected>.Matches(p => p is ProductsViewModel))).Returns(ProductSearchResult);
            ProductDetailsViewModelFactory = Stub<IProductDetailsViewModelFactory>()
                .Stubs(x => x.Create(Arg<IProductAddedToBasket>.Matches(p => p is ProductsViewModel))).Returns(ProductDetails);
            BasketViewModelFactory = Stub<IBasketViewModelFactory>()
                .Stubs(x => x.Create(Arg<IOnProceedingToCheckout>.Matches(p => p is ProductsViewModel))).Returns(Basket);
            ReviewOrderViewModelFactory = Stub<IReviewOrderViewModelFactory>()
                .Stubs(x => x.Create(Arg<IOnPlacingOrder>.Matches(p => p is ProductsViewModel))).Returns(ReviewOrder);
            
            ViewModel = new ProductsViewModel(
                ProductSearchViewModelFactory, 
                ProductSearchResultViewModelFactory, 
                ProductDetailsViewModelFactory,
                BasketViewModelFactory,
                ReviewOrderViewModelFactory
                );
        }
    }
}