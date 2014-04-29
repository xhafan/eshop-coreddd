namespace Eshop.WpfMvvmApp.Products
{
    public interface IBasketViewModelFactory
    {
        BasketViewModel Create(IOnProceedingToCheckout onProceedingToCheckout);
    }
}