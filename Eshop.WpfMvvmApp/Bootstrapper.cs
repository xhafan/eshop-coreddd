using Castle.Facilities.TypedFactory;
using Castle.Windsor;
using Castle.Windsor.Installer;
using CoreIoC;

namespace Eshop.WpfMvvmApp
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            var container = new WindsorContainer();
            container.AddFacility<TypedFactoryFacility>();
            container.Install(
                FromAssembly.Containing<IoCInstaller>()
                );
            IoC.Initialize(container);
        }
    }
}
