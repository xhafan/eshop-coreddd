using CoreWebApiClient.TestControllers;
using NUnit.Framework;

namespace CoreWebApiClient.Tests.TestControllerClients
{
    [TestFixture]
    public class when_posting_without_return_value_async : BaseTestControllerClientTest
    {
        [Test]
        public async void post_without_return_value_async()
        {
            const int id = 23;
            const string name = "name";
            const string value = "value";

            await ControllerClient.PostWithoutReturnValueAsync(new TestDto {Id = id, Name = name}, value);
        }
    }
}