using Eshop.Domain;

namespace Eshop.Tests.Common.Builders
{
    public class OrderBuilder
    {
        public const string DeliveryAddress = "delivery address";

        private Customer _customer;
        private Product _product;

        public OrderBuilder WithCustomer(Customer customer)
        {
            _customer = customer;
            return this;
        }

        public OrderBuilder WithProduct(Product product)
        {
            _product = product;
            return this;
        }

        public Order Build()
        {
            var basketItem = new BasketItemBuilder()
                .WithCustomer(_customer)
                .WithProduct(_product)
                .Build();
            return new Order(new[]{ basketItem }, DeliveryAddress);
        }
    }
}
