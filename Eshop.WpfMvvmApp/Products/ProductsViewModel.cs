using CoreMvvm;

namespace Eshop.WpfMvvmApp.Products
{
    public class ProductsViewModel : NotifyingObject
    {
        private readonly ProductSearchViewModel _productSearch;
        private readonly ProductSearchResultViewModel _productSearchResult;
        private readonly ProductDetailsViewModel _productDetails;
        private readonly BasketViewModel _basket;

        public ProductsViewModel(
            ProductSearchViewModel productSearch,
            ProductSearchResultViewModel productSearchResult,
            ProductDetailsViewModel productDetails,
            BasketViewModel basket
            )
        {
            _productSearch = productSearch;
            _productSearchResult = productSearchResult;
            _productDetails = productDetails;
            _basket = basket;

            _productSearch.OnProductSearched += async products =>
                {
                    await _productSearchResult.PopulateSearchResult(products);
                    CurrentViewModel = _productSearchResult;
                };

            _productSearchResult.OnProductSelected += async productId =>
                {
                    await _productDetails.LoadProduct(productId);
                    CurrentViewModel = _productDetails;
                };

            _productDetails.OnProductAddedToBasket += async () =>
                {
                    await _basket.LoadBasketItems();
                    CurrentViewModel = _basket;
                };
        }

        public ProductSearchViewModel ProductSearch { get { return _productSearch; } }
        public NotifyingObject CurrentViewModel { get; private set; }
    }
}