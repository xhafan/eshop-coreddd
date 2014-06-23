//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoreWebApiClient.Tests.ControllerClients {
    
    
    public class TestControllerClient : CoreWebApiClient.BaseApiControllerClient, ITestControllerClient {
        
        public TestControllerClient(string serverUrl, System.Web.Routing.RouteCollection routes) : 
                base(serverUrl, routes) {
        }
        
        public TestControllerClient(string serverUrl, System.Web.Routing.RouteCollection routes, CoreWebApiClient.IAuthenticationCookiePersister authenticationCookiePersister) : 
                base(serverUrl, routes, authenticationCookiePersister) {
        }
        
        public virtual CoreWebApiClient.TestControllers.AnotherTestDto Get(int id, string name, string value) {
            System.Web.Routing.RouteValueDictionary routeValues = new System.Web.Routing.RouteValueDictionary();
            routeValues.Add("id", id);
            routeValues.Add("name", name);
            routeValues.Add("value", value);
            return this.HttpClientGet<CoreWebApiClient.TestControllers.AnotherTestDto>("Get", routeValues);
        }
        
        public virtual System.Threading.Tasks.Task<CoreWebApiClient.TestControllers.AnotherTestDto> GetAsync(int id, string name, string value) {
            System.Web.Routing.RouteValueDictionary routeValues = new System.Web.Routing.RouteValueDictionary();
            routeValues.Add("id", id);
            routeValues.Add("name", name);
            routeValues.Add("value", value);
            return this.HttpClientGetAsync<CoreWebApiClient.TestControllers.AnotherTestDto>("Get", routeValues);
        }
        
        public virtual void PostWithoutReturnValue(CoreWebApiClient.TestControllers.TestDto dto, string value) {
            System.Web.Routing.RouteValueDictionary routeValues = new System.Web.Routing.RouteValueDictionary();
            routeValues.Add("value", value);
            this.HttpClientPost("PostWithoutReturnValue", dto, routeValues);
        }
        
        public virtual System.Threading.Tasks.Task PostWithoutReturnValueAsync(CoreWebApiClient.TestControllers.TestDto dto, string value) {
            System.Web.Routing.RouteValueDictionary routeValues = new System.Web.Routing.RouteValueDictionary();
            routeValues.Add("value", value);
            return this.HttpClientPostAsync("PostWithoutReturnValue", dto, routeValues);
        }
        
        public virtual void PostWithoutReturnValueAndWithoutFromBodyAttribute(CoreWebApiClient.TestControllers.TestDto dto, string value) {
            System.Web.Routing.RouteValueDictionary routeValues = new System.Web.Routing.RouteValueDictionary();
            routeValues.Add("value", value);
            this.HttpClientPost("PostWithoutReturnValueAndWithoutFromBodyAttribute", dto, routeValues);
        }
        
        public virtual System.Threading.Tasks.Task PostWithoutReturnValueAndWithoutFromBodyAttributeAsync(CoreWebApiClient.TestControllers.TestDto dto, string value) {
            System.Web.Routing.RouteValueDictionary routeValues = new System.Web.Routing.RouteValueDictionary();
            routeValues.Add("value", value);
            return this.HttpClientPostAsync("PostWithoutReturnValueAndWithoutFromBodyAttribute", dto, routeValues);
        }
        
        public virtual void PostWithoutReturnValueAndWithoutComplexParameterType(string value) {
            System.Web.Routing.RouteValueDictionary routeValues = new System.Web.Routing.RouteValueDictionary();
            this.HttpClientPost("PostWithoutReturnValueAndWithoutComplexParameterType", value, routeValues);
        }
        
        public virtual System.Threading.Tasks.Task PostWithoutReturnValueAndWithoutComplexParameterTypeAsync(string value) {
            System.Web.Routing.RouteValueDictionary routeValues = new System.Web.Routing.RouteValueDictionary();
            return this.HttpClientPostAsync("PostWithoutReturnValueAndWithoutComplexParameterType", value, routeValues);
        }
        
        public virtual CoreWebApiClient.TestControllers.AnotherTestDto PostWithReturnValue(CoreWebApiClient.TestControllers.TestDto dto, string value) {
            System.Web.Routing.RouteValueDictionary routeValues = new System.Web.Routing.RouteValueDictionary();
            routeValues.Add("value", value);
            return this.HttpClientPost<CoreWebApiClient.TestControllers.AnotherTestDto>("PostWithReturnValue", dto, routeValues);
        }
        
        public virtual System.Threading.Tasks.Task<CoreWebApiClient.TestControllers.AnotherTestDto> PostWithReturnValueAsync(CoreWebApiClient.TestControllers.TestDto dto, string value) {
            System.Web.Routing.RouteValueDictionary routeValues = new System.Web.Routing.RouteValueDictionary();
            routeValues.Add("value", value);
            return this.HttpClientPostAsync<CoreWebApiClient.TestControllers.AnotherTestDto>("PostWithReturnValue", dto, routeValues);
        }
        
        public virtual void AGetWithoutParameters() {
            System.Web.Routing.RouteValueDictionary routeValues = new System.Web.Routing.RouteValueDictionary();
            this.HttpClientGetNoReturnValue("AGetWithoutParameters", routeValues);
        }
        
        public virtual System.Threading.Tasks.Task AGetWithoutParametersAsync() {
            System.Web.Routing.RouteValueDictionary routeValues = new System.Web.Routing.RouteValueDictionary();
            return this.HttpClientGetNoReturnValueAsync("AGetWithoutParameters", routeValues);
        }
        
        public virtual int AGetWithoutParametersWithReturnValue() {
            System.Web.Routing.RouteValueDictionary routeValues = new System.Web.Routing.RouteValueDictionary();
            return this.HttpClientGet<int>("AGetWithoutParametersWithReturnValue", routeValues);
        }
        
        public virtual System.Threading.Tasks.Task<int> AGetWithoutParametersWithReturnValueAsync() {
            System.Web.Routing.RouteValueDictionary routeValues = new System.Web.Routing.RouteValueDictionary();
            return this.HttpClientGetAsync<int>("AGetWithoutParametersWithReturnValue", routeValues);
        }
    }
}
