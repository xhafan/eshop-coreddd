using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CoreDdd.Nhibernate.Configurations;
using CoreDdd.Nhibernate.UnitOfWorks;
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
        public void SetUp() // todo: use installer?
        {
            var windsorContainer = new WindsorContainer();
            windsorContainer.Register(
                Component.For<INhibernateConfigurator>()
                    .ImplementedBy<EshopNhibernateConfigurator>()
                    .LifeStyle.Singleton,
                Component.For<NhibernateUnitOfWork>()
                    .ImplementedBy<NhibernateUnitOfWork>()
                    .LifeStyle.PerThread
                );
            IoC.Initialize(new CastleContainer(windsorContainer));
        }
    }
}
