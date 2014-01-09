using CoreMvvm;

namespace Eshop.WpfMvvmApp.Products
{
    public class ProductsViewModel : NotifyingObject
    {
        private readonly ProductSearchViewModel _productSearch;
        private readonly ProductSearchResultViewModel _productSearchResult;
        private readonly ProductDetailsViewModel _productDetails;

        public ProductsViewModel(
            ProductSearchViewModel productSearch,
            ProductSearchResultViewModel productSearchResult,
            ProductDetailsViewModel productDetails
            )
        {
            _productSearch = productSearch;
            _productSearchResult = productSearchResult;
            _productDetails = productDetails;

            _productSearch.OnProductSearched += async products =>
                {
                    await _productSearchResult.PopulateSearchResult(products);
                    CurrentViewModel = _productSearchResult;
                };

            _productSearchResult.OnProductSelected += async productId =>
                {
                    await productDetails.LoadProduct(productId);
                    CurrentViewModel = _productDetails;
                };
        }

        public ProductSearchViewModel ProductSearch { get { return _productSearch; } }
        public NotifyingObject CurrentViewModel { get; private set; }
    }
}