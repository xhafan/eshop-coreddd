using System.Threading.Tasks;

namespace Eshop.WpfMvvmApp.Products
{
    public interface IOnProceedingToCheckout
    {
        Task ProceededToCheckout();
    }
}