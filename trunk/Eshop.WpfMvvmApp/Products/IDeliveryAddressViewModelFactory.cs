namespace Eshop.WpfMvvmApp.Products
{
    public interface IDeliveryAddressViewModelFactory
    {
        DeliveryAddressViewModel Create(IOnDeliveryAddressSet onDeliveryAddressSet);
    }
}