using CoreDdd.Domain.Repositories;
using CoreTest;
using Eshop.Domain;
using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.Commands.UnitTests
{
    [TestFixture]
    public class when_handling_add_product_to_basket_command_for_existing_customer : BaseTest
    {
        private const int Quantity = 34;
        private Customer _customer;
        private Product _product;

        [SetUp]
        public void Context()
        {
            const int customerId = 45;
            _customer = Mock<Customer>();
            var customerRepository = Stub<IRepository<Customer>>().Stubs(x => x.GetById(customerId)).Returns(_customer);
            const int productId = 23;
            _product = Stub<Product>();
            var productRepository = Stub<IRepository<Product>>().Stubs(x => x.GetById(productId)).Returns(_product);
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