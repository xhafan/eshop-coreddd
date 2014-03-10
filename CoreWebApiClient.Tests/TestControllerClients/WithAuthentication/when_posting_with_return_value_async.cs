using CoreWebApiClient.TestControllers;
using NUnit.Framework;

namespace CoreWebApiClient.Tests.TestControllerClients.WithAuthentication
{
    [TestFixture]
    public class when_posting_with_return_value_async : TestControllerClientWithAuthenticationSetup
    {
        private AnotherTestDto _dto;
        const int Id = 23;
        const string Name = "name";
        const string Value = "value";

        protected override void Act()
        {
            _dto = ControllerClient.PostWithReturnValueAsync(new TestDto { Id = Id, Name = Name }, Value).Result;
        }

        [Test]
        public void return_value_is_correct()
        {
            Act();

            Assert.That(_dto.Id, Is.EqualTo(Id));
            Assert.That(_dto.Name, Is.EqualTo(Name));
            Assert.That(_dto.Value, Is.EqualTo(Value));
        }
    }
}