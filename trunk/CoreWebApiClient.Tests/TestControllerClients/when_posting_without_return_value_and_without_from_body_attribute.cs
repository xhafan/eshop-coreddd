using CoreWebApiClient.TestControllers;
using NUnit.Framework;

namespace CoreWebApiClient.Tests.TestControllerClients
{
    [TestFixture]
    public class when_posting_without_return_value_and_without_from_body_attribute : BaseTestControllerClientTest
    {
        [Test]
        public void post_without_return_value_and_without_from_body_attribute()
        {
            const int id = 23;
            const string name = "name";
            const string value = "value";

            ControllerClient.PostWithoutReturnValueAndWithoutFromBodyAttribute(new TestDto { Id = id, Name = name }, value);
        }
    }
}