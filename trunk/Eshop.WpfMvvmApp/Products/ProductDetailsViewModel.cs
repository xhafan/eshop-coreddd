using System.Threading.Tasks;
using System.Windows.Input;
using CoreMvvm;
using Eshop.WpfMvvmApp.ControllerClients;

namespace Eshop.WpfMvvmApp.Products
{
    public class ProductDetailsViewModel : NotifyingObject
    {
        private readonly IProductControllerClient _productControllerClient;
        private readonly IBasketControllerClient _basketControllerClient;
        private readonly IProductAddedToBasket _productAddedToBasket;
        private readonly RelayCommandAsync<int> _addToBasketCommand;
        private int _productId;

        public ProductDetailsViewModel(
            IProductControllerClient productControllerClient, 
            IBasketControllerClient basketControllerClient,
            IProductAddedToBasket productAddedToBasket
            )
        {
            _productControllerClient = productControllerClient;
            _basketControllerClient = basketControllerClient;
            _productAddedToBasket = productAddedToBasket;

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

            var productDetails = await _productControllerClient.GetProductAsync(productId);
            Name = productDetails.Name;
            Description = productDetails.Description;

            IsBusy = false;
        }

        public bool CanAddProductToBasketExecute(int quantity)
        {
            return true;
        }

        public async Task AddProductToBasket(int quantity)
        {
            IsBusy = true;

            await _basketControllerClient.AddProductToBasketAsync(_productId, quantity);
            await _productAddedToBasket.ProductAddedToBasket();

            IsBusy = false;
        }

    }
}
