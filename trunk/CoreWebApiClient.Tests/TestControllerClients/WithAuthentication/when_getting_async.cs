using CoreWebApiClient.TestControllers;
using NUnit.Framework;

namespace CoreWebApiClient.Tests.TestControllerClients.WithAuthentication
{
    [TestFixture]
    public class when_getting_async : TestControllerClientWithAuthenticationSetup
    {
        private AnotherTestDto _dto;
        const int Id = 23;
        const string Name = "name";
        const string Value = "value";

        protected override void Act()
        {
            _dto = ControllerClient.GetAsync(Id, Name, Value).Result;
        }

        [Test]
        public void get_async()
        {
            Act();

            Assert.That(_dto.Id, Is.EqualTo(Id));
            Assert.That(_dto.Name, Is.EqualTo(Name));
            Assert.That(_dto.Value, Is.EqualTo(Value));
        }
    }
}