using System.Threading.Tasks;
using System.Windows.Input;
using CoreMvvm;
using Eshop.WpfMvvmApp.ControllerClients;

namespace Eshop.WpfMvvmApp.Products
{
    public class DeliveryAddressViewModel : BaseViewModel
    {
        private readonly IDeliveryAddressControllerClient _deliveryAddressControllerClient;
        private readonly RelayCommandAsync<string> _setDeliveryAddressCommand;
        private readonly ProductsViewModel _products;

        public DeliveryAddressViewModel(IDeliveryAddressControllerClient deliveryAddressControllerClient, ProductsViewModel products)
        {
            _products = products;
            _deliveryAddressControllerClient = deliveryAddressControllerClient;
            _setDeliveryAddressCommand = new RelayCommandAsync<string>(async x => await _setDeliveryAddress(x), _canSetDeliveryAddressExecute);
        }

        public string DeliveryAddress { get; set; }
        public ICommand SetDeliveryAddressCommand { get { return _setDeliveryAddressCommand; } }

        private static bool _canSetDeliveryAddressExecute(string deliveryAddress)
        {
            return !string.IsNullOrWhiteSpace(deliveryAddress);
        }
        
        private async Task _setDeliveryAddress(string deliveryAddress)
        {
            await _deliveryAddressControllerClient.SetDeliveryAddressAsync(deliveryAddress);
            await _products.LoadReviewOrder();
        }
    }
}