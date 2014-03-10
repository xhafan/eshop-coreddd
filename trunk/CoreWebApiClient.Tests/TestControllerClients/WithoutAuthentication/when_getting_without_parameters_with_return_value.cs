using NUnit.Framework;
using Shouldly;

namespace CoreWebApiClient.Tests.TestControllerClients.WithoutAuthentication
{
    [TestFixture]
    public class when_getting_without_parameters_with_return_value : TestControllerClientWithoutAuthenticationSetup
    {
        [Test]
        public void return_value_is_correct()
        {
            var value = ControllerClient.AGetWithoutParametersWithReturnValue();

            value.ShouldBe(23);
        }
    }
}