using Eshop.Commands;
using Eshop.WebApi.Controllers;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace Eshop.WebApi.UnitTests.Controllers.BasketControllers
{
    [TestFixture]
    public class when_adding_product_to_basket_with_session_context : BasketControllerSetup
    {
        private const int ProductId = 23;
        private const int Quantity = 34;
        private const int CustomerId = 45;

        [SetUp]
        public override void Context()
        {
            base.Context();
            Controller.SessionContext = new SessionContext { CustomerId = CustomerId };

            Controller.AddProductToBasket(ProductId, Quantity);
        }

        [Test]
        public void command_is_executed()
        {
            CommandExecutor.AssertWasCalled(x => x.Execute(Arg<AddProductToBasketCommand>.Matches(p => MatchingCommand(p))));
        }

        private bool MatchingCommand(AddProductToBasketCommand command)
        {
            command.CustomerId.ShouldBe(CustomerId);
            command.ProductId.ShouldBe(ProductId);
            command.Quantity.ShouldBe(Quantity);
            return true;
        }
    }
}