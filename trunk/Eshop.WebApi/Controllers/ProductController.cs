using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using Eshop.Dtos;

namespace Eshop.WebApi.Controllers
{
    public class ProductController : ApiController
    {
        public IEnumerable<string> Get()
        {
            Thread.Sleep(2000);
            return new string[] { "value1", "value2" };
        }

        public string Get(int id)
        {
            return "value";
        }

        public string Get(int id, bool flag)
        {
            return string.Format("id:{0} flag:{1}", id, flag);
        }

        public void Post1([FromBody]string value)
        {
        }

        public void Post2(ProductDto product)
        {
        }

        public ProductDto Post4([FromBody]ProductDto product, string value)
        {
            return new ProductDto
                {
                    Id = product.Id + 1,
                    Name = product.Name + "X"
                };
        }        
    }
}