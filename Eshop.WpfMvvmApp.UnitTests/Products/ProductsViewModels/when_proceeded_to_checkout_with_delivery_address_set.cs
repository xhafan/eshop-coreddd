﻿using System.Threading.Tasks;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Products.ProductsViewModels
{
    [TestFixture]
    public class when_proceeded_to_checkout_with_delivery_address_set : ProductsViewModelSetup
    {
        [SetUp]
        public async override void Context()
        {
            base.Context();
            DeliveryAddressControllerClient.Stubs(x => x.GetDeliveryAddressAsync()).Returns(TaskEx.FromResult("delivery address"));
            ReviewOrder.Expect(x => x.LoadBasketItems()).Return(TaskEx.FromResult(0));

            await ViewModel.ProceededToCheckout();
        }

        [Test]
        public void review_order_loads_basket_items()
        {
            ReviewOrder.VerifyAllExpectations();
        }

        [Test]
        public void current_view_model_is_set()
        {
            ViewModel.CurrentViewModel.ShouldBe(ReviewOrder);
        }
    }
}