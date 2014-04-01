using NUnit.Framework;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Products.ProductSearchViewModels
{
    [TestFixture]
    public class when_can_execute_search_products_command : ProductSearchViewModelSetup
    {
        private bool _canExecute;
        private const string SearchText = "search text";

        [SetUp]
        public override void Context()
        {
            base.Context();

            _canExecute = ViewModel.SearchProductsCommand.CanExecute(SearchText);
        }

        [Test]
        public void can_always_execute()
        {
            _canExecute.ShouldBe(true);
        }
    }
}