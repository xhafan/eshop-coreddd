using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CoreMvvm;
using CoreUtils.Extensions;
using Eshop.Dtos;

namespace Eshop.WpfMvvmApp.Products
{
    public class ProductSearchResultViewModel2 : BaseViewModel
    {
        private readonly ProductsViewModel2 _productsViewModel;
        private readonly ObservableCollection<ProductViewModel> _products = new ObservableCollection<ProductViewModel>();
        private readonly RelayCommandAsync<int> _selectProductCommand;

        public ProductSearchResultViewModel2(ProductsViewModel2 productsViewModel)
        {
            _productsViewModel = productsViewModel;
            _selectProductCommand = new RelayCommandAsync<int>(async x => await _selectProduct(x));
        }

        public ObservableCollection<ProductViewModel> Products { get { return _products; } }
        public ICommand SelectProductCommand { get { return _selectProductCommand; } }

        public void PopulateSearchResult(IEnumerable<ProductSummaryDto> products)
        {
            _products.Clear();
            products.Each(x => _products.Add(new ProductViewModel(x.Id, x.Name)));
        }

        private async Task _selectProduct(int productId)
        {
            await _productsViewModel.ProductSelected(productId);
        }
    }
}