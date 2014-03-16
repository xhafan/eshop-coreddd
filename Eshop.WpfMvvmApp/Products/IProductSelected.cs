using System.Threading.Tasks;

namespace Eshop.WpfMvvmApp.Products
{
    public interface IProductSelected
    {
        Task ProductSelected(int productId);
    }
}