using CoreMvvm;
using Eshop.WpfMvvmApp.ControllerClients;

namespace Eshop.WpfMvvmApp.Products
{
    public class BasketViewModel : NotifyingObject
    {
        public BasketViewModel(IProductControllerClient productControllerClient)
        {
        }
    }
}