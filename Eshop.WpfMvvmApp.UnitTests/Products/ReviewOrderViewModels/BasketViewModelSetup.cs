using CoreTest;
using Eshop.WpfMvvmApp.ControllerClients;
using Eshop.WpfMvvmApp.Products;
using NUnit.Framework;

namespace Eshop.WpfMvvmApp.UnitTests.Products.ReviewOrderViewModels
{
    public abstract class ReviewOrderViewModelSetup : BaseTest
    {
        protected const int ProductOneId = 23;
        protected const int ProductTwoId = 24;
        protected ReviewOrderViewModel ViewModel;
        protected IBasketControllerClient BasketControllerClient;
        protected IOnPlacingOrder OnPlacingOrder;

        [SetUp]
        public virtual void Context()
        {
            BasketControllerClient = Mock<IBasketControllerClient>();
            OnPlacingOrder = Mock<IOnPlacingOrder>();
            ViewModel = new ReviewOrderViewModel(BasketControllerClient, OnPlacingOrder);
        }
    }
}