using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using CoreMvvm;
using Eshop.Dtos;
using Eshop.WpfMvvmApp.ControllerClients;

namespace Eshop.WpfMvvmApp.Products
{
    public class ProductSearchViewModel : NotifyingObject
    {
        private readonly IProductControllerClient _productControllerClient;
        private readonly IEventAggregator _eventAggregator;

        private readonly RelayCommandAsync<string> _searchProductsCommand;
        
        public ProductSearchViewModel(IProductControllerClient productControllerClient, IEventAggregator eventAggregator)
        {
            _productControllerClient = productControllerClient;
            _eventAggregator = eventAggregator;

            _searchProductsCommand = new RelayCommandAsync<string>(async x => await SearchProducts(x), CanSearchProductsExecute);
        }

        public string SearchText { get; set; }

        public ICommand SearchProductsCommand { get { return _searchProductsCommand; } }

        public bool IsBusy { get; private set; } // todo: refactor this into some base view model
        public bool IsNotBusy { get { return !IsBusy; } }

        public bool CanSearchProductsExecute(string searchText)
        {
            return true;
        }

        public async Task SearchProducts(string searchText)
        {
            IsBusy = true;

            var products = await _productControllerClient.GetSearchProductsAsync(searchText);
            await _eventAggregator.Publish(new ProductSearchedEvent { Products = products });

            IsBusy = false;
        }
    }
}
