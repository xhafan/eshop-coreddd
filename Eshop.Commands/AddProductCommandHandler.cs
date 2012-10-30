using CoreDdd.Commands;
using CoreDdd.Domain.Repositories;
using Eshop.Domain;

namespace Eshop.Commands
{
    public class AddProductCommandHandler : BaseCommandHandler<AddProductCommand>
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly ICustomerFactory _customerFactory;

        public AddProductCommandHandler(
            IRepository<Customer> customerRepository,
            IRepository<Product> productRepository,
            ICustomerFactory customerFactory)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _customerFactory = customerFactory;
        }

        public override void Execute(AddProductCommand command)
        {
            var isNewCustomer = command.CustomerId == default(int);
            var customer = isNewCustomer
                               ? _customerFactory.Create()
                               : _customerRepository.GetById(command.CustomerId);

            var product = _productRepository.GetById(command.ProductId);               
            
            customer.AddProductToBasket(product, command.Count);
            
            if (isNewCustomer) _customerRepository.Save(customer);
        }
    }
}