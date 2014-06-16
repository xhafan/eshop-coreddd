using System.Threading.Tasks;
using System.Windows.Input;
using CoreMvvm;
using Eshop.WpfMvvmApp.ControllerClients;

namespace Eshop.WpfMvvmApp.Products
{
    public class ProductSearchViewModel2 : BaseViewModel
    {
        private readonly IProductControllerClient _productControllerClient;
        private readonly ProductsViewModel2 _products;
        private readonly RelayCommandAsync<string> _searchProductsCommand;

        public ProductSearchViewModel2(IProductControllerClient productControllerClient, ProductsViewModel2 products)
        {
            _productControllerClient = productControllerClient;
            _products = products;
            _searchProductsCommand = new RelayCommandAsync<string>(async x => await _searchProducts(x));
        }

        public string SearchText { get; set; }
        public ICommand SearchProductsCommand { get { return _searchProductsCommand; } }

        private async Task _searchProducts(string searchText)
        {
            var productSummaryDtos = await _productControllerClient.SearchProductsAsync(searchText);
            _products.ProductSearched(productSummaryDtos);
        }
    }
}