using NUnit.Framework;

namespace CoreWebApiClient.Tests.TestControllerClients
{
    [TestFixture]
    public class when_getting_async : BaseTestControllerClientTest
    {
        [Test]
        public async void get_async()
        {
            const int id = 23;
            const string name = "name";
            const string value = "value";

            var dto = await ControllerClient.GetAsync(id, name, value);

            Assert.That(dto.Id, Is.EqualTo(id));
            Assert.That(dto.Name, Is.EqualTo(name));
            Assert.That(dto.Value, Is.EqualTo(value));
        }
    }
}