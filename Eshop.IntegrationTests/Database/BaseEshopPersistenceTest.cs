using CoreTest;

namespace Eshop.IntegrationTests.Database
{
    public abstract class BaseEshopPersistenceTest : BasePersistenceTest
    {
        protected override IAggregateRootTypesToClearProvider GetAggregateRootTypesToClearProvider()
        {
            return new EshopAggregateRootTypesToClearProvider();
        }
    }
}
