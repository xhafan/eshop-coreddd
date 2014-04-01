using System.Threading.Tasks;
using System.Windows.Input;
using CoreMvvm;
using Eshop.WpfMvvmApp.ControllerClients;

namespace Eshop.WpfMvvmApp.Products
{
    public class ProductSearchViewModel : BaseViewModel
    {
        private readonly IProductControllerClient _productControllerClient;
        private readonly IProductSearched _productSearched;

        private readonly RelayCommandAsync<string> _searchProductsCommand;

        public ProductSearchViewModel(IProductControllerClient productControllerClient, IProductSearched productSearched)
        {
            _productControllerClient = productControllerClient;
            _productSearched = productSearched;

            _searchProductsCommand = new RelayCommandAsync<string>(async x => await _searchProducts(x), _canSearchProductsExecute);
        }

        public string SearchText { get; set; }

        public ICommand SearchProductsCommand { get { return _searchProductsCommand; } }

        private bool _canSearchProductsExecute(string searchText)
        {
            return true;
        }

        private async Task _searchProducts(string searchText)
        {
            var products = await _productControllerClient.SearchProductsAsync(searchText);
            _productSearched.ProductSearched(products);
        }
    }
}
