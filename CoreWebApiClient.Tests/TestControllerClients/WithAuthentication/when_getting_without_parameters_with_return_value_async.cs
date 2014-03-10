﻿using NUnit.Framework;
using Shouldly;

namespace CoreWebApiClient.Tests.TestControllerClients.WithAuthentication
{
    [TestFixture]
    public class when_getting_without_parameters_with_return_value_async : TestControllerClientWithAuthenticationSetup
    {
        private int _value;

        protected override void Act()
        {
            _value = ControllerClient.AGetWithoutParametersWithReturnValueAsync().Result;
        }

        [Test]
        public void return_value_is_correct()
        {
            Act();

            _value.ShouldBe(23);
        }   
    }
}