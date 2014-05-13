using System.Collections.Generic;
using System.Threading.Tasks;
using CoreMvvm;
using Eshop.Dtos;
using Eshop.WpfMvvmApp.ControllerClients;

namespace Eshop.WpfMvvmApp.Products
{
    public class ProductsViewModel : 
        BaseViewModel, 
        IProductSearched, 
        IProductSelected, 
        IProductAddedToBasket,
        IOnProceedingToCheckout,
        IOnPlacingOrder,
        IOnDeliveryAddressSet
    {
        private readonly IDeliveryAddressControllerClient _deliveryAddressControllerClient;
        private readonly ProductSearchViewModel _productSearch;
        private readonly ProductSearchResultViewModel _productSearchResult;
        private readonly ProductDetailsViewModel _productDetails;
        private readonly BasketViewModel _basket;
        private readonly ReviewOrderViewModel _reviewOrder;
        private readonly DeliveryAddressViewModel _deliveryAddress;
        private readonly OrderPlacedViewModel _orderPlaced;

        protected ProductsViewModel() {}

        public ProductsViewModel(
            IDeliveryAddressControllerClient deliveryAddressControllerClient,
            IProductSearchViewModelFactory productSearchFactory,
            IProductSearchResultViewModelFactory productSearchResultFactory,
            IProductDetailsViewModelFactory productDetailsFactory,
            IBasketViewModelFactory basketViewModelFactory,
            IReviewOrderViewModelFactory reviewOrderViewModelFactory,
            IDeliveryAddressViewModelFactory deliveryAddressViewModelFactory
            )
        {
            _deliveryAddressControllerClient = deliveryAddressControllerClient;
            _productSearch = productSearchFactory.Create(this);
            _productSearchResult = productSearchResultFactory.Create(this);
            _productDetails = productDetailsFactory.Create(this);
            _basket = basketViewModelFactory.Create(this);
            _reviewOrder = reviewOrderViewModelFactory.Create(this);
            _deliveryAddress = deliveryAddressViewModelFactory.Create(this);
            _orderPlaced = new OrderPlacedViewModel();
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

        public async Task ProceededToCheckout()
        {
            var deliveryAddress = await _deliveryAddressControllerClient.GetDeliveryAddressAsync();
            if (string.IsNullOrWhiteSpace(deliveryAddress))
            {
                CurrentViewModel = _deliveryAddress;
                return;
            }
            await DeliveryAddressSet(deliveryAddress);
        }

        public async Task OrderPlaced()
        {
            CurrentViewModel = _orderPlaced;
        }

        public async Task DeliveryAddressSet(string deliveryAddress)
        {
            await _reviewOrder.LoadBasketItems();
            CurrentViewModel = _reviewOrder;
        }
    }
}