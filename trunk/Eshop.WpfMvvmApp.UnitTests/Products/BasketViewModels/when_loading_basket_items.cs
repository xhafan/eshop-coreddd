using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreTest;
using Eshop.Dtos;
using Eshop.WpfMvvmApp.ControllerClients;
using Eshop.WpfMvvmApp.Products;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Products.BasketViewModels
{
    [TestFixture]
    public class when_loading_basket_items : BaseTest
    {
        private const int ProductId = 23;
        private BasketViewModel _viewModel;

        [SetUp]
        public async void Context()
        {
            var basketItemDtos = new[] { new BasketItemDto { ProductId = ProductId }};
            var basketControllerClient = Stub<IBasketControllerClient>().Stubs(x => x.GetBasketItemsAsync()).Returns(TaskEx.FromResult<IEnumerable<BasketItemDto>>(basketItemDtos));
            _viewModel = new BasketViewModel(basketControllerClient);
            
            await _viewModel.LoadBasketItems();
        }

        [Test]
        public void basket_items_are_loaded()
        {
            _viewModel.BasketItems.Count.ShouldBe(1);
            _viewModel.BasketItems.First().ProductId.ShouldBe(ProductId);
        }
    }
}