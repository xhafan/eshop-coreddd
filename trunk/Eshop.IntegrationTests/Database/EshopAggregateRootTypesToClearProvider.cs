using System;
using System.Collections.Generic;
using CoreTest;
using Eshop.Domain;

namespace Eshop.IntegrationTests.Database
{
    public class EshopAggregateRootTypesToClearProvider : IAggregateRootTypesToClearProvider
    {
        public IEnumerable<Type> GetAggregateRootTypesToClear()
        {
            yield return typeof(Order);
            yield return typeof(Customer);
            yield return typeof(Product);
        }
    }
}
