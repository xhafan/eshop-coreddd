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
        protected IOrderControllerClient OrderControllerClient;

        [SetUp]
        public virtual void Context()
        {
            BasketControllerClient = Mock<IBasketControllerClient>();
            OrderControllerClient = Stub<IOrderControllerClient>();
            OnPlacingOrder = Mock<IOnPlacingOrder>();

            ViewModel = new ReviewOrderViewModel(BasketControllerClient, OrderControllerClient, OnPlacingOrder);
        }
    }
}