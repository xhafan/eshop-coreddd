using CoreDdd.Commands;
using Eshop.Commands;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace Eshop.WebApi.UnitTests.Controllers.BasketControllers
{
    [TestFixture]
    public class when_adding_product_to_basket_without_session_context : BasketControllerSetup
    {
        private const int ProductId = 23;
        private const int Quantity = 34;
        private const int GeneratedCustomerId = 45;

        [SetUp]
        public override void Context()
        {
            base.Context();

            Controller.AddProductToBasket(ProductId, Quantity);
        }

        [Test]
        public void command_is_executed()
        {
            CommandExecutor.AssertWasCalled(x => x.Execute(Arg<AddProductToBasketCommand>.Matches(p => MatchingCommand(p))));
        }

        [Test]
        public void command_executed_event_handler_sets_session_context()
        {
            CommandExecutor.Raise(x => x.CommandExecuted += null, new CommandExecutedArgs { Args = GeneratedCustomerId });
            
            Controller.SessionContext.ShouldNotBe(null);
            Controller.SessionContext.CustomerId.ShouldBe(GeneratedCustomerId);
        }

        private bool MatchingCommand(AddProductToBasketCommand command)
        {
            command.CustomerId.ShouldBe(default(int));
            command.ProductId.ShouldBe(ProductId);
            command.Quantity.ShouldBe(Quantity);
            return true;
        }
    }
}