﻿using Eshop.WpfMvvmApp.Products;
using NUnit.Framework;
using Shouldly;

namespace Eshop.WpfMvvmApp.UnitTests.Products
{
    [TestFixture]
    public class when_proceeding_to_checkout_with_delivery_address_not_set : ProductsViewModelWithProductAddedToBasketSetup
    {
        [SetUp]
        public override void Context()
        {
            base.Context();
            StubNoDeliveryAddressOnControllerClient();

            ProceedToCheckout();
        }
        
        [Test]
        public void current_view_model_is_set()
        {
            ViewModel.CurrentViewModel.ShouldBeTypeOf<DeliveryAddressViewModel>();
        }
    }
}