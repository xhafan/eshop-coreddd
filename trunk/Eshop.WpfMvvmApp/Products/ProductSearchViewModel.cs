using System.Threading.Tasks;
using System.Windows.Input;
using CoreMvvm;
using Eshop.WpfMvvmApp.ControllerClients;

namespace Eshop.WpfMvvmApp.Products
{
    public class ProductSearchViewModel : BaseViewModel  // todo: test me
    {
        private readonly IProductControllerClient _productControllerClient;
        private readonly IProductSearched _productSearched;

        private readonly RelayCommandAsync<string> _searchProductsCommand;

        public ProductSearchViewModel(IProductControllerClient productControllerClient, IProductSearched productSearched)
        {
            _productControllerClient = productControllerClient;
            _productSearched = productSearched;

            _searchProductsCommand = new RelayCommandAsync<string>(async x => await SearchProducts(x), CanSearchProductsExecute);
        }

        public string SearchText { get; set; }

        public ICommand SearchProductsCommand { get { return _searchProductsCommand; } }

        public bool CanSearchProductsExecute(string searchText)
        {
            return true;
        }

        public async Task SearchProducts(string searchText)
        {
            var products = await _productControllerClient.SearchProductsAsync(searchText);
            _productSearched.ProductSearched(products);
        }
    }
}
