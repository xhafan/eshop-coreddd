﻿using NUnit.Framework;

namespace CoreWebApiClient.Tests.TestControllerClients.WithAuthentication
{
    [TestFixture]
    public class when_posting_without_return_value_and_without_complex_parameter_type : TestControllerClientWithAuthenticationSetup
    {
        const string Value = "value";

        protected override void Act()
        {
            ControllerClient.PostWithoutReturnValueAndWithoutComplexParameterType(Value);
        }

        [Test]
        public void does_not_throw()
        {
            Act();
        }
    }
}