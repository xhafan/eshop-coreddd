using CoreDdd.Nhibernate.UnitOfWorks;
using Eshop.Infrastructure;
using NUnit.Framework;

namespace Eshop.IntegrationTests
{
    public abstract class BasePersistenceTest
    {
        protected NhibernateUnitOfWork UnitOfWork;

        protected BasePersistenceTest()
        {
            UnitOfWork = new NhibernateUnitOfWork(new EshopNhibernateConfigurator());
        }

        [SetUp]
        public void TestFixtureSetUp()
        {
            UnitOfWork.BeginTransaction();
        }

        [TearDown]
        public void TestFixtureTearDown()
        {
            UnitOfWork.Rollback();
        }
    }
}