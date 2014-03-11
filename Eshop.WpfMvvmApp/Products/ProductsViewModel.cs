using CoreMvvm;

namespace Eshop.WpfMvvmApp.Products
{
    public class ProductsViewModel : NotifyingObject
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly ProductSearchViewModel _productSearch;
        private readonly ProductSearchResultViewModel _productSearchResult;
        private readonly ProductDetailsViewModel _productDetails;
        private readonly BasketViewModel _basket;

        public ProductsViewModel(
            IEventAggregator eventAggregator,
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
            _eventAggregator = eventAggregator;

            _eventAggregator.Subscribe<ProductSearchedEvent>(async @event =>
                {
                    await _productSearchResult.PopulateSearchResult(@event.Products);
                    CurrentViewModel = _productSearchResult;
                });

            _eventAggregator.Subscribe<ProductSelectedEvent>(async @event =>
                {
                    await _productDetails.LoadProduct(@event.ProductId);
                    CurrentViewModel = _productDetails;
                });

            _eventAggregator.Subscribe<ProductAddedToBasketEvent>(async @event =>
                {
                    await _basket.LoadBasketItems();
                    CurrentViewModel = _basket;
                });
        }

        public ProductSearchViewModel ProductSearch { get { return _productSearch; } }
        public NotifyingObject CurrentViewModel { get; private set; }
    }
}