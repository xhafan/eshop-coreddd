using Eshop.Commands;
using Eshop.WebApi.Controllers;
using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.WebApi.UnitTests.Controllers.OrderControllers
{
    [TestFixture]
    public class when_placing_order : OrderControllerSetup
    {
        private const int CustomerId = 45;

        [SetUp]
        public override void Context()
        {
            base.Context();
            Controller.SessionContext = new SessionContext { CustomerId = CustomerId };

            Controller.PlaceOrder(null);
        }

        [Test]
        public void place_order_command_is_executed()
        {
            CommandExecutor.AssertWasCalled(x => x.Execute(Arg<PlaceOrderCommand>.Matches(p => MatchingPlaceOrderCommand(p))));
        }

        private bool MatchingPlaceOrderCommand(PlaceOrderCommand command)
        {
            Assert.That(command.CustomerId, Is.EqualTo(CustomerId));
            return true;
        }
    }
}