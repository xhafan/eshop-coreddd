using System.IO;
using System.Net;
using CoreTest;
using Eshop.WpfMvvmApp.ControllerClients;
using NUnit.Framework;
using Shouldly;

namespace Eshop.IntegrationTests.WpfMvvmApp.ControllerClients.AuthenticationCookiePersisters
{
    [TestFixture]
    public class when_getting_persistent_cookie_which_cannot_be_deserialized : BaseTest
    {
        private Cookie _cookie;

        [SetUp]
        public void Context()
        {
            File.WriteAllText(AuthenticationCookiePersister.PersistentCookiePath, "nonsence nonsence nonsence nonsence nonsence nonsence nonsence");

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