using CoreDdd.Commands;
using CoreDdd.Queries;
using CoreTest;
using Eshop.WebApi2.Controllers;
using NUnit.Framework;

namespace Eshop.WebApi.UnitTests.Controllers.BasketControllers
{
    public abstract class BasketControllerSetup : BaseTest
    {
        protected IQueryExecutor QueryExecutor;
        protected ICommandExecutor CommandExecutor;
        protected BasketController BasketController;

        [SetUp]
        public virtual void Context()
        {
            QueryExecutor = Stub<IQueryExecutor>();
            CommandExecutor = Stub<ICommandExecutor>();
            BasketController = new BasketController(QueryExecutor, CommandExecutor);
        }
    }
}