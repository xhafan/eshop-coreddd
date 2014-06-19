using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CoreMvvm;
using CoreUtils.Extensions;
using Eshop.WpfMvvmApp.ControllerClients;

namespace Eshop.WpfMvvmApp.Products
{
    public class ReviewOrderViewModel2 : BaseViewModel
    {
        private readonly IOrderControllerClient _orderControllerClient;
        private readonly ObservableCollection<BasketItemViewModel> _basketItems = new ObservableCollection<BasketItemViewModel>();

        public ReviewOrderViewModel2(IOrderControllerClient orderControllerClient)
        {
            _orderControllerClient = orderControllerClient;
        }

        public ObservableCollection<BasketItemViewModel> BasketItems { get { return _basketItems; } }
        public decimal Subtotal { get; private set; }
        public string DeliveryAddress { get; private set; }

        public async Task LoadReviewOrderData()
        {
            var reviewOrderDto = await _orderControllerClient.GetReviewOrderDtoAsync();
            _basketItems.Clear();
            reviewOrderDto.BasketItems.Each(x => _basketItems.Add(new BasketItemViewModel(x)));
            _updateSubtotal();
            DeliveryAddress = reviewOrderDto.DeliveryAddress.DeliveryAddress;
        }

        private void _updateSubtotal()
        {
            Subtotal = _basketItems.Sum(x => x.Quantity * x.ProductPrice);
        }

    }
}