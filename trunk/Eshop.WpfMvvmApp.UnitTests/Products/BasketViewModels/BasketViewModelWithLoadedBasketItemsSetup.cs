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
            var basketItemDtos = new[] { new BasketItemDto { ProductId = ProductId }};
            BasketControllerClient.Stubs(x => x.GetBasketItemsAsync()).Returns(TaskEx.FromResult<IEnumerable<BasketItemDto>>(basketItemDtos));

            await ViewModel.LoadBasketItems();
        }
    }
}