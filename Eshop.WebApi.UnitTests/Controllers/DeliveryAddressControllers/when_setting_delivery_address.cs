using Eshop.Commands;
using Eshop.WebApi.Controllers;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace Eshop.WebApi.UnitTests.Controllers.DeliveryAddressControllers
{
    [TestFixture]
    public class when_setting_delivery_address : DeliveryAddressControllerSetup
    {
        private const int CustomerId = 45;

        [SetUp]
        public override void Context()
        {
            base.Context();
            Controller.SessionContext = new SessionContext { CustomerId = CustomerId };

            Controller.SetDeliveryAddress("delivery address");
        }

        [Test]
        public void command_is_executed()
        {
            CommandExecutor.AssertWasCalled(x => x.Execute(Arg<SetDeliveryAddressCommand>.Matches(p => MatchingCommand(p))));
        }

        private bool MatchingCommand(SetDeliveryAddressCommand command)
        {
            command.CustomerId.ShouldBe(CustomerId);
            command.Address.ShouldBe("delivery address");
            return true;
        }
    }
}