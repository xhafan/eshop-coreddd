using CoreDdd.Commands;
using CoreDdd.Queries;
using CoreTest;
using Eshop.WebApi.Controllers;
using NUnit.Framework;

namespace Eshop.WebApi.UnitTests.Controllers.BasketControllers
{
    public abstract class BasketControllerSetup : BaseTest
    {
        protected IQueryExecutor QueryExecutor;
        protected ICommandExecutor CommandExecutor;
        protected BasketController Controller;

        [SetUp]
        public virtual void Context()
        {
            QueryExecutor = Stub<IQueryExecutor>();
            CommandExecutor = Stub<ICommandExecutor>();
            Controller = new BasketController(QueryExecutor, CommandExecutor);
        }
    }
}