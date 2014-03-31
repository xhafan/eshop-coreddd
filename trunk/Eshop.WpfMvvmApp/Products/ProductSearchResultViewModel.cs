using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CoreMvvm;
using CoreUtils.Extensions;
using Eshop.Dtos;

namespace Eshop.WpfMvvmApp.Products
{
    public class ProductSearchResultViewModel : BaseViewModel
    {
        private readonly IProductSelected _productSelected;
        private readonly ObservableCollection<ProductViewModel> _products = new ObservableCollection<ProductViewModel>();
        
        private readonly RelayCommandAsync<int> _selectProductCommand;

        public ProductSearchResultViewModel(IProductSelected productSelected)
        {
            _productSelected = productSelected;
            _selectProductCommand = new RelayCommandAsync<int>(async x => await _selectProduct(x), _canSelectProductExecute);
        }

        public ObservableCollection<ProductViewModel> Products { get { return _products; } }

        public ICommand SelectProductCommand { get { return _selectProductCommand; } }

        public void PopulateSearchResult(IEnumerable<ProductSummaryDto> products)
        {
            _products.Clear();
            products.Each(x => _products.Add(new ProductViewModel(x.Id, x.Name)));
        }
        
        private bool _canSelectProductExecute(int productId)
        {
            return true;
        }

        private async Task _selectProduct(int productId)
        {
            await _productSelected.ProductSelected(productId);
        }
    }
}