using System.Web.Security;
using CoreWebApiClient.Tests.ControllerClients;
using NUnit.Framework;

namespace CoreWebApiClient.Tests.TestControllerClients.WithAuthentication
{
    public abstract class TestControllerClientWithAuthenticationSetup
    {
        protected TestAuthenticatedControllerClient ControllerClient;
        protected IAuthenticationCookiePersister AuthenticationCookiePersister;

        [SetUp]
        public void Context()
        {
            AuthenticationCookiePersister = new TestAuthenticationCookiePersister();
            ControllerClient = new TestAuthenticatedControllerClient(RunOncePerTestRun.TestServerUrl, RoutesProvider.GetDefaultRoutes(), AuthenticationCookiePersister);
            ControllerClient.Login("user name", "password");
        }

        protected abstract void Act();

        [Test]
        public void AuthenticationCookieIsSet()
        {
            var authenticationCookie = AuthenticationCookiePersister.GetPersistentAuthenticationCookie();
            Assert.That(authenticationCookie, Is.Not.Null);
            Assert.That(authenticationCookie.Name, Is.EqualTo(FormsAuthentication.FormsCookieName));

            Act();

            Assert.That(AuthenticationCookiePersister.GetPersistentAuthenticationCookie(), Is.Not.Null);
        }
    }
}