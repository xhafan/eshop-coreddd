using CoreMvvm;
using Eshop.WpfMvvmApp.Products;

namespace Eshop.WpfMvvmApp.Main
{
    public class MainViewModel : NotifyingObject
    {
        private readonly ProductsViewModel _productsViewModel;

        public MainViewModel(
            ProductsViewModel productsViewModel
            )
        {
            _productsViewModel = productsViewModel;

            CurrentViewModel = _productsViewModel;
        }

        public NotifyingObject CurrentViewModel { get; private set; }
    }
}
