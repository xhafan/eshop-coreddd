using CoreTest;
using Eshop.Dtos;
using Eshop.WpfMvvmApp.Products;
using NUnit.Framework;

namespace Eshop.WpfMvvmApp.UnitTests.Products.BasketItemViewModels
{
    public abstract class BasketItemViewModelSetup : BaseTest
    {
        protected const int ProductId = 23;
        protected const string ProductName = "product name";
        protected const int Quantity = 34;
        protected const decimal ProductPrice = 45.6m;
        protected BasketItemViewModel ViewModel;

        [SetUp]
        public virtual void Context()
        {
            var basketItemDto = new BasketItemDto
            {
                ProductId = ProductId,
                ProductName = ProductName,
                ProductPrice = ProductPrice,
                Quantity = Quantity
            };

            ViewModel = new BasketItemViewModel(basketItemDto);
        }
    }
}