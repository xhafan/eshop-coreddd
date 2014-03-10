using CoreWebApiClient.TestControllers;
using NUnit.Framework;

namespace CoreWebApiClient.Tests.TestControllerClients.WithoutAuthentication
{
    [TestFixture]
    public class when_posting_without_return_value : TestControllerClientWithoutAuthenticationSetup
    {
        [Test]
        public void does_not_throw()
        {
            const int id = 23;
            const string name = "name";
            const string value = "value";

            ControllerClient.PostWithoutReturnValue(new TestDto {Id = id, Name = name}, value);
        }
    }
}