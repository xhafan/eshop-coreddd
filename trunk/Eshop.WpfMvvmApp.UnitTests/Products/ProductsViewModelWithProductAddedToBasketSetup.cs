using System.Threading.Tasks;
using Eshop.Dtos;
using Eshop.WpfMvvmApp.Products;
using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.WpfMvvmApp.UnitTests.Products
{
    public abstract class ProductsViewModelWithProductAddedToBasketSetup : ProductsViewModelWithSelectedProductFromSearchResultSetup
    {
        protected const int ProductTwoId = 24;
        protected const string ProductTwoName = "product two name";
        protected const decimal ProductTwoPrice = 57.8m;
        protected const int ProductOneQuantity = 2;
        protected const int ProductTwoQuantity = 3;
        protected const string DeliveryAddress = "delivery address";

        [SetUp]
        public override void Context()
        {
            base.Context();
            ExpectProductAddedToBasket();
            StubBasketItemsFromControllerClient();

            AddProductToBasket();
        }

        private void AddProductToBasket()
        {
            GetCurrentViewModelAsProductDetails().AddToBasketCommand.Execute(ProductOneQuantity);
        }

        private void ExpectProductAddedToBasket()
        {
            BasketControllerClient.Expect(x => x.AddProductToBasketAsync(ProductOneId, ProductOneQuantity)).Return(TaskEx.FromResult(0));
        }

        private void StubBasketItemsFromControllerClient()
        {
            var basketItemDtos = new[]
            {
                new BasketItemDto
                {
                    ProductId = ProductOneId,
                    ProductName = ProductOneName,
                    ProductPrice = ProductOnePrice,
                    Quantity = ProductOneQuantity
                },
                new BasketItemDto
                {
                    ProductId = ProductTwoId,
                    ProductName = ProductTwoName,
                    ProductPrice = ProductTwoPrice,
                    Quantity = ProductTwoQuantity
                },
            };
            BasketControllerClient.Stubs(x => x.GetBasketItemsAsync()).Returns(TaskEx.FromResult(basketItemDtos));
        }

        protected BasketViewModel GetCurrentViewModelAsBasket()
        {
            return (BasketViewModel)ViewModel.CurrentViewModel;
        }

        protected ReviewOrderViewModel GetCurrentViewModelAsReviewOrder()
        {
            return (ReviewOrderViewModel)ViewModel.CurrentViewModel;
        }

        protected void ProceedToCheckout()
        {
            GetCurrentViewModelAsBasket().ProceedToCheckoutCommand.Execute(null);
        }

        protected void StubNoDeliveryAddressOnControllerClient()
        {
            DeliveryAddressControllerClient.Stubs(x => x.GetDeliveryAddressAsync()).Returns(TaskEx.FromResult(""));
        }

        protected DeliveryAddressViewModel GetCurrentViewModelAsDeliveryAddress()
        {
            return (DeliveryAddressViewModel)ViewModel.CurrentViewModel;
        }

        protected void StubReviewOrderDataOnControllerClient()
        {
            OrderControllerClient.Stubs(x => x.GetReviewOrderDtoAsync()).Returns(TaskEx.FromResult(GetReviewOrderDto()));
        }


        private ReviewOrderDto GetReviewOrderDto()
        {
            var basketItemDtos = new[]
            {
                new BasketItemDto
                {
                    ProductId = ProductOneId,
                    ProductPrice = ProductOnePrice,
                    Quantity = ProductOneQuantity
                },
                new BasketItemDto
                {
                    ProductId = ProductTwoId,
                    ProductPrice = ProductTwoPrice,
                    Quantity = ProductTwoQuantity
                },
            };
            var deliveryAddressDto = new DeliveryAddressDto { DeliveryAddress = DeliveryAddress };
            var reviewOrderDto = new ReviewOrderDto
            {
                BasketItems = basketItemDtos,
                DeliveryAddress = deliveryAddressDto
            };
            return reviewOrderDto;
        }

        protected void StubExistingDeliveryAddressOnControllerClient()
        {
            DeliveryAddressControllerClient.Stubs(x => x.GetDeliveryAddressAsync()).Returns(TaskEx.FromResult(DeliveryAddress));
        }
    }
}