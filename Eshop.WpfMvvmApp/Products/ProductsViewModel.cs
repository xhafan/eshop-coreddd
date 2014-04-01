using System.Collections.Generic;
using System.Threading.Tasks;
using CoreMvvm;
using Eshop.Dtos;

namespace Eshop.WpfMvvmApp.Products
{
    public class ProductsViewModel : BaseViewModel, IProductSearched, IProductSelected, IProductAddedToBasket
    {
        private readonly ProductSearchViewModel _productSearch;
        private readonly ProductSearchResultViewModel _productSearchResult;
        private readonly ProductDetailsViewModel _productDetails;
        private readonly BasketViewModel _basket;

        protected ProductsViewModel() {}

        public ProductsViewModel(
            IProductSearchViewModelFactory productSearchFactory,
            IProductSearchResultViewModelFactory productSearchResultFactory,
            IProductDetailsViewModelFactory productDetailsFactory,
            BasketViewModel basket
            )
        {
            _productSearch = productSearchFactory.Create(this);
            _productSearchResult = productSearchResultFactory.Create(this);
            _productDetails = productDetailsFactory.Create(this);
            _basket = basket;
        }

        public ProductSearchViewModel ProductSearch { get { return _productSearch; } }
        public BaseViewModel CurrentViewModel { get; private set; }
        
        public void ProductSearched(IEnumerable<ProductSummaryDto> products)
        {
            _productSearchResult.PopulateSearchResult(products);
            CurrentViewModel = _productSearchResult;
        }

        public async Task ProductSelected(int productId)
        {
            await _productDetails.LoadProduct(productId);
            CurrentViewModel = _productDetails;
        }

        public async Task ProductAddedToBasket()
        {
            await _basket.LoadBasketItems();
            CurrentViewModel = _basket;
        }
    }
}