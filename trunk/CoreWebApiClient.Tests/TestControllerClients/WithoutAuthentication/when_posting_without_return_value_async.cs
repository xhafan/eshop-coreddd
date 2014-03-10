using CoreWebApiClient.TestControllers;
using NUnit.Framework;

namespace CoreWebApiClient.Tests.TestControllerClients.WithoutAuthentication
{
    [TestFixture]
    public class when_posting_without_return_value_async : TestControllerClientWithoutAuthenticationSetup
    {
        [Test]
        public async void does_not_throw()
        {
            const int id = 23;
            const string name = "name";
            const string value = "value";

            await ControllerClient.PostWithoutReturnValueAsync(new TestDto {Id = id, Name = name}, value);
        }
    }
}