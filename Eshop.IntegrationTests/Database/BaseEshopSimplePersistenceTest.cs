using CoreTest;

namespace Eshop.IntegrationTests.Database
{
    public abstract class BaseEshopSimplePersistenceTest : BaseSimplePersistenceTest
    {
        protected override IAggregateRootTypesToClearProvider GetAggregateRootTypesToClearProvider()
        {
            return new EshopAggregateRootTypesToClearProvider();
        }
    }
}