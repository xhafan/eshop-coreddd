using System.Collections.Generic;
using System.Threading.Tasks;
using CoreMvvm;
using Eshop.Dtos;
using Eshop.WpfMvvmApp.ControllerClients;

namespace Eshop.WpfMvvmApp.Products
{
    public class ProductsViewModel2 : BaseViewModel
    {
        private readonly ProductSearchViewModel2 _productSearch;
        private readonly ProductSearchResultViewModel2 _productSearchResult;
        private readonly ProductDetailsViewModel2 _productDetails;
        private readonly BasketViewModel2 _basket;

        public ProductsViewModel2(
            IProductControllerClient productControllerClient,
            IBasketControllerClient basketControllerClient
            )
        {
            _productSearch = new ProductSearchViewModel2(productControllerClient, this);
            _productSearchResult = new ProductSearchResultViewModel2(this);
            _productDetails = new ProductDetailsViewModel2(this, productControllerClient, basketControllerClient);
            _basket = new BasketViewModel2(basketControllerClient);
        }

        public BaseViewModel CurrentViewModel { get; private set; }
        public ProductSearchViewModel2 ProductSearch { get { return _productSearch; } }
        
        public void ProductSearched(IEnumerable<ProductSummaryDto> searchedProducts)
        {
            _productSearchResult.PopulateSearchResult(searchedProducts);
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