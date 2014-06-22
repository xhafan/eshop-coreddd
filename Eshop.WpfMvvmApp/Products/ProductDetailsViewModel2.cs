using System.Threading.Tasks;
using System.Windows.Input;
using CoreMvvm;
using Eshop.WpfMvvmApp.ControllerClients;

namespace Eshop.WpfMvvmApp.Products
{
    public class ProductDetailsViewModel2 : BaseViewModel
    {
        private readonly IProductControllerClient _productControllerClient;
        private readonly IBasketControllerClient _basketControllerClient;
        private readonly ProductsViewModel2 _productsViewModel;
        private readonly RelayCommandAsync<int> _addToBasketCommand;
        private int _productId;

        public ProductDetailsViewModel2(
            IProductControllerClient productControllerClient, 
            IBasketControllerClient basketControllerClient,
            ProductsViewModel2 productsViewModel
            )
        {
            _productControllerClient = productControllerClient;
            _basketControllerClient = basketControllerClient;
            _productsViewModel = productsViewModel;
            _addToBasketCommand = new RelayCommandAsync<int>(async x => await _addProductToBasket(x));
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; set; }                
        public ICommand AddToBasketCommand { get { return _addToBasketCommand; } }

        public async Task LoadProduct(int productId)
        {
            _productId = productId;
            var productDetails = await _productControllerClient.GetProductAsync(productId);
            Name = productDetails.Name;
            Description = productDetails.Description;
            Price = productDetails.Price;
        }

        private async Task _addProductToBasket(int quantity)
        {
            await _basketControllerClient.AddProductToBasketAsync(_productId, quantity);
            await _productsViewModel.ProductAddedToBasket();
        }
    }
}