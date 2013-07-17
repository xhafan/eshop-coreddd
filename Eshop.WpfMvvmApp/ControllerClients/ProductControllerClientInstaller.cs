using System.Configuration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Eshop.WpfMvvmApp.ControllerClients
{
    public class ProductControllerClientInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IProductControllerClient>()
                         .ImplementedBy<ProductControllerClient>()
                         .DependsOn(new
                             {
                                 serverUrl = ConfigurationManager.AppSettings["serverUrl"],
                                 routes = CoreWebApiClient.Bootstrapper.Routes // todo: is this the best initialisation?
                             })
                         .LifeStyle.Singleton);
        }
    }
}