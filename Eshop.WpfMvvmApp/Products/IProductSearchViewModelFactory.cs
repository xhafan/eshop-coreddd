namespace Eshop.WpfMvvmApp.Products
{
    public interface IProductSearchViewModelFactory
    {
        ProductSearchViewModel Create(IProductSearched productSearched);
    }
}