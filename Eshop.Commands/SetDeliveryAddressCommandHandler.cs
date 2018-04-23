using CoreDdd.Commands;
using CoreDdd.Domain.Repositories;
using Eshop.Domain;

namespace Eshop.Commands
{
    public class SetDeliveryAddressCommandHandler : BaseCommandHandler<SetDeliveryAddressCommand>
    {
        private readonly IRepository<Customer> _customerRepository;

        public SetDeliveryAddressCommandHandler(IRepository<Customer> customerRepository)            
        {
            _customerRepository = customerRepository;
        }

        public override void Execute(SetDeliveryAddressCommand command)
        {
            var customer = _customerRepository.Get(command.CustomerId);
          
            customer.SetDeliveryAddress(command.Address);
        }
    }
}