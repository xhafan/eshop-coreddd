using NUnit.Framework;

namespace CoreWebApiClient.Tests.TestControllerClients.WithoutAuthentication
{
    [TestFixture]
    public class when_getting_without_parameters_and_without_return_value : TestControllerClientWithoutAuthenticationSetup
    {
        [Test]
        public void does_not_throw()
        {
            ControllerClient.AGetWithoutParameters();
        }
    }
}