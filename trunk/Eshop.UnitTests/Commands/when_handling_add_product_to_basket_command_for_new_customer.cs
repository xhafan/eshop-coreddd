using CoreDdd.Domain.Repositories;
using CoreTest;
using Eshop.Commands;
using Eshop.Domain;
using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.UnitTests.Commands
{
    [TestFixture]
    public class when_handling_add_product_to_basket_command_for_new_customer : BaseTest
    {
        private const int ProductId = 23;
        private const int Count = 34;
        private Customer _customer;
        private IRepository<Customer> _customerRepository;
        private Product _product;

        [SetUp]
        public void Context()
        {
            _customerRepository = Mock<IRepository<Customer>>();
            _product = Stub<Product>();
            var productRepository = Stub<IRepository<Product>>().Stubs(x => x.GetById(ProductId)).Returns(_product);
            _customer = Mock<Customer>();
            var customerFactory = Stub<ICustomerFactory>().Stubs(x => x.Create()).Returns(_customer);
            var handler = new AddProductCommandHandler(_customerRepository, productRepository, customerFactory);

            handler.Execute(new AddProductCommand
                                {
                                    CustomerId = default(int),
                                    ProductId = ProductId,
                                    Count = Count
                                });
        }

        [Test]
        public void add_product_to_basket_is_called_on_customer()
        {
            _customer.AssertWasCalled(x => x.AddProductToBasket(_product, Count));
        }

        [Test]
        public void new_customer_is_saved()
        {
            _customerRepository.AssertWasCalled(x => x.Save(_customer));
        }    
    }
}
