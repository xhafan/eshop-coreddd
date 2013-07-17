using Castle.Windsor;
using Castle.Windsor.Installer;
using CoreDdd.Infrastructure;

namespace Eshop.WpfMvvmApp
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            CoreWebApiClient.Bootstrapper.Run();

            var container = new WindsorContainer();
            container.Install(
                FromAssembly.Containing<ViewModelInstaller>()
                );
            IoC.Initialize(container);
        }
    }
}
