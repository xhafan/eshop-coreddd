using System.Collections.Generic;
using System.Threading.Tasks;
using Eshop.Dtos;
using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.WpfMvvmApp.UnitTests.Products.BasketViewModels
{
    public abstract class BasketViewModelWithLoadedBasketItemsSetup : BasketViewModelSetup
    {
        [SetUp]
        public override async void Context()
        {
            base.Context();
            var basketItemDtos = new[]
            {
                new BasketItemDto
                {
                    ProductId = ProductOneId,
                    ProductPrice = 45.6m,
                    Quantity = 2
                },
                new BasketItemDto
                {
                    ProductId = ProductTwoId,
                    ProductPrice = 57.8m,
                    Quantity = 3
                },
            };
            BasketControllerClient.Stubs(x => x.GetBasketItemsAsync()).Returns(TaskEx.FromResult<IEnumerable<BasketItemDto>>(basketItemDtos));

            await ViewModel.LoadBasketItems();
        }
    }
}