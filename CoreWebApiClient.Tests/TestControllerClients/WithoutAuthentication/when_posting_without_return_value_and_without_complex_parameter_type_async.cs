using NUnit.Framework;

namespace CoreWebApiClient.Tests.TestControllerClients.WithoutAuthentication
{
    [TestFixture]
    public class when_posting_without_return_value_and_without_complex_parameter_type_async : TestControllerClientWithoutAuthenticationSetup
    {
        [Test]
        public async void does_not_throw()
        {
            const string value = "value";

            await ControllerClient.PostWithoutReturnValueAndWithoutComplexParameterTypeAsync(value);
        }
    }
}