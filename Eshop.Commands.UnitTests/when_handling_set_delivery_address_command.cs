using CoreDdd.Domain.Repositories;
using CoreTest;
using Eshop.Domain;
using NUnit.Framework;
using Rhino.Mocks;

namespace Eshop.Commands.UnitTests
{
    [TestFixture]
    public class when_handling_set_delivery_address_command : BaseTest
    {
        private const string DeliveryAddress = "delivery address";
        private Customer _customer;

        [SetUp]
        public void Context()
        {
            const int customerId = 45;
            _customer = Mock<Customer>();
            var customerRepository = Stub<IRepository<Customer>>().Stubs(x => x.GetById(customerId)).Returns(_customer);
            var handler = new SetDeliveryAddressCommandHandler(customerRepository);

            handler.Execute(new SetDeliveryAddressCommand
                                {
                                    CustomerId = customerId,
                                    Address = DeliveryAddress,
                                });
        }

        [Test]
        public void set_delivery_address_is_called_on_customer()
        {
            _customer.AssertWasCalled(x => x.SetDeliveryAddress(DeliveryAddress));
        }
    }
}