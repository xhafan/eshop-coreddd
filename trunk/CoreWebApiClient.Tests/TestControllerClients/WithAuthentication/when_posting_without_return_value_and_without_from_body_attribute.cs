using CoreWebApiClient.TestControllers;
using CoreWebApiClient.Tests.TestControllerClients.WithoutAuthentication;
using NUnit.Framework;

namespace CoreWebApiClient.Tests.TestControllerClients.WithAuthentication
{
    [TestFixture]
    public class when_posting_without_return_value_and_without_from_body_attribute : TestControllerClientWithAuthenticationSetup
    {
        const int Id = 23;
        const string Name = "name";
        const string Value = "value";

        protected override void Act()
        {
            ControllerClient.PostWithoutReturnValueAndWithoutFromBodyAttribute(new TestDto { Id = Id, Name = Name }, Value);
        }

        [Test]
        public void post_without_return_value_and_without_from_body_attribute()
        {
            Act();
        }
    }
}