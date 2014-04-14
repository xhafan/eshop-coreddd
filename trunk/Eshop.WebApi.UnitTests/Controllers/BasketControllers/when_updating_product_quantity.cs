using Eshop.Commands;
using Eshop.WebApi.Controllers;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace Eshop.WebApi.UnitTests.Controllers.BasketControllers
{
    [TestFixture]
    public class when_updating_product_quantity : BasketControllerSetup
    {
        private const int ProductId = 23;
        private const int Quantity = 34;
        private const int CustomerId = 45;

        [SetUp]
        public override void Context()
        {
            base.Context();
            Controller.SessionContext = new SessionContext { CustomerId = CustomerId };

            Controller.UpdateProductQuantity(ProductId, Quantity);
        }

        [Test]
        public void command_is_executed()
        {
            CommandExecutor.AssertWasCalled(x => x.Execute(Arg<UpdateProductQuantityInBasketCommand>.Matches(p => MatchingCommand(p))));
        }

        private bool MatchingCommand(UpdateProductQuantityInBasketCommand command)
        {
            command.CustomerId.ShouldBe(CustomerId);
            command.ProductId.ShouldBe(ProductId);
            command.Quantity.ShouldBe(Quantity);
            return true;
        }
    }
}