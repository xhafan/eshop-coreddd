using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using CoreMvvm;
using CoreUtils.Extensions;
using Eshop.WpfMvvmApp.ControllerClients;

namespace Eshop.WpfMvvmApp.Products
{
    public class BasketViewModel : BaseViewModel
    {
        private readonly IBasketControllerClient _basketControllerClient;
        private readonly ObservableCollection<BasketItemViewModel> _basketItems = new ObservableCollection<BasketItemViewModel>();
        private readonly RelayCommandAsync<int> _updateProductQuantityCommand;
        protected BasketViewModel() {}

        public BasketViewModel(IBasketControllerClient basketControllerClient)
        {
            _basketControllerClient = basketControllerClient;
            _updateProductQuantityCommand = new RelayCommandAsync<int>(async x => await _updateProductQuantity(x), _canUpdateProductQuantityExecute);
        }
       
        public ObservableCollection<BasketItemViewModel> BasketItems { get { return _basketItems; } }
        public decimal Subtotal { get { return 23.45m; } }
        public ICommand UpdateProductQuantityCommand { get { return _updateProductQuantityCommand; } }
        public virtual async Task LoadBasketItems()
        {
            var basketItemDtos = await _basketControllerClient.GetBasketItemsAsync();
            _basketItems.Clear();
            basketItemDtos.Each(x => _basketItems.Add(new BasketItemViewModel(x)));
        }

        private bool _canUpdateProductQuantityExecute(int productId)
        {
            return true;
        }

        private async Task _updateProductQuantity(int productId)
        {
            var basketItem = _basketItems.First(x => x.ProductId == productId);
            await _basketControllerClient.UpdateProductQuantityAsync(productId, basketItem.UpdatedQuantity);
            if (basketItem.UpdatedQuantity == 0)
            {
                _basketItems.Remove(basketItem);
            }
            else
            {
                basketItem.UpdateQuantity();
            }
        }
    }
}