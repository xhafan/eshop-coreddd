//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Eshop.WpfMvvmApp.ControllerClients {
    
    
    public class DeliveryAddressControllerClient : CoreWebApiClient.BaseApiControllerClient, IDeliveryAddressControllerClient {
        
        public DeliveryAddressControllerClient(string serverUrl, System.Web.Routing.RouteCollection routes) : 
                base(serverUrl, routes) {
        }
        
        public DeliveryAddressControllerClient(string serverUrl, System.Web.Routing.RouteCollection routes, CoreWebApiClient.IAuthenticationCookiePersister authenticationCookiePersister) : 
                base(serverUrl, routes, authenticationCookiePersister) {
        }
        
        public virtual void SetDeliveryAddress(string deliveryAddress) {
            System.Web.Routing.RouteValueDictionary routeValues = new System.Web.Routing.RouteValueDictionary();
            this.HttpClientPost("SetDeliveryAddress", deliveryAddress, routeValues);
        }
        
        public virtual System.Threading.Tasks.Task SetDeliveryAddressAsync(string deliveryAddress) {
            System.Web.Routing.RouteValueDictionary routeValues = new System.Web.Routing.RouteValueDictionary();
            return this.HttpClientPostAsync("SetDeliveryAddress", deliveryAddress, routeValues);
        }
        
        public virtual string GetDeliveryAddress() {
            System.Web.Routing.RouteValueDictionary routeValues = new System.Web.Routing.RouteValueDictionary();
            return this.HttpClientGet<string>("GetDeliveryAddress", routeValues);
        }
        
        public virtual System.Threading.Tasks.Task<string> GetDeliveryAddressAsync() {
            System.Web.Routing.RouteValueDictionary routeValues = new System.Web.Routing.RouteValueDictionary();
            return this.HttpClientGetAsync<string>("GetDeliveryAddress", routeValues);
        }
    }
}
