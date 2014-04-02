using CoreTest;
using Eshop.Dtos;
using Eshop.WpfMvvmApp.Products;
using NUnit.Framework;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Products.BasketItemViewModels
{
    [TestFixture]
    public class when_constructing : BaseTest
    {
        private const int ProductId = 23;
        private const string ProductName = "product name";
        private const int Quantity = 34;
        private const decimal ProductPrice = 45.6m;
        private BasketItemViewModel _viewModel;

        [SetUp]
        public void Context()
        {
            var basketItemDto = new BasketItemDto
                {
                    ProductId = ProductId,
                    ProductName = ProductName,
                    ProductPrice = ProductPrice,
                    Quantity = Quantity
                };

            _viewModel = new BasketItemViewModel(basketItemDto);
        }

        [Test]
        public void product_id_is_correct()
        {
            _viewModel.ProductId.ShouldBe(ProductId);
        }

        [Test]
        public void product_name_is_correct()
        {
            _viewModel.ProductName.ShouldBe(ProductName);
        }

        [Test]
        public void price_is_correct()
        {
            _viewModel.ProductPrice.ShouldBe(ProductPrice);
        }

        [Test]
        public void quantity_is_correct()
        {
            _viewModel.Quantity.ShouldBe(Quantity);
        }
    }
}