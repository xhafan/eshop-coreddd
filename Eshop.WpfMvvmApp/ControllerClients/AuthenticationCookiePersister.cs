using System.Net;
using CoreWebApiClient;

namespace Eshop.WpfMvvmApp.ControllerClients
{
    public class AuthenticationCookiePersister : IAuthenticationCookiePersister // todo: save it to disk and test it
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