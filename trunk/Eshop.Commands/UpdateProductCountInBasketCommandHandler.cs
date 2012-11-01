using CoreDdd.Commands;
using CoreDdd.Domain.Repositories;
using Eshop.Domain;

namespace Eshop.Commands
{
    public class UpdateProductCountInBasketCommandHandler : BaseCommandHandler<UpdateProductCountInBasketCommand>
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Product> _productRepository;

        public UpdateProductCountInBasketCommandHandler(
            IRepository<Customer> customerRepository,
            IRepository<Product> productRepository)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        public override void Execute(UpdateProductCountInBasketCommand command)
        {
            var customer = _customerRepository.GetById(command.CustomerId);
            var product = _productRepository.Load(command.ProductId);

            customer.UpdateProductCountInBasket(product, command.NewCount);
        }
    }
}