using System.Threading.Tasks;

namespace Eshop.WpfMvvmApp.Products
{
    public interface IOnPlacingOrder
    {
        Task OrderPlaced();
    }
}