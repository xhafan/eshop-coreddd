using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace CoreWebApiClient
{
    public abstract class BaseApiControllerClient
    {
        private const string ControllerClientSuffix = "ControllerClient";
        private readonly IAuthenticationCookiePersister _authenticationCookiePersister;
        private readonly string _serverUrl;
        private readonly string _controllerName;
        private readonly RouteCollection _routes;

        protected BaseApiControllerClient(string serverUrl, RouteCollection routes)
        {
            _serverUrl = serverUrl;
            _routes = routes;

            var typeName = GetType().Name;
            var indexOfControllerProxySubstring = typeName.IndexOf(ControllerClientSuffix);
            _controllerName = typeName.Substring(0, indexOfControllerProxySubstring);
        }

        protected BaseApiControllerClient(string serverUrl, RouteCollection routes, IAuthenticationCookiePersister authenticationCookiePersister)
            : this(serverUrl, routes)
        {
            _authenticationCookiePersister = authenticationCookiePersister;
        }

        protected TResult HttpClientGet<TResult>(string controllerActionName, RouteValueDictionary routeValues)
        {
            return HttpClientGetAsync<TResult>(controllerActionName, routeValues).Result;
        }

        protected async Task<TResult> HttpClientGetAsync<TResult>(string controllerActionName, RouteValueDictionary routeValues)
        {
            var url = _buildUrl(_routes, controllerActionName, routeValues);
            return await ExecuteHttpClientActionAsync(url, async (client, cookies) =>
            {
                var response = await client.GetAsync(url);
                _ensureSuccessStatusCode(response);
                return await response.Content.ReadAsAsync<TResult>();
            });
        }

        protected void HttpClientPost(string controllerActionName, object parameter, RouteValueDictionary routeValues)
        {
            HttpClientPostAsync(controllerActionName, parameter, routeValues).Wait();
        }

        protected async Task HttpClientPostAsync(string controllerActionName, object parameter, RouteValueDictionary routeValues)
        {
            var url = _buildUrl(_routes, controllerActionName, routeValues);
            await ExecuteHttpClientActionAsync(url, async (client, cookies) =>
                {
                    var response = await client.PostAsJsonAsync(url, parameter);
                    _ensureSuccessStatusCode(response);
                });
        }

        protected TResult HttpClientPost<TResult>(string controllerActionName, object parameter, RouteValueDictionary routeValues)
        {
            return HttpClientPostAsync<TResult>(controllerActionName, parameter, routeValues).Result;
        }

        protected async Task<TResult> HttpClientPostAsync<TResult>(string controllerActionName, object parameter, RouteValueDictionary routeValues)
        {
            var url = _buildUrl(_routes, controllerActionName, routeValues);

            return await ExecuteHttpClientActionAsync(url, async (client, cookies) =>
                {
                    var response = await client.PostAsJsonAsync(url, parameter);
                    _ensureSuccessStatusCode(response);
                    return await response.Content.ReadAsAsync<TResult>();
                });
        }

        private async Task<TResult> ExecuteHttpClientActionAsync<TResult>(string url, Func<HttpClient, CookieContainer, Task<TResult>> httpClientAction)
        {
            var cookies = GetCookieContainerWithAuthenticationCookie();
            using (var handler = new HttpClientHandler { CookieContainer = cookies })
            using (var client = new HttpClient(handler))
            {
                _addAcceptJsonHeader(client);
                var result = await httpClientAction(client, cookies);
                PersistAuthenticationCookie(url, cookies);
                return result;
            }
        }

        private void PersistAuthenticationCookie(string url, CookieContainer cookies)
        {
            if (_authenticationCookiePersister != null)
            {
                _authenticationCookiePersister.SetPersistentAuthenticationCookie(GetAuthenticationCookie(cookies, url));
            }
        }

        private CookieContainer GetCookieContainerWithAuthenticationCookie()
        {
            var cookies = new CookieContainer();
            if (_authenticationCookiePersister != null)
            {
                var authenticationCookie = _authenticationCookiePersister.GetPersistentAuthenticationCookie();
                if (authenticationCookie != null)
                {
                    cookies.Add(authenticationCookie);
                }
            }
            return cookies;
        }

        private async Task ExecuteHttpClientActionAsync(string url, Func<HttpClient, CookieContainer, Task> httpClientAction)
        {
            var cookies = GetCookieContainerWithAuthenticationCookie();
            using (var handler = new HttpClientHandler { CookieContainer = cookies })
            using (var client = new HttpClient(handler))
            {
                _addAcceptJsonHeader(client);
                await httpClientAction(client, cookies);
                PersistAuthenticationCookie(url, cookies);
            }
        }

        private Cookie GetAuthenticationCookie(CookieContainer cookies, string url)
        {
            var authenticationCookie = cookies.GetCookies(new Uri(url)).Cast<Cookie>().FirstOrDefault(x => x.Name == FormsAuthentication.FormsCookieName);
            if (authenticationCookie != null) authenticationCookie.Path = "/";
            return authenticationCookie;
        }

        private void _ensureSuccessStatusCode(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode) return;
            var content = response.Content.ReadAsStringAsync().Result;
            throw new HttpRequestException(string.Format("Response status code does not indicate success: {0} {1}.\n\n{2}", (int)response.StatusCode, response.StatusCode, content));
        }

        private void _addAcceptJsonHeader(HttpClient client)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private string _buildUrl(RouteCollection routeCollection, string controllerActionName, RouteValueDictionary routeValues)
        {
            var requestContext = new RequestContext(new FakeHttpContext(_serverUrl), new RouteData());
            routeValues.Add("Controller", _controllerName);
            routeValues.Add("Action", controllerActionName);
            return routeCollection.GetVirtualPathForArea(requestContext, routeValues).VirtualPath;
        }
    }
}