﻿using CoreWebApiClient.TestControllers;
using NUnit.Framework;

namespace CoreWebApiClient.Tests.TestControllerClients.WithAuthentication
{
    [TestFixture]
    public class when_posting_without_return_value_and_without_from_body_attribute_async : TestControllerClientWithAuthenticationSetup
    {
        const int Id = 23;
        const string Name = "name";
        const string Value = "value";

        protected override void Act()
        {
            ControllerClient.PostWithoutReturnValueAndWithoutFromBodyAttributeAsync(new TestDto { Id = Id, Name = Name }, Value).Wait();
        }

        [Test]
        public void does_not_throw()
        {
            Act();
        }
    }
}