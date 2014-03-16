namespace Eshop.WpfMvvmApp.Products
{
    public interface IProductDetailsViewModelFactory
    {
        ProductDetailsViewModel Create(IProductAddedToBasket productAddedToBasket);
    }
}