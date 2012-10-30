using CoreDdd.Domain.Repositories;
using CoreTest;
using Eshop.Commands;
using Eshop.Domain;
using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.UnitTests.Commands
{
    [TestFixture]
    public class when_handling_add_product_to_basket_command_for_existing_customer : BaseTest
    {
        private const int ProductId = 23;
        private const int Count = 34;
        private const int CustomerId = 45;
        private Customer _customer;
        private IRepository<Customer> _customerRepository;
        private Product _product;

        [SetUp]
        public void Context()
        {
            _customer = Mock<Customer>();
            _customerRepository = Stub<IRepository<Customer>>().Stubs(x => x.GetById(CustomerId)).Returns(_customer);
            _product = Stub<Product>();
            var productRepository = Stub<IRepository<Product>>().Stubs(x => x.GetById(ProductId)).Returns(_product);
            var handler = new AddProductCommandHandler(_customerRepository, productRepository, null);

            handler.Execute(new AddProductCommand
                                {
                                    CustomerId = CustomerId,
                                    ProductId = ProductId,
                                    Count = Count
                                });
        }

        [Test]
        public void add_product_to_basket_is_called_on_customer()
        {
            _customer.AssertWasCalled(x => x.AddProductToBasket(_product, Count));
        }
    }
}