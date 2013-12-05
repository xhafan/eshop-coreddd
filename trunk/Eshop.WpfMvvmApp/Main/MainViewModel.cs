using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CoreMvvm;
using CoreUtils.Extensions;
using Eshop.WpfMvvmApp.ControllerClients;

namespace Eshop.WpfMvvmApp.Main
{
    public class MainViewModel : NotifyingObject
    {
        private readonly IProductControllerClient _productControllerClient;
        private readonly RelayCommandAsync<string> _searchProductsCommand;
        private readonly ObservableCollection<string> _products = new ObservableCollection<string>();

        public MainViewModel(IProductControllerClient productControllerClient)
        {
            _productControllerClient = productControllerClient;
            _searchProductsCommand = new RelayCommandAsync<string>(async x => await SearchProducts(x), CanSearchProductsExecute);
        }

        public ObservableCollection<string> Products { get { return _products; } }
        public ICommand SearchProductsCommand { get { return _searchProductsCommand; } }
        public string SearchText { get; set; }

        public bool IsBusy { get; private set; }
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
            products.Each(x => Products.Add(x.Name));

            IsBusy = false;
        }
    }
}
