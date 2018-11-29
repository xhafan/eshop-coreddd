using CoreDdd.Domain.Repositories;
using Eshop.Domain;
using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.Commands.UnitTests.AddProductToBasketCommandHandlers
{
    [TestFixture]
    public class when_handling_add_product_to_basket_command_for_existing_customer
    {
        private const int Quantity = 34;
        private Customer _customer;
        private Product _product;

        [SetUp]
        public void Context()
        {
            const int customerId = 45;
            _customer = MockRepository.GenerateMock<Customer>();
            var customerRepository = MockRepository.GenerateStub<IRepository<Customer>>();
            customerRepository.Stub(x => x.Get(customerId)).Return(_customer);
            const int productId = 23;
            _product = MockRepository.GenerateStub<Product>();
            var productRepository = MockRepository.GenerateStub<IRepository<Product>>();
            productRepository.Stub(x => x.Get(productId)).Return(_product);
            var handler = new AddProductToBasketCommandHandler(customerRepository, productRepository, null);

            handler.Execute(new AddProductToBasketCommand
                                {
                                    CustomerId = customerId,
                                    ProductId = productId,
                                    Quantity = Quantity
                                });
        }

        [Test]
        public void add_product_to_basket_is_called_on_customer()
        {
            _customer.AssertWasCalled(x => x.AddProductToBasket(_product, Quantity));
        }
    }
}