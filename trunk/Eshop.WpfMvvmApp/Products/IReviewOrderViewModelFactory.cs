namespace Eshop.WpfMvvmApp.Products
{
    public interface IReviewOrderViewModelFactory
    {
        ReviewOrderViewModel Create(IOnPlacingOrder onPlacingOrder);
    }
}