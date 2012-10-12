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
            UnitOfWorkInitializer.Initialize();
        }
    }
}
