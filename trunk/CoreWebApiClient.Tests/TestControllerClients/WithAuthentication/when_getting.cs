using CoreWebApiClient.TestControllers;
using NUnit.Framework;

namespace CoreWebApiClient.Tests.TestControllerClients.WithAuthentication
{
    [TestFixture]
    public class when_getting : TestControllerClientWithAuthenticationSetup
    {
        const int Id = 23;
        const string Name = "name";
        const string Value = "value";
        private AnotherTestDto _dto;

        protected override void Act()
        {
            _dto = ControllerClient.Get(Id, Name, Value);
        }

        [Test]
        public void get()
        {
            Act();

            Assert.That(_dto.Id, Is.EqualTo(Id));
            Assert.That(_dto.Name, Is.EqualTo(Name));
            Assert.That(_dto.Value, Is.EqualTo(Value));
        }
    }
}
