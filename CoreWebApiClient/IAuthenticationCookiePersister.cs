using System.Net;

namespace CoreWebApiClient
{
    public interface IAuthenticationCookiePersister
    {
        Cookie GetPersistentAuthenticationCookie();
        void SetPersistentAuthenticationCookie(Cookie cookie);
    }
}