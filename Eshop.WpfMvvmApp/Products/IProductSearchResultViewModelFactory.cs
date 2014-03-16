namespace Eshop.WpfMvvmApp.Products
{
    public interface IProductSearchResultViewModelFactory
    {
        ProductSearchResultViewModel Create(IProductSelected productSelected);
    }
}