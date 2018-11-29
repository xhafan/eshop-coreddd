using CoreDdd.Commands;
using CoreDdd.Queries;
using Eshop.WebApi.Controllers;
using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.WebApi.UnitTests.Controllers.BasketControllers
{
    public abstract class BasketControllerSetup
    {
        protected IQueryExecutor QueryExecutor;
        protected ICommandExecutor CommandExecutor;
        protected BasketController Controller;

        [SetUp]
        public virtual void Context()
        {
            QueryExecutor = MockRepository.GenerateStub<IQueryExecutor>();
            CommandExecutor = MockRepository.GenerateStub<ICommandExecutor>();
            Controller = new BasketController(QueryExecutor, CommandExecutor);
        }
    }
}