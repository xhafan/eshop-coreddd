using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CoreMvvm;

namespace Eshop.WpfMvvmApp
{
    public class ViewModelInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromThisAssembly()
                       .BasedOn<NotifyingObject>()                    
                       .Configure(x => x.LifestyleTransient()));
        }
    }
}