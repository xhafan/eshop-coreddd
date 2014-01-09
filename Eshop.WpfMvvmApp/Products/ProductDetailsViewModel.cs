using System.Threading.Tasks;
using CoreMvvm;
using Eshop.WpfMvvmApp.ControllerClients;

namespace Eshop.WpfMvvmApp.Products
{
    public class ProductDetailsViewModel : NotifyingObject
    {
        private readonly IProductControllerClient _productControllerClient;
        
        public ProductDetailsViewModel(IProductControllerClient productControllerClient)
        {
            _productControllerClient = productControllerClient;
        }

        public bool IsBusy { get; private set; } // todo: refactor this into some base view model
        public bool IsNotBusy { get { return !IsBusy; } }

        public string Name { get; private set; }
        public string Description { get; private set; }

        public async Task LoadProduct(int productId)
        {
            IsBusy = true;

            var productDetails = await _productControllerClient.GetAsync(productId);
            Name = productDetails.Name;
            Description = productDetails.Description;

            IsBusy = false;
        }
    }
}
