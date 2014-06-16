﻿using System.Threading.Tasks;
using Eshop.Dtos;
using Eshop.WpfMvvmApp.Products;
using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.WpfMvvmApp.UnitTests.Chicago.Products.ProductsViewModels
{
    public abstract class ProductsViewModelWithSearchedProductsSetup : ProductsViewModelSetup
    {
        protected const string SearchedText = "searched text";
        protected const int ProductOneId = 23;
        protected const string ProductOneName = "product one name";

        [SetUp]
        public override void Context()
        {
            base.Context();
            StubProductSearchResultFromControllerClient();

            SearchProduct();
        }

        private void SearchProduct()
        {
            ViewModel.ProductSearch.SearchProductsCommand.Execute(SearchedText);
        }

        private void StubProductSearchResultFromControllerClient()
        {
            ProductControllerClient
                .Stubs(x => x.SearchProductsAsync(SearchedText))
                    .Returns(TaskEx.FromResult(new[] {new ProductSummaryDto {Id = ProductOneId, Name = ProductOneName}}));
        }

        protected ProductSearchResultViewModel2 GetCurrentViewModelAsProductSearchResult()
        {
            return (ProductSearchResultViewModel2)ViewModel.CurrentViewModel;
        }
    }
}