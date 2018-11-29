using CoreDdd.Domain.Repositories;
using Eshop.Domain;
using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.Commands.UnitTests.PlaceOrderCommandHandlers
{
    [TestFixture]
    public class when_handling_place_order_command
    {
        private Customer _customer;
        private IRepository<Order> _orderRepository;
        private Order _order;

        [SetUp]
        public void Context()
        {
            const int customerId = 45;
            _customer = MockRepository.GenerateMock<Customer>();

            var customerRepository = MockRepository.GenerateStub<IRepository<Customer>>();
            customerRepository.Stub(x => x.Get(customerId)).Return(_customer);
            _orderRepository = MockRepository.GenerateMock<IRepository<Order>>();

            _order = MockRepository.GenerateStub<Order>();
            _customer.Stub(x => x.PlaceOrder()).Return(_order);

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