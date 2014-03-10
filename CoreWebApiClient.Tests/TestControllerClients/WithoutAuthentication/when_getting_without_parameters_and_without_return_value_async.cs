using NUnit.Framework;

namespace CoreWebApiClient.Tests.TestControllerClients.WithoutAuthentication
{
    [TestFixture]
    public class when_getting_without_parameters_and_without_return_value_async : TestControllerClientWithoutAuthenticationSetup
    {
        [Test]
        public async void does_not_throw()
        {
            await ControllerClient.AGetWithoutParametersAsync();
        }
    }
}