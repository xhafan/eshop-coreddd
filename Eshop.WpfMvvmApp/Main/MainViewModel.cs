using CoreMvvm;
using Eshop.WpfMvvmApp.Products;

namespace Eshop.WpfMvvmApp.Main
{
    public class MainViewModel : NotifyingObject
    {
        private readonly ProductSearchViewModel _productSearchViewModel;
        private readonly ProductDetailsViewModel _productDetailsViewModel;

        public MainViewModel(
            ProductSearchViewModel productSearchViewModel,
            ProductDetailsViewModel productDetailsViewModel
            )
        {
            _productSearchViewModel = productSearchViewModel;
            _productDetailsViewModel = productDetailsViewModel;

            _productSearchViewModel.OnProductSelected += async productId =>
                {
                    await productDetailsViewModel.LoadProduct(productId);
                    CurrentViewModel = _productDetailsViewModel;
                };
            
            CurrentViewModel = _productSearchViewModel;
        }

        public NotifyingObject CurrentViewModel { get; private set; }
    }
}
