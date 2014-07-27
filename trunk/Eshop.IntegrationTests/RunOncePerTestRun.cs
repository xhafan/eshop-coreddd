using Castle.Windsor;
using Castle.Windsor.Installer;
using CoreDdd.Nhibernate.Register.Castle;
using CoreIoC;
using CoreIoC.Castle;
using Eshop.Infrastructure;
using NUnit.Framework;

namespace Eshop.IntegrationTests
{
    [SetUpFixture]
    public class RunOncePerTestRun
    {
        [SetUp]
        public void SetUp()
        {
            NhibernateInstaller.SetUnitOfWorkLifeStyle(x => x.PerThread);
            var container = new WindsorContainer();
            container.Install(
                FromAssembly.Containing<EshopNhibernateInstaller>(),
                FromAssembly.Containing<NhibernateInstaller>()
                );
            IoC.Initialize(new CastleContainer(container));
        }
    }
}
