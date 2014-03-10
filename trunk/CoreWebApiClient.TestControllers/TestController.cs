using System.Web.Http;

namespace CoreWebApiClient.TestControllers
{
    public class TestController : ApiController
    {
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
