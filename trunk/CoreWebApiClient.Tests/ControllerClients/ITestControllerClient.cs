//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoreWebApiClient.Tests.ControllerClients {
    
    
    public interface ITestControllerClient {
        
        CoreWebApiClient.TestControllers.AnotherTestDto Get(int id, string name, string value);
        
        System.Threading.Tasks.Task<CoreWebApiClient.TestControllers.AnotherTestDto> GetAsync(int id, string name, string value);
        
        void PostWithoutReturnValue(CoreWebApiClient.TestControllers.TestDto dto, string value);
        
        System.Threading.Tasks.Task PostWithoutReturnValueAsync(CoreWebApiClient.TestControllers.TestDto dto, string value);
        
        CoreWebApiClient.TestControllers.AnotherTestDto PostWithReturnValue(CoreWebApiClient.TestControllers.TestDto dto, string value);
        
        System.Threading.Tasks.Task<CoreWebApiClient.TestControllers.AnotherTestDto> PostWithReturnValueAsync(CoreWebApiClient.TestControllers.TestDto dto, string value);
    }
}
