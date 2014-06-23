using Eshop.Domain;

namespace Eshop.Tests.Common.Builders
{
    public class BasketItemBuilder
    {
        public const int Quantity = 34;

        private Customer _customer;
        private Product _product;
        private int? _quantity;

        public BasketItemBuilder WithCustomer(Customer customer)
        {
            _customer = customer;
            return this;
        }

        public BasketItemBuilder WithProduct(Product product)
        {
            _product = product;
            return this;
        }

        public BasketItemBuilder WithQuantity(int quantity)
        {
            _quantity = quantity;
            return this;
        }

        public BasketItem Build()
        {
            return new BasketItem(
                _customer ?? new CustomerBuilder().Build(),
                _product ?? new ProductBuilder().Build(),
                _quantity ?? Quantity
                );
        }
    }
}