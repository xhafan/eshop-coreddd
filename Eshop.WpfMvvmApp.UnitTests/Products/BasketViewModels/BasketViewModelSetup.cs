using CoreTest;
using Eshop.WpfMvvmApp.ControllerClients;
using Eshop.WpfMvvmApp.Products;
using NUnit.Framework;

namespace Eshop.WpfMvvmApp.UnitTests.Products.BasketViewModels
{
    public abstract class BasketViewModelSetup : BaseTest
    {
        protected const int ProductOneId = 23;
        protected const int ProductTwoId = 24;
        protected BasketViewModel ViewModel;
        protected IBasketControllerClient BasketControllerClient;

        [SetUp]
        public virtual void Context()
        {
            BasketControllerClient = Mock<IBasketControllerClient>();
            ViewModel = new BasketViewModel(BasketControllerClient);
        }
    }
}