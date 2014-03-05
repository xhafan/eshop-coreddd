using System.Net;

namespace CoreWebApiClient.Tests.TestControllerClients.WithAuthentication
{
    public class TestAuthenticationCookiePersister : IAuthenticationCookiePersister
    {
        private Cookie _cookie;

        public Cookie GetPersistentAuthenticationCookie()
        {
            return _cookie;
        }

        public void SetPersistentAuthenticationCookie(Cookie cookie)
        {
            _cookie = cookie;
        }
    }
}