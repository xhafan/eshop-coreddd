using CoreDdd.Domain.Repositories;
using CoreTest;
using Eshop.Domain;
using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.Commands.UnitTests
{
    [TestFixture]
    public class when_handling_add_product_to_basket_command_for_new_customer : BaseTest
    {
        private const int Count = 34;
        private const int CustomerId = 45;
        private int customerIdRaisedByEvent;
        private Customer _customer;
        private IRepository<Customer> _customerRepository;
        private Product _product;

        [SetUp]
        public void Context()
        {
            _customerRepository = Mock<IRepository<Customer>>();
            const int productId = 23;
            _product = Stub<Product>();
            var productRepository = Stub<IRepository<Product>>().Stubs(x => x.GetById(productId)).Returns(_product);
            _customer = Mock<Customer>().Stubs(x => x.Id).Returns(CustomerId);
            var customerFactory = Stub<ICustomerFactory>().Stubs(x => x.Create()).Returns(_customer);
            var handler = new AddProductToBasketCommandHandler(_customerRepository, productRepository, customerFactory);
            handler.CommandExecuted += (sender, args) => customerIdRaisedByEvent = (int)args.Args; // todo: refactor CoreDdd to support generic event handling

            handler.Execute(new AddProductToBasketCommand
                                {
                                    CustomerId = default(int),
                                    ProductId = productId,
                                    Quantity = Count
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

        [Test]
        public void customer_id_is_raised_by_event()
        {
            Assert.That(customerIdRaisedByEvent, Is.EqualTo(CustomerId));
        }
    }
}
