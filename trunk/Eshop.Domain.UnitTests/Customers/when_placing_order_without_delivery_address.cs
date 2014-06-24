using System;
using CoreUtils;
using NUnit.Framework;
using Shouldly;

namespace Eshop.Domain.UnitTests.Customers
{
    [TestFixture]
    public class when_placing_order_without_delivery_address : CustomerWithProductAddedToBasketSetup
    {
        private Exception _exception;

        [SetUp]
        public override void Context()
        {
            base.Context();

            _exception = Should.Throw<CoreException>(() => Customer.PlaceOrder());
        }

        [Test]
        public void exception_is_thrown()
        {
            _exception.Message.ShouldBe("Deliver address is not set");
        }
    }
}