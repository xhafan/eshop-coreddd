//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Eshop.WpfMvvmApp.ControllerClients {
    
    
    public class ProductControllerClient : CoreWebApiClient.BaseApiControllerClient, IProductControllerClient {
        
        public ProductControllerClient(string serverUrl, System.Web.Routing.RouteCollection routes) : 
                base(serverUrl, routes) {
        }
        
        public virtual System.Collections.Generic.IEnumerable<Eshop.Dtos.ProductDto> Get(string searchText) {
            System.Web.Routing.RouteValueDictionary routeValues = new System.Web.Routing.RouteValueDictionary();
            routeValues.Add("searchText", searchText);
            return this.HttpClientGet<System.Collections.Generic.IEnumerable<Eshop.Dtos.ProductDto>>("Get", routeValues);
        }
        
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Eshop.Dtos.ProductDto>> GetAsync(string searchText) {
            System.Web.Routing.RouteValueDictionary routeValues = new System.Web.Routing.RouteValueDictionary();
            routeValues.Add("searchText", searchText);
            return this.HttpClientGetAsync<System.Collections.Generic.IEnumerable<Eshop.Dtos.ProductDto>>("Get", routeValues);
        }
    }
}