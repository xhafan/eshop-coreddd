using System.Web.Http;
using CoreWebApi;

namespace CoreWebApiClient.TestControllers
{
    [Authentication(typeof(TestSessionContext))]
    public class TestAuthenticatedController : CoreAuthenticatedController<TestSessionContext>
    {
        public void Login([FromBody]string userName, string password)
        {
            SessionContext = new TestSessionContext { UserId = 23 };
        }

        public AnotherTestDto Get(int id, string name, string value)
        {
            return new AnotherTestDto
                {
                    Id = id,
                    Name = name,
                    Value = value
                };
        }

        public void PostWithoutReturnValue([FromBody]TestDto dto, string value)
        {
        }

        [HttpPost]
        public void PostWithoutReturnValueAndWithoutFromBodyAttribute(TestDto dto, string value)
        {
        }

        [HttpPost]
        public void PostWithoutReturnValueAndWithoutComplexParameterType([FromBody]string value)
        {
        }

        public AnotherTestDto PostWithReturnValue([FromBody]TestDto dto, string value)
        {
            return new AnotherTestDto
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    Value = value
                };
        }

        [HttpGet]
        public void AGetWithoutParameters()
        {
        }

        [HttpGet]
        public int AGetWithoutParametersWithReturnValue()
        {
            return 23;
        }
    }
}