using CoreDdd.Domain.Repositories;
using Eshop.Domain;
using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.Commands.UnitTests.UpdateProductQuantityInBasketCommandHandlers
{
    [TestFixture]
    public class when_handling_update_product_quantity_in_basket_command
    {
        private const int NewQuantity = 34;
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
            var handler = new UpdateProductQuantityInBasketCommandHandler(customerRepository, productRepository);

            handler.Execute(new UpdateProductQuantityInBasketCommand
                                {
                                    CustomerId = customerId,
                                    ProductId = productId,
                                    Quantity = NewQuantity
                                });
        }

        [Test]
        public void update_product_quantity_in_basket_is_called_on_customer()
        {
            _customer.AssertWasCalled(x => x.UpdateProductQuantityInBasket(_product, NewQuantity));
        }
    }
}