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
        public decimal Subtotal { get; private set; }
        public ICommand UpdateProductQuantityCommand { get { return _updateProductQuantityCommand; } }

        public virtual async Task LoadBasketItems()
        {
            var basketItemDtos = await _basketControllerClient.GetBasketItemsAsync();
            _basketItems.Clear();
            basketItemDtos.Each(x =>
            {
                var basketItem = new BasketItemViewModel(x);
                basketItem.PropertyChanged += (sender, args) =>
                {
                    if (args.PropertyName == "Quantity")
                    {
                        _updateSubtotal();
                    }
                };
                _basketItems.Add(basketItem);
            });
            _updateSubtotal();
        }

        private void _updateSubtotal()
        {
            Subtotal = _basketItems.Sum(x => x.Quantity * x.ProductPrice);
        } 

        private bool _canUpdateProductQuantityExecute(int productId)
        {
            return true;
        }

        private async Task _updateProductQuantity(int productId)
        {
            var basketItem = _basketItems.First(x => x.ProductId == productId);
            await _basketControllerClient.UpdateProductQuantityAsync(productId, basketItem.UpdatedQuantity);
            basketItem.UpdateQuantity();
            if (basketItem.Quantity == 0)
            {
                _basketItems.Remove(basketItem);
            }
        }
    }
}