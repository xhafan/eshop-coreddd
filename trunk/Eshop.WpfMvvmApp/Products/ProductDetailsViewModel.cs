using System.Threading.Tasks;
using System.Windows.Input;
using CoreMvvm;
using Eshop.WpfMvvmApp.ControllerClients;

namespace Eshop.WpfMvvmApp.Products
{
    public class ProductDetailsViewModel : BaseViewModel
    {
        private readonly IProductControllerClient _productControllerClient;
        private readonly IBasketControllerClient _basketControllerClient;
        private readonly IProductAddedToBasket _productAddedToBasket;
        private readonly RelayCommandAsync<int> _addToBasketCommand;
        private int _productId;

        protected ProductDetailsViewModel() {}

        public ProductDetailsViewModel(
            IProductControllerClient productControllerClient, 
            IBasketControllerClient basketControllerClient,
            IProductAddedToBasket productAddedToBasket
            )
        {
            _productControllerClient = productControllerClient;
            _basketControllerClient = basketControllerClient;
            _productAddedToBasket = productAddedToBasket;

            _addToBasketCommand = new RelayCommandAsync<int>(async x => await _addProductToBasket(x), _canAddProductToBasketExecute);
        }

        public ICommand AddToBasketCommand { get { return _addToBasketCommand; } }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        
        public int Quantity { get; set; }

        public virtual async Task LoadProduct(int productId)
        {
            _productId = productId;

            var productDetails = await _productControllerClient.GetProductAsync(productId);
            Name = productDetails.Name;
            Description = productDetails.Description;
            Price = productDetails.Price;
        }

        private bool _canAddProductToBasketExecute(int quantity)
        {
            return true;
        }

        private async Task _addProductToBasket(int quantity)
        {
            await _basketControllerClient.AddProductToBasketAsync(_productId, quantity);
            await _productAddedToBasket.ProductAddedToBasket();
        }
    }
}
