using CoreIntegrationTest.Nhibernate;
using CoreTest;

namespace Eshop.IntegrationTests.Database
{
    public abstract class BaseEshopSimplePersistenceTest : BaseNhibernateSimplePersistenceTest
    {
        protected override IAggregateRootTypesToClearProvider GetAggregateRootTypesToClearProvider()
        {
            return new EshopAggregateRootTypesToClearProvider();
        }
    }
}