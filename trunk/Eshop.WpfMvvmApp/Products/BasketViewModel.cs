using System.Threading.Tasks;
using System.Windows.Input;
using CoreMvvm;
using Eshop.WpfMvvmApp.ControllerClients;

namespace Eshop.WpfMvvmApp.Products
{
    public class BasketViewModel : NotifyingObject
    {
        private readonly IProductControllerClient _productControllerClient;
        private readonly RelayCommandAsync<int> _addToBasketCommand;
        private int _productId;

        public BasketViewModel(IProductControllerClient productControllerClient)
        {
            _productControllerClient = productControllerClient;

            _addToBasketCommand = new RelayCommandAsync<int>(async x => await AddProductToBasket(x), CanAddProductToBasketExecute);
        }

        public ICommand AddToBasketCommand { get { return _addToBasketCommand; } }


        public bool IsBusy { get; private set; } // todo: refactor this into some base view model
        public bool IsNotBusy { get { return !IsBusy; } }

        public string Name { get; private set; }
        public string Description { get; private set; }
        
        public int Quantity { get; set; }

        public async Task LoadProduct(int productId)
        {
            _productId = productId;

            IsBusy = true;

            var productDetails = await _productControllerClient.GetAsync(productId);
            Name = productDetails.Name;
            Description = productDetails.Description;

            IsBusy = false;
        }

        public delegate Task OnProductAddedToBasketHandler();
        public event OnProductAddedToBasketHandler OnProductAddedToBasket;

        public bool CanAddProductToBasketExecute(int quantity)
        {
            return true;
        }

        public async Task AddProductToBasket(int quantity)
        {
            IsBusy = true;

            await _productControllerClient.AddProductToBasketAsync(_productId, quantity);
            if (OnProductAddedToBasket!= null) await OnProductAddedToBasket();

            IsBusy = false;
        }

    }
}