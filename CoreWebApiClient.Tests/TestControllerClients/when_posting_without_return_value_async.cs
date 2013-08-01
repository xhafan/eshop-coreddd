using CoreWebApiClient.TestControllers;
using NUnit.Framework;
using Shouldly;

namespace CoreWebApiClient.Tests.TestControllerClients
{
    [TestFixture]
    public class when_posting_without_return_value_async : BaseTestControllerClientTest
    {
        [Test]
        public void post_without_return_value_async()
        {
            const int id = 23;
            const string name = "name";
            const string value = "value";

            Should.NotThrow(() => ControllerClient.PostWithoutReturnValueAsync(new TestDto { Id = id, Name = name }, value));
        }
    }
}