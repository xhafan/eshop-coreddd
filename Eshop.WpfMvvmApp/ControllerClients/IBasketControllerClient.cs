//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Eshop.WpfMvvmApp.ControllerClients {
    
    
    public interface IBasketControllerClient {
        
        void AddProductToBasket(int productId, int quantity);
        
        System.Threading.Tasks.Task AddProductToBasketAsync(int productId, int quantity);
        
        Eshop.Dtos.BasketItemDto[] GetBasketItems();
        
        System.Threading.Tasks.Task<Eshop.Dtos.BasketItemDto[]> GetBasketItemsAsync();
        
        void UpdateProductQuantity(int productId, int quantity);
        
        System.Threading.Tasks.Task UpdateProductQuantityAsync(int productId, int quantity);
    }
}
