using CoreDdd.Commands;
using CoreDdd.Domain.Repositories;
using Eshop.Domain;

namespace Eshop.Commands
{
    public class PlaceOrderCommandHandler : BaseCommandHandler<PlaceOrderCommand>
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Order> _orderRepository;

        public PlaceOrderCommandHandler(IRepository<Customer> customerRepository, IRepository<Order> orderRepository)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
        }

        public override void Execute(PlaceOrderCommand command)
        {
            var customer = _customerRepository.Get(command.CustomerId);

            var newOrder = customer.PlaceOrder();

            _orderRepository.Save(newOrder);
        }
    }
}