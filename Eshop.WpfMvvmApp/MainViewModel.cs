using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CoreMvvm;
using CoreUtils.Extensions;
using Eshop.WpfMvvmApp.ControllerClients;

namespace Eshop.WpfMvvmApp
{
    public class MainViewModel : NotifyingObject
    {
        private readonly IProductControllerClient _productControllerClient;
        private readonly ObservableCollection<string> _products = new ObservableCollection<string>();
        private readonly RelayCommandAsync<string> _getProductsCommand;

        public MainViewModel(IProductControllerClient productControllerClient)
        {
            _productControllerClient = productControllerClient;
            _getProductsCommand = new RelayCommandAsync<string>(async x => await GetProductsAsync(x), CanGetProducts);
        }

        public ObservableCollection<string> Products { get { return _products; } }
        public ICommand GetProductsCommand { get { return _getProductsCommand; } }
        public bool IsBusy { get; private set; }
        public bool IsNotBusy { get { return !IsBusy; } }

        public bool CanGetProducts(string name)
        {
            return true;
        }

        public async Task GetProductsAsync(string name)
        {
            IsBusy = true;

            var products = await _productControllerClient.GetAsync();
            Products.Clear();
            products.Each(x => Products.Add(x));

            IsBusy = false;
        }
    }
}
