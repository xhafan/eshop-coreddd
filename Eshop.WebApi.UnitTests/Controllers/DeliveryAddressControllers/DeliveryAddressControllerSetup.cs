using CoreDdd.Commands;
using CoreDdd.Queries;
using CoreTest;
using Eshop.WebApi.Controllers;
using NUnit.Framework;

namespace Eshop.WebApi.UnitTests.Controllers.DeliveryAddressControllers
{
    public abstract class DeliveryAddressControllerSetup : BaseTest
    {
        protected IQueryExecutor QueryExecutor;
        protected ICommandExecutor CommandExecutor;
        protected DeliveryAddressController Controller;

        [SetUp]
        public virtual void Context()
        {
            QueryExecutor = Stub<IQueryExecutor>();
            CommandExecutor = Stub<ICommandExecutor>();
            Controller = new DeliveryAddressController(QueryExecutor, CommandExecutor);
        }
    }
}