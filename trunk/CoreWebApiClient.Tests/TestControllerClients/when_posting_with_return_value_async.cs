using CoreWebApiClient.TestControllers;
using NUnit.Framework;

namespace CoreWebApiClient.Tests.TestControllerClients
{
    [TestFixture]
    public class when_posting_with_return_value_async : BaseTestControllerClientTest
    {
        [Test]
        public async void post_with_return_value_async()
        {
            const int id = 23;
            const string name = "name";
            const string value = "value";

            var dto = await ControllerClient.PostWithReturnValueAsync(new TestDto { Id = id, Name = name}, value);

            Assert.That(dto.Id, Is.EqualTo(id));
            Assert.That(dto.Name, Is.EqualTo(name));
            Assert.That(dto.Value, Is.EqualTo(value));
        }
    }
}