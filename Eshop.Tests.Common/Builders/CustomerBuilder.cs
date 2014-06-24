using System.Collections.Generic;
using System.Collections.ObjectModel;
using Eshop.Domain;

namespace Eshop.Tests.Common.Builders
{
    public class CustomerBuilder
    {
        public const string DeliveryAddress = "delivery address";

        private class BasketItemInfo
        {
            public Product Product;
            public int Quantity;
        }

        private readonly ICollection<BasketItemInfo> _basketItems = new Collection<BasketItemInfo>();
        private string _deliveryAddress;

        public CustomerBuilder WithProductInBasket(Product product, int quantity)
        {
            _basketItems.Add(new BasketItemInfo { Product = product, Quantity = quantity });
            return this;
        }

        public CustomerBuilder WithDeliveryAddress(string deliveryAddress = DeliveryAddress)
        {
            _deliveryAddress = deliveryAddress;
            return this;
        }

        public Customer Build()
        {
            var customer = new Customer();
            foreach (var basketItem in _basketItems)
            {
                customer.AddProductToBasket(basketItem.Product, basketItem.Quantity);
            }
            customer.SetDeliveryAddress(_deliveryAddress);
            return customer;
        }
    }
}