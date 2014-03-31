using CoreTest;
using Eshop.WpfMvvmApp.Products;
using NUnit.Framework;

namespace Eshop.WpfMvvmApp.UnitTests.Products.ProductSearchResultViewModels
{
    public abstract class ProductSearchResultViewModelSetup : BaseTest
    {
        protected ProductSearchResultViewModel ViewModel;
        protected IProductSelected ProductSelected;

        [SetUp]
        public virtual void Context()
        {
            ProductSelected = Stub<IProductSelected>();
            ViewModel = new ProductSearchResultViewModel(ProductSelected);
        }
    }
}