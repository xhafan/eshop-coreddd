using CoreDdd.Domain.Repositories;
using CoreTest;
using Eshop.Commands;
using Eshop.Domain;
using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.UnitTests.Commands
{
    [TestFixture]
    public class when_handling_update_product_count_in_basket_command : BaseTest
    {
        private const int NewCount = 34;
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
            var productRepository = Stub<IRepository<Product>>().Stubs(x => x.Load(productId)).Returns(_product);
            var handler = new UpdateProductCountInBasketCommandHandler(customerRepository, productRepository);

            handler.Execute(new UpdateProductCountInBasketCommand
                                {
                                    CustomerId = customerId,
                                    ProductId = productId,
                                    NewCount = NewCount
                                });
        }

        [Test]
        public void update_product_count_in_basket_is_called_on_customer()
        {
            _customer.AssertWasCalled(x => x.UpdateProductCountInBasket(_product, NewCount));
        }
    }
}