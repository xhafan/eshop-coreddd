using Castle.Facilities.TypedFactory;
using Castle.Windsor;
using Castle.Windsor.Installer;
using CoreIoC;
using CoreIoC.Castle;

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
            IoC.Initialize(new CastleContainer(container));
        }
    }
}
