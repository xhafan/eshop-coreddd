using CoreDdd.Commands;
using CoreDdd.Queries;
using Eshop.WebApi.Controllers;
using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.WebApi.UnitTests.Controllers.OrderControllers
{
    public abstract class OrderControllerSetup
    {
        protected IQueryExecutor QueryExecutor;
        protected ICommandExecutor CommandExecutor;
        protected OrderController Controller;

        [SetUp]
        public virtual void Context()
        {
            QueryExecutor = MockRepository.GenerateStub<IQueryExecutor>();
            CommandExecutor = MockRepository.GenerateStub<ICommandExecutor>();
            Controller = new OrderController(QueryExecutor, CommandExecutor);
        }
    }
}