using CoreWebApiClient.Tests.ControllerClients;
using NUnit.Framework;

namespace CoreWebApiClient.Tests.TestControllerClients.WithoutAuthentication
{
    public abstract class TestControllerClientWithoutAuthenticationSetup
    {
        protected TestControllerClient ControllerClient;

        [SetUp]
        public void Context()
        {
            ControllerClient = new TestControllerClient(RunOncePerTestRun.TestServerUrl, RoutesProvider.GetDefaultRoutes());
        }
    }
}