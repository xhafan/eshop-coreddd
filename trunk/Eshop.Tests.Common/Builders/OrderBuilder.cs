using Eshop.Domain;

namespace Eshop.Tests.Common.Builders
{
    public class OrderBuilder
    {
        private Customer _customer;

        public OrderBuilder WithCustomer(Customer customer)
        {
            _customer = customer;
            return this;
        }

        public Order Build()
        {
            return _customer.PlaceOrder();
        }
    }
}
