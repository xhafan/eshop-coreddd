using NUnit.Framework;

namespace CoreWebApiClient.Tests.TestControllerClients.WithAuthentication
{
    [TestFixture]
    public class when_getting_without_parameters_and_without_return_value_async : TestControllerClientWithAuthenticationSetup
    {
        protected override void Act()
        {
            ControllerClient.AGetWithoutParametersAsync().Wait();
        }

        [Test]
        public void does_not_throw()
        {
            Act();
        }   
    }
}