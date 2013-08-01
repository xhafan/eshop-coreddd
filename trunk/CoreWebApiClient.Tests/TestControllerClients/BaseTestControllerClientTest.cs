using CoreTest;
using CoreWebApiClient.Tests.ControllerClients;
using NUnit.Framework;

namespace CoreWebApiClient.Tests.TestControllerClients
{
    public abstract class BaseTestControllerClientTest : BaseTest
    {
        protected TestControllerClient ControllerClient;

        [SetUp]
        public void Context()
        {
            ControllerClient = new TestControllerClient(RunOncePerTestRun.TestServerUrl, Bootstrapper.Routes);
        }
    }
}