using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using CoreTest;
using Eshop.WpfMvvmApp.ControllerClients;
using NUnit.Framework;
using Shouldly;

namespace Eshop.IntegrationTests.WpfMvvmApp.ControllerClients.AuthenticationCookiePersisters
{
    [TestFixture]
    public class when_setting_cookie_and_getting_it_again_in_another_persister_instance : BaseTest
    {
        private const string CookieName = "cookie_name";
        private const string CookieValue = "cookie value";
        private Cookie _retrievedCookie;
        private Cookie _savedCookie;

        [SetUp]
        public void Context()
        {
            var authenticationCookiePersister = new AuthenticationCookiePersister();
            _savedCookie = new Cookie(CookieName, CookieValue);
            authenticationCookiePersister.SetPersistentAuthenticationCookie(_savedCookie);

            authenticationCookiePersister = new AuthenticationCookiePersister();
            _retrievedCookie = authenticationCookiePersister.GetPersistentAuthenticationCookie();
        }

        [Test]
        public void cookie_is_correct()
        {
            _retrievedCookie.Name.ShouldBe(CookieName);
            _retrievedCookie.Value.ShouldBe(CookieValue);
        }

        [Test]
        public void saved_cookie_is_the_same_as_retrieved_cookie()
        {
            GetSerializedBytes(_savedCookie).ShouldBe(GetSerializedBytes(_retrievedCookie));
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(AuthenticationCookiePersister.PersistentCookiePath);
        }

        private byte[] GetSerializedBytes(Cookie cookie)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, cookie);
                return ms.ToArray();
            }            
        }
    }
}
