using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using CoreWebApiClient.WebApiHelpers;

namespace CoreWebApiClient
{
    public abstract class BaseApiControllerClient
    {
        private const string ControllerClientSuffix = "ControllerClient";
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

        protected TResult HttpClientGet<TResult>(string controllerActionName, RouteValueDictionary routeValues)
        {
            var url = _buildUrl(_routes, controllerActionName, routeValues);

            using (var client = new HttpClient())
            {
                _addAcceptJsonHeader(client);
                var response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsAsync<TResult>().Result;
            }
        }

        protected async Task<TResult> HttpClientGetAsync<TResult>(string controllerActionName, RouteValueDictionary routeValues)
        {
            var url = _buildUrl(_routes, controllerActionName, routeValues);

            using (var client = new HttpClient())
            {
                _addAcceptJsonHeader(client);
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<TResult>();
            }
        }

        protected void HttpClientPost(string controllerActionName, object parameter, RouteValueDictionary routeValues)
        {
            var url = _buildUrl(_routes, controllerActionName, routeValues);

            using (var client = new HttpClient())
            {
                _addAcceptJsonHeader(client);
                var response = client.PostAsJsonAsync(url, parameter).Result;
                response.EnsureSuccessStatusCode();                
            }
        }

        protected async Task HttpClientPostAsync(string controllerActionName, object parameter, RouteValueDictionary routeValues)
        {
            var url = _buildUrl(_routes, controllerActionName, routeValues);

            using (var client = new HttpClient())
            {
                _addAcceptJsonHeader(client);
                var response = await client.PostAsJsonAsync(url, parameter);
                response.EnsureSuccessStatusCode();                
            }
        }

        protected TResult HttpClientPost<TResult>(string controllerActionName, object parameter, RouteValueDictionary routeValues)
        {
            var url = _buildUrl(_routes, controllerActionName, routeValues);

            using (var client = new HttpClient())
            {
                _addAcceptJsonHeader(client);
                var response = client.PostAsJsonAsync(url, parameter).Result;
                response.EnsureSuccessStatusCode();                
                return response.Content.ReadAsAsync<TResult>().Result;
            }
        }

        protected async Task<TResult> HttpClientPostAsync<TResult>(string controllerActionName, object parameter, RouteValueDictionary routeValues)
        {
            var url = _buildUrl(_routes, controllerActionName, routeValues);

            using (var client = new HttpClient())
            {
                _addAcceptJsonHeader(client);
                var response = await client.PostAsJsonAsync(url, parameter);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<TResult>();
            }
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