using CoreMvvm;
using Eshop.WpfMvvmApp.Products;

namespace Eshop.WpfMvvmApp.Main
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(
            ProductsViewModel productsViewModel
            )
        {
            CurrentViewModel = productsViewModel;
        }

        public BaseViewModel CurrentViewModel { get; private set; }
    }
}
