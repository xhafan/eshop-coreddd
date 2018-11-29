using CoreDdd.Domain.Repositories;
using Eshop.Domain;
using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.Commands.UnitTests.AddProductToBasketCommandHandlers
{
    [TestFixture]
    public class when_handling_add_product_to_basket_command_for_new_customer
    {
        private const int Quantity = 34;
        private const int CustomerId = 45;
        private int _customerIdRaisedByEvent;
        private Customer _customer;
        private IRepository<Customer> _customerRepository;
        private Product _product;

        [SetUp]
        public void Context()
        {
            _customerRepository = MockRepository.GenerateMock<IRepository<Customer>>();
            const int productId = 23;
            _product = MockRepository.GenerateStub<Product>();
            var productRepository = MockRepository.GenerateStub<IRepository<Product>>();
            productRepository.Stub(x => x.Get(productId)).Return(_product);
            _customer = MockRepository.GenerateMock<Customer>();
            _customer.Stub(x => x.Id).Return(CustomerId);
            var customerFactory = MockRepository.GenerateStub<ICustomerFactory>();
            customerFactory.Stub(x => x.Create()).Return(_customer);
            var handler = new AddProductToBasketCommandHandler(_customerRepository, productRepository, customerFactory);
            handler.CommandExecuted += (args) => _customerIdRaisedByEvent = (int)args.Args; // todo: refactor CoreDdd to support generic event handling

            handler.Execute(new AddProductToBasketCommand
                                {
                                    CustomerId = default(int),
                                    ProductId = productId,
                                    Quantity = Quantity
                                });
        }

        [Test]
        public void add_product_to_basket_is_called_on_customer()
        {
            _customer.AssertWasCalled(x => x.AddProductToBasket(_product, Quantity));
        }

        [Test]
        public void new_customer_is_saved()
        {
            _customerRepository.AssertWasCalled(x => x.Save(_customer));
        }

        [Test]
        public void customer_id_is_raised_by_event()
        {
            Assert.That(_customerIdRaisedByEvent, Is.EqualTo(CustomerId));
        }
    }
}
