using System.Configuration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CoreWebApiClient;

namespace Eshop.WpfMvvmApp.ControllerClients
{
    public class ControllerClientInstaller : IWindsorInstaller // todo: implement automatic registration
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var dependenciesAsAnonymousType = new
                {
                    serverUrl = ConfigurationManager.AppSettings["serverUrl"], 
                    routes = RoutesProvider.GetDefaultRoutes()
                };
            container.Register(
                
                Component.For<IProductControllerClient>()
                         .ImplementedBy<ProductControllerClient>()
                         .DependsOn(dependenciesAsAnonymousType)
                         .LifeStyle.Transient,

                Component.For<IBasketControllerClient>()
                         .ImplementedBy<BasketControllerClient>()
                         .DependsOn(dependenciesAsAnonymousType)
                         .LifeStyle.Transient,

                Component.For<IDeliveryAddressControllerClient>()
                         .ImplementedBy<DeliveryAddressControllerClient>()
                         .DependsOn(dependenciesAsAnonymousType)
                         .LifeStyle.Transient,

                Component.For<IOrderControllerClient>()
                         .ImplementedBy<OrderControllerClient>()
                         .DependsOn(dependenciesAsAnonymousType)
                         .LifeStyle.Transient,

                Component.For<IAuthenticationCookiePersister>()
                         .ImplementedBy<AuthenticationCookiePersister>()
                         .LifeStyle.Singleton
                );
        }
    }
}