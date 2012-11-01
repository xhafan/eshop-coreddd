using CoreDdd.Commands;
using CoreDdd.Domain.Repositories;
using Eshop.Domain;

namespace Eshop.Commands
{
    public class PlaceOrderCommandHandler : BaseCommandHandler<PlaceOrderCommand>
    {
        private readonly IRepository<Customer> _customerRepository;

        public PlaceOrderCommandHandler(IRepository<Customer> customerRepository)            
        {
            _customerRepository = customerRepository;
        }

        public override void Execute(PlaceOrderCommand command)
        {
            var customer = _customerRepository.GetById(command.CustomerId);

            customer.PlaceOrder();
        }
    }
}