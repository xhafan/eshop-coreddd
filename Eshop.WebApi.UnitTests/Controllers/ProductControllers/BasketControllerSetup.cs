using CoreDdd.Queries;
using Eshop.WebApi.Controllers;
using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.WebApi.UnitTests.Controllers.ProductControllers
{
    public abstract class ProductControllerSetup
    {
        protected IQueryExecutor QueryExecutor;
        protected ProductController Controller;

        [SetUp]
        public virtual void Context()
        {
            QueryExecutor = MockRepository.GenerateStub<IQueryExecutor>();
            Controller = new ProductController(QueryExecutor);
        }
    }
}