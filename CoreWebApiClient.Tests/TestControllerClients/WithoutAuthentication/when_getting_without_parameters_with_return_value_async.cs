using NUnit.Framework;
using Shouldly;

namespace CoreWebApiClient.Tests.TestControllerClients.WithoutAuthentication
{
    [TestFixture]
    public class when_getting_without_parameters_with_return_value_async : TestControllerClientWithoutAuthenticationSetup
    {
        [Test]
        public async void return_value_is_correct()
        {
            var value = await ControllerClient.AGetWithoutParametersWithReturnValueAsync();

            value.ShouldBe(23);
        }
    }
}