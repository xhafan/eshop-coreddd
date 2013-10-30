using CoreDdd.Domain.Repositories;
using CoreTest;
using Eshop.Domain;
using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.Commands.UnitTests
{
    [TestFixture]
    public class when_handling_place_order_command : BaseTest
    {
        private Customer _customer;

        [SetUp]
        public void Context()
        {
            const int customerId = 45;
            _customer = Mock<Customer>();
            var customerRepository = Stub<IRepository<Customer>>().Stubs(x => x.GetById(customerId)).Returns(_customer);
            var handler = new PlaceOrderCommandHandler(customerRepository);

            handler.Execute(new PlaceOrderCommand
                                {
                                    CustomerId = customerId,
                                });
        }

        [Test]
        public void place_order_is_called_on_customer()
        {
            _customer.AssertWasCalled(x => x.PlaceOrder());
        }
    }
}