using CoreDdd.Commands;
using CoreDdd.Domain.Repositories;
using Eshop.Domain;

namespace Eshop.Commands
{
    public class UpdateProductQuantityInBasketCommandHandler : BaseCommandHandler<UpdateProductQuantityInBasketCommand>
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Product> _productRepository;

        public UpdateProductQuantityInBasketCommandHandler(
            IRepository<Customer> customerRepository,
            IRepository<Product> productRepository)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        public override void Execute(UpdateProductQuantityInBasketCommand command)
        {
            var customer = _customerRepository.Get(command.CustomerId);
            var product = _productRepository.Get(command.ProductId);

            customer.UpdateProductQuantityInBasket(product, command.Quantity);
        }
    }
}