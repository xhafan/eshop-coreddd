using CoreWebApiClient.TestControllers;
using NUnit.Framework;
using Shouldly;

namespace CoreWebApiClient.Tests.TestControllerClients
{
    [TestFixture]
    public class when_posting_without_return_value : BaseTestControllerClientTest
    {
        [Test]
        public void post_without_return_value()
        {
            const int id = 23;
            const string name = "name";
            const string value = "value";

            Should.NotThrow(() => ControllerClient.PostWithoutReturnValue(new TestDto { Id = id, Name = name }, value));
        }
    }
}