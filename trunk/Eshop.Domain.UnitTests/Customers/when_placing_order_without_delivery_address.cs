using System;
using CoreTest;
using CoreUtils;
using NUnit.Framework;
using Shouldly;

namespace Eshop.Domain.UnitTests.Customers
{
    [TestFixture]
    public class when_placing_order_without_delivery_address : BaseTest
    {
        private Customer _customer;
        private Exception _exception;

        [SetUp]
        public void Context()
        {
            _customer = new Customer();

            _exception = Should.Throw<CoreException>(() => _customer.PlaceOrder());
        }

        [Test]
        public void exception_is_thrown()
        {
            _exception.Message.ShouldBe(Customer.MissingDeliveryAddressExceptionMessage);
        }
    }
}