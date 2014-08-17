using System.Collections.Generic;
using CoreDdd.Domain;
using CoreUtils.Extensions;

namespace Eshop.Domain
{
    public class Order : Entity, IAggregateRoot
    {
        private readonly ICollection<OrderItem> _orderItems = new HashSet<OrderItem>();

        protected Order() {}

        public Order(IEnumerable<BasketItem> basketItems, string deliveryAddress)
        {
            basketItems.Each(x => _orderItems.Add(new OrderItem(this, x.Product, x.Quantity)));
            DeliveryAddress = deliveryAddress;

        }
        
        public virtual IEnumerable<OrderItem> OrderItems { get { return _orderItems; } }
        public virtual string DeliveryAddress { get; protected set; }
    }
}