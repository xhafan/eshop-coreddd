using CoreWebApiClient.TestControllers;
using NUnit.Framework;

namespace CoreWebApiClient.Tests.TestControllerClients.WithoutAuthentication
{
    [TestFixture]
    public class when_posting_with_return_value : TestControllerClientWithoutAuthenticationSetup
    {
        [Test]
        public void return_value_is_correct()
        {
            const int id = 23;
            const string name = "name";
            const string value = "value";

            var dto = ControllerClient.PostWithReturnValue(new TestDto { Id = id, Name = name}, value);

            Assert.That(dto.Id, Is.EqualTo(id));
            Assert.That(dto.Name, Is.EqualTo(name));
            Assert.That(dto.Value, Is.EqualTo(value));
        }
    }
}