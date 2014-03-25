using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CoreMvvm;
using CoreUtils.Extensions;
using Eshop.WpfMvvmApp.ControllerClients;

namespace Eshop.WpfMvvmApp.Products
{
    public class BasketViewModel : BaseViewModel
    {
        private readonly IBasketControllerClient _basketControllerClient;
        private readonly ObservableCollection<BasketItemViewModel> _basketItems = new ObservableCollection<BasketItemViewModel>();

        public BasketViewModel(IBasketControllerClient basketControllerClient)
        {
            _basketControllerClient = basketControllerClient;
        }
       
        public ObservableCollection<BasketItemViewModel> BasketItems { get { return _basketItems; } }

        public async Task LoadBasketItems()
        {
            var basketItemDtos = await _basketControllerClient.GetBasketItemsAsync();
            _basketItems.Clear();
            basketItemDtos.Each(x => _basketItems.Add(new BasketItemViewModel(x)));
        }
    }
}