using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CoreDdd.Nhibernate.Configurations;

namespace Eshop.Infrastructure
{
    public class EshopNhibernateInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<INhibernateConfigurator>()
                    .ImplementedBy<EshopNhibernateConfigurator>()
                    .LifeStyle.Singleton
                );
        }
    }
}