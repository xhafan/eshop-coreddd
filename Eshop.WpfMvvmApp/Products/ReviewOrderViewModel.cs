using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using CoreMvvm;
using CoreUtils.Extensions;
using Eshop.WpfMvvmApp.ControllerClients;

namespace Eshop.WpfMvvmApp.Products
{
    public class ReviewOrderViewModel : BaseViewModel
    {
        private readonly IBasketControllerClient _basketControllerClient;
        private readonly IOrderControllerClient _orderControllerClient;
        private readonly IOnPlacingOrder _onPlacingOrder;
        private readonly ObservableCollection<BasketItemViewModel> _basketItems = new ObservableCollection<BasketItemViewModel>();
        private readonly RelayCommandAsync<object> _placeOrderCommand;
        
        protected ReviewOrderViewModel() {}

        public ReviewOrderViewModel(IBasketControllerClient basketControllerClient, IOrderControllerClient orderControllerClient, IOnPlacingOrder onPlacingOrder)
        {
            _basketControllerClient = basketControllerClient;
            _orderControllerClient = orderControllerClient;
            _onPlacingOrder = onPlacingOrder;
            _placeOrderCommand = new RelayCommandAsync<object>(async x => await _placeOrder());
        }

        public ObservableCollection<BasketItemViewModel> BasketItems { get { return _basketItems; } }
        public decimal Subtotal { get; private set; }
        public ICommand PlaceOrderCommand { get { return _placeOrderCommand; } }

        public virtual async Task LoadBasketItems()
        {
            var basketItemDtos = await _basketControllerClient.GetBasketItemsAsync();
            _basketItems.Clear();
            basketItemDtos.Each(x => _basketItems.Add(new BasketItemViewModel(x)));
            _updateSubtotal();
        }

        private void _updateSubtotal()
        {
            Subtotal = _basketItems.Sum(x => x.Quantity * x.ProductPrice);
        }

        private async Task _placeOrder()
        {
            await _orderControllerClient.PlaceOrderAsync(null);
            await _onPlacingOrder.OrderPlaced();
        }
    }
}