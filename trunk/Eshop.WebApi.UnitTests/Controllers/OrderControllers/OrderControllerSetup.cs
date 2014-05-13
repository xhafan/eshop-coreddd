using CoreDdd.Commands;
using CoreDdd.Queries;
using CoreTest;
using Eshop.WebApi.Controllers;
using NUnit.Framework;

namespace Eshop.WebApi.UnitTests.Controllers.OrderControllers
{
    public abstract class OrderControllerSetup : BaseTest
    {
        protected IQueryExecutor QueryExecutor;
        protected ICommandExecutor CommandExecutor;
        protected OrderController Controller;

        [SetUp]
        public virtual void Context()
        {
            QueryExecutor = Stub<IQueryExecutor>();
            CommandExecutor = Stub<ICommandExecutor>();
            Controller = new OrderController(QueryExecutor, CommandExecutor);
        }
    }
}