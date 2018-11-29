using CoreDdd.Commands;
using CoreDdd.Queries;
using Eshop.WebApi.Controllers;
using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.WebApi.UnitTests.Controllers.DeliveryAddressControllers
{
    public abstract class DeliveryAddressControllerSetup
    {
        protected IQueryExecutor QueryExecutor;
        protected ICommandExecutor CommandExecutor;
        protected DeliveryAddressController Controller;

        [SetUp]
        public virtual void Context()
        {
            QueryExecutor = MockRepository.GenerateStub<IQueryExecutor>();
            CommandExecutor = MockRepository.GenerateStub<ICommandExecutor>();
            Controller = new DeliveryAddressController(QueryExecutor, CommandExecutor);
        }
    }
}