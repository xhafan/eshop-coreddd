using NUnit.Framework;

namespace CoreWebApiClient.Tests.TestControllerClients
{
    [TestFixture]
    public class when_posting_without_return_value_and_without_complex_parameter_type : BaseTestControllerClientTest
    {
        [Test]
        public void post_without_return_value_and_without_complex_parameter_type()
        {
            const string value = "value";

            ControllerClient.PostWithoutReturnValueAndWithoutComplexParameterType(value);
        }
    }
}