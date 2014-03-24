using CoreDdd.Queries;
using CoreTest;
using Eshop.WebApi.Controllers;
using NUnit.Framework;

namespace Eshop.WebApi.UnitTests.Controllers.ProductControllers
{
    public abstract class ProductControllerSetup : BaseTest
    {
        protected IQueryExecutor QueryExecutor;
        protected ProductController Controller;

        [SetUp]
        public virtual void Context()
        {
            QueryExecutor = Stub<IQueryExecutor>();
            Controller = new ProductController(QueryExecutor);
        }
    }
}