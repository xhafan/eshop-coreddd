using System.Collections.Generic;
using System.Threading.Tasks;
using CoreMvvm;
using Eshop.Dtos;
using Eshop.WpfMvvmApp.ControllerClients;

namespace Eshop.WpfMvvmApp.Products
{
    public class ProductsViewModel : BaseViewModel
    {
        private readonly IDeliveryAddressControllerClient _deliveryAddressControllerClient;
        private readonly ProductSearchViewModel _productSearch;
        private readonly ProductSearchResultViewModel _productSearchResult;
        private readonly ProductDetailsViewModel _productDetails;
        private readonly BasketViewModel _basket;
        private readonly DeliveryAddressViewModel _deliveryAddress;
        private readonly ReviewOrderViewModel _reviewOrder;
        private readonly OrderPlacedViewModel _orderPlaced;

        public ProductsViewModel(
            IProductControllerClient productControllerClient, 
            IBasketControllerClient basketControllerClient, 
            IDeliveryAddressControllerClient deliveryAddressControllerClient, 
            IOrderControllerClient orderControllerClient
            )
        {
            _deliveryAddressControllerClient = deliveryAddressControllerClient;
            _productSearch = new ProductSearchViewModel(productControllerClient, this);
            _productSearchResult = new ProductSearchResultViewModel(this);
            _productDetails = new ProductDetailsViewModel(productControllerClient, basketControllerClient, this);
            _basket = new BasketViewModel(basketControllerClient, this);
            _deliveryAddress = new DeliveryAddressViewModel(_deliveryAddressControllerClient, this);
            _reviewOrder = new ReviewOrderViewModel(orderControllerClient, this);
            _orderPlaced = new OrderPlacedViewModel();
        }

        public BaseViewModel CurrentViewModel { get; private set; }
        public ProductSearchViewModel ProductSearch { get { return _productSearch; } }
        
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
            await LoadReviewOrder();
        }

        public async Task LoadReviewOrder()
        {
            await _reviewOrder.LoadReviewOrderData();
            CurrentViewModel = _reviewOrder;
        }

        public void OrderPlaced()
        {
            CurrentViewModel = _orderPlaced;
        }
    }
}