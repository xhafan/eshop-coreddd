﻿using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Products.ReviewOrderViewModels
{
    [TestFixture]
    public class when_loading_basket_items : ReviewOrderViewModelWithLoadedBasketItemsSetup
    {
        [Test]
        public void basket_items_are_loaded()
        {
            ViewModel.BasketItems.Count.ShouldBe(2);
            ViewModel.BasketItems.First().ProductId.ShouldBe(ProductOneId);
            ViewModel.BasketItems.ElementAt(1).ProductId.ShouldBe(ProductTwoId);
        }

        [Test]
        public void subtotal_is_refreshed()
        {
            ViewModel.Subtotal.ShouldBe(264.6m);
        }
    }
}