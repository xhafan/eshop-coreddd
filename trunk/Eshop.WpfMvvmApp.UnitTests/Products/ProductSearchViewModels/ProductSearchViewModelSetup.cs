using CoreTest;
using Eshop.WpfMvvmApp.ControllerClients;
using Eshop.WpfMvvmApp.Products;
using NUnit.Framework;

namespace Eshop.WpfMvvmApp.UnitTests.Products.ProductSearchViewModels
{
    public abstract class ProductSearchViewModelSetup : BaseTest
    {
        protected IProductSearched ProductSearched;
        protected IProductControllerClient ProductControllerClient;
        protected ProductSearchViewModel ViewModel;

        [SetUp]
        public virtual void Context()
        {
            ProductControllerClient = Stub<IProductControllerClient>();
            ProductSearched = Mock<IProductSearched>();
            ViewModel = new ProductSearchViewModel(ProductControllerClient, ProductSearched);            
        }
    }
}