using NUnit.Framework;

namespace CoreWebApiClient.Tests.TestControllerClients.WithoutAuthentication
{
    [TestFixture]
    public class when_getting : TestControllerClientWithoutAuthenticationSetup
    {
        [Test]
        public void get()
        {
            const int id = 23;
            const string name = "name";
            const string value = "value";

            var dto = ControllerClient.Get(id, name, value);

            Assert.That(dto.Id, Is.EqualTo(id));
            Assert.That(dto.Name, Is.EqualTo(name));
            Assert.That(dto.Value, Is.EqualTo(value));
        }
    }
}
