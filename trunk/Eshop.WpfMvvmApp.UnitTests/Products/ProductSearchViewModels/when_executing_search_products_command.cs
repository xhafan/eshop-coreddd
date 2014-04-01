using System.Collections.Generic;
using System.Threading.Tasks;
using Eshop.Dtos;
using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.WpfMvvmApp.UnitTests.Products.ProductSearchViewModels
{
    [TestFixture]
    public class when_executing_search_products_command : ProductSearchViewModelSetup
    {
        private IEnumerable<ProductSummaryDto> _productSummaryDtos;
        private const string SearchText = "search text";

        [SetUp]
        public override void Context()
        {
            base.Context();
            _productSummaryDtos = new[] { new ProductSummaryDto() };
            ProductControllerClient.Stubs(x => x.SearchProductsAsync(SearchText)).Returns(TaskEx.FromResult(_productSummaryDtos));
            
            ViewModel.SearchProductsCommand.Execute(SearchText);
        }

        [Test]
        public void product_searched_service_is_notified()
        {
            ProductSearched.AssertWasCalled(x => x.ProductSearched(_productSummaryDtos));
        }
    }
}