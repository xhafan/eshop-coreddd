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
            container.Install(
                FromAssembly.Containing<ViewModelInstaller>()
                );
            IoC.Initialize(container);
        }
    }
}
