using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CoreMvvm;
using CoreUtils.Extensions;
using Eshop.WpfMvvmApp.ControllerClients;

namespace Eshop.WpfMvvmApp.Products
{
    public class ProductSearchViewModel : NotifyingObject
    {
        private readonly IProductControllerClient _productControllerClient;
        private readonly ObservableCollection<ProductViewModel> _products = new ObservableCollection<ProductViewModel>();

        private readonly RelayCommandAsync<string> _searchProductsCommand;
        private readonly RelayCommandAsync<int> _selectProductCommand;
        
        public ProductSearchViewModel(IProductControllerClient productControllerClient)
        {
            _productControllerClient = productControllerClient;
        
            _searchProductsCommand = new RelayCommandAsync<string>(async x => await SearchProducts(x), CanSearchProductsExecute);
            _selectProductCommand = new RelayCommandAsync<int>(async x => await SelectProduct(x), CanSelectProductExecute);
        }

        public ObservableCollection<ProductViewModel> Products { get { return _products; } }
        public string SearchText { get; set; }

        public ICommand SearchProductsCommand { get { return _searchProductsCommand; } }
        public ICommand SelectProductCommand { get { return _selectProductCommand; } }

        public bool IsBusy { get; private set; } // todo: refactor this into some base view model
        public bool IsNotBusy { get { return !IsBusy; } }

        public bool CanSearchProductsExecute(string searchText)
        {
            return true;
        }

        public async Task SearchProducts(string searchText)
        {
            IsBusy = true;

            var products = await _productControllerClient.GetAsync(searchText);
            Products.Clear();
            products.Each(x => Products.Add(new ProductViewModel(x.Id, x.Name)));

            IsBusy = false;
        }

        public bool CanSelectProductExecute(int productId)
        {
            return true;
        }

        public delegate Task OnProductSelectedHandler(int productId);
        public event OnProductSelectedHandler OnProductSelected;

        public async Task SelectProduct(int productId)
        {
            await OnProductSelected(productId);
        }

    }
}
