using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CoreMvvm;
using Eshop.WpfMvvmApp.Products;

namespace Eshop.WpfMvvmApp
{
    public class IoCInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromThisAssembly()
                       .BasedOn<BaseViewModel>()
                       .Configure(x => x.LifestyleTransient()),
                Component.For<IProductSearchViewModelFactory>().AsFactory(),
                Component.For<IProductSearchResultViewModelFactory>().AsFactory(),
                Component.For<IProductDetailsViewModelFactory>().AsFactory(),
                Component.For<IBasketViewModelFactory>().AsFactory(),
                Component.For<IReviewOrderViewModelFactory>().AsFactory()
                );
        }
    }
}