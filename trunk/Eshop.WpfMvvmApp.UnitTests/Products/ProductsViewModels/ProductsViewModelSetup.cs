using CoreTest;
using Eshop.WpfMvvmApp.ControllerClients;
using Eshop.WpfMvvmApp.Products;
using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.WpfMvvmApp.UnitTests.Products.ProductsViewModels
{
    public abstract class ProductsViewModelSetup : BaseTest
    {
        protected IDeliveryAddressControllerClient DeliveryAddressControllerClient;

        protected IProductSearchViewModelFactory ProductSearchViewModelFactory;
        protected IProductSearchResultViewModelFactory ProductSearchResultViewModelFactory;
        protected IProductDetailsViewModelFactory ProductDetailsViewModelFactory;
        protected IBasketViewModelFactory BasketViewModelFactory;
        protected IReviewOrderViewModelFactory ReviewOrderViewModelFactory;
        protected IDeliveryAddressViewModelFactory DeliveryAddressViewModelFactory;

        protected ProductsViewModel ViewModel;
        protected ProductSearchViewModel ProductSearch;
        protected ProductSearchResultViewModel ProductSearchResult;
        protected ProductDetailsViewModel ProductDetails;
        protected BasketViewModel Basket;
        protected ReviewOrderViewModel ReviewOrder;
        protected DeliveryAddressViewModel DeliveryAddress;

        [SetUp]
        public virtual void Context()
        {
            DeliveryAddressControllerClient = Stub<IDeliveryAddressControllerClient>();

            ProductSearch = Stub<ProductSearchViewModel>();
            ProductSearchResult = Stub<ProductSearchResultViewModel>();
            ProductDetails = Stub<ProductDetailsViewModel>();
            Basket = Stub<BasketViewModel>();
            ReviewOrder = Stub<ReviewOrderViewModel>();
            DeliveryAddress = Stub<DeliveryAddressViewModel>();

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
            DeliveryAddressViewModelFactory = Stub<IDeliveryAddressViewModelFactory>()
                .Stubs(x => x.Create(Arg<IOnDeliveryAddressSet>.Matches(p => p is ProductsViewModel))).Returns(DeliveryAddress);

            ViewModel = new ProductsViewModel(
                DeliveryAddressControllerClient,
                ProductSearchViewModelFactory, 
                ProductSearchResultViewModelFactory, 
                ProductDetailsViewModelFactory,
                BasketViewModelFactory,
                ReviewOrderViewModelFactory,
                DeliveryAddressViewModelFactory
                );
        }
    }
}