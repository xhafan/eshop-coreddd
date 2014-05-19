using CoreTest;
using Eshop.WpfMvvmApp.ControllerClients;
using NUnit.Framework;
using Shouldly;

namespace Eshop.IntegrationTests.WpfMvvmApp.ControllerClients.AuthenticationCookiePersisters
{
    [TestFixture]
    public class when_setting_null_persistent_cookie : BaseTest
    {
        private AuthenticationCookiePersister _authenticationCookiePersister;

        [SetUp]
        public void Context()
        {
            _authenticationCookiePersister = new AuthenticationCookiePersister();
        }

        [Test]
        public void setting_cookie_as_null_should_not_throw()
        {
            Should.NotThrow(() => _authenticationCookiePersister.SetPersistentAuthenticationCookie(null));
        }
    }
}