using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CoreMvvm;
using CoreUtils.Extensions;
using Eshop.Dtos;

namespace Eshop.WpfMvvmApp.Products
{
    public class ProductSearchResultViewModel : NotifyingObject
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly ObservableCollection<ProductViewModel> _products = new ObservableCollection<ProductViewModel>();
        
        private readonly RelayCommandAsync<int> _selectProductCommand;

        public ProductSearchResultViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _selectProductCommand = new RelayCommandAsync<int>(async x => await SelectProduct(x), CanSelectProductExecute);
        }

        public ObservableCollection<ProductViewModel> Products { get { return _products; } }

        public ICommand SelectProductCommand { get { return _selectProductCommand; } }

        public Task PopulateSearchResult(IEnumerable<ProductSummaryDto> products)
        {
            Products.Clear();
            products.Each(x => Products.Add(new ProductViewModel(x.Id, x.Name)));
            return TaskEx.FromResult(0); // todo: extract this to TaskEx.CompletedTask(); or sth
        }
        
        public bool CanSelectProductExecute(int productId)
        {
            return true;
        }

        public async Task SelectProduct(int productId)
        {
            await _eventAggregator.Publish(new ProductSelectedEvent { ProductId = productId });
        }
    }
}