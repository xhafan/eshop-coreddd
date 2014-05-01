using System.Threading.Tasks;

namespace Eshop.WpfMvvmApp.Products
{
    public interface IOnDeliveryAddressSet
    {
        Task DeliveryAddressSet(string deliveryAddress);
    }
}