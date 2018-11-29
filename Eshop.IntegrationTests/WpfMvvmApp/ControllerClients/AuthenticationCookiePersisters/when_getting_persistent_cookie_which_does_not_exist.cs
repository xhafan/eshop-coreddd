using System.IO;
using System.Net;
using Eshop.WpfMvvmApp.ControllerClients;
using NUnit.Framework;
using Shouldly;

namespace Eshop.IntegrationTests.WpfMvvmApp.ControllerClients.AuthenticationCookiePersisters
{
    [TestFixture]
    public class when_getting_persistent_cookie_which_does_not_exist
    {
        private Cookie _cookie;

        [SetUp]
        public void Context()
        {
            File.Delete(AuthenticationCookiePersister.PersistentCookiePath);

            var authenticationCookiePersister = new AuthenticationCookiePersister();
            _cookie = authenticationCookiePersister.GetPersistentAuthenticationCookie();
        }

        [Test]
        public void cookie_is_null()
        {
            _cookie.ShouldBe(null);
        }
    }
}