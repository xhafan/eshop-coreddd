using System.Collections.Generic;
using System.Threading.Tasks;
using CoreMvvm;
using Eshop.Dtos;
using Eshop.WpfMvvmApp.ControllerClients;

namespace Eshop.WpfMvvmApp.Products
{
    public class ProductsViewModel2 : BaseViewModel
    {
        private readonly IDeliveryAddressControllerClient _deliveryAddressControllerClient;
        private readonly ProductSearchViewModel2 _productSearch;
        private readonly ProductSearchResultViewModel2 _productSearchResult;
        private readonly ProductDetailsViewModel2 _productDetails;
        private readonly BasketViewModel2 _basket;
        private readonly DeliveryAddressViewModel2 _deliveryAddress;
        private readonly ReviewOrderViewModel2 _reviewOrder;

        public ProductsViewModel2(
            IProductControllerClient productControllerClient, 
            IBasketControllerClient basketControllerClient, 
            IDeliveryAddressControllerClient deliveryAddressControllerClient, 
            IOrderControllerClient orderControllerClient
            )
        {
            _deliveryAddressControllerClient = deliveryAddressControllerClient;
            _productSearch = new ProductSearchViewModel2(productControllerClient, this);
            _productSearchResult = new ProductSearchResultViewModel2(this);
            _productDetails = new ProductDetailsViewModel2(this, productControllerClient, basketControllerClient);
            _basket = new BasketViewModel2(basketControllerClient, this);
            _deliveryAddress = new DeliveryAddressViewModel2();
            _reviewOrder = new ReviewOrderViewModel2(orderControllerClient);
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

        public async Task ProceededToCheckout()
        {
            var deliveryAddress = await _deliveryAddressControllerClient.GetDeliveryAddressAsync();
            if (string.IsNullOrWhiteSpace(deliveryAddress))
            {
                CurrentViewModel = _deliveryAddress;
                return;
            }
            await _reviewOrder.LoadReviewOrderData();
            CurrentViewModel = _reviewOrder;
        }
    }
}