using System.Threading.Tasks;
using Eshop.Dtos;
using Eshop.WpfMvvmApp.Products;
using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.WpfMvvmApp.UnitTests.Chicago.Products.ProductsViewModels
{
    public abstract class ProductsViewModelWithProductAddedToBasketSetup : ProductsViewModelWithSelectedProductFromSearchResultSetup
    {
        protected const int ProductTwoId = 24;
        protected const string ProductTwoName = "product two name";
        protected const decimal ProductTwoPrice = 57.8m;
        protected const int ProductOneQuantity = 2;
        protected const int ProductTwoQuantity = 3;

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

        protected BasketViewModel2 GetCurrentViewModelAsBasket()
        {
            return (BasketViewModel2)ViewModel.CurrentViewModel;
        }

        protected ReviewOrderViewModel2 GetCurrentViewModelAsReviewOrder()
        {
            return (ReviewOrderViewModel2)ViewModel.CurrentViewModel;
        }
    }
}