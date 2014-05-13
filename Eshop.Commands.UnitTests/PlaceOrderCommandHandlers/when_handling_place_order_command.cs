using CoreDdd.Domain.Repositories;
using CoreTest;
using Eshop.Domain;
using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.Commands.UnitTests.PlaceOrderCommandHandlers
{
    [TestFixture]
    public class when_handling_place_order_command : BaseTest
    {
        private Customer _customer;
        private IRepository<Order> _orderRepository;
        private Order _order;

        [SetUp]
        public void Context()
        {
            const int customerId = 45;
            _customer = Mock<Customer>();
            
            var customerRepository = Stub<IRepository<Customer>>().Stubs(x => x.GetById(customerId)).Returns(_customer);
            _orderRepository = Mock<IRepository<Order>>();

            _order = Stub<Order>();
            _customer.Stubs(x => x.PlaceOrder()).Returns(_order);

            var handler = new PlaceOrderCommandHandler(customerRepository, _orderRepository);

            handler.Execute(new PlaceOrderCommand
                                {
                                    CustomerId = customerId,
                                });
        }

        [Test]
        public void new_order_is_saved()
        {
            _orderRepository.AssertWasCalled(x => x.Save(_order));
        }
    }
}