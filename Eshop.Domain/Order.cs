using System.Collections.Generic;
using System.Linq;
using CoreDdd.Domain;
using Iesi.Collections.Generic;

namespace Eshop.Domain
{
    public class Order : Entity, IAggregateRoot
    {
        private readonly Iesi.Collections.Generic.ISet<OrderItem> _orderItems = new HashedSet<OrderItem>();
        public virtual IEnumerable<OrderItem> OrderItems { get { return _orderItems; } }

        public virtual string DeliveryAddress { get; protected internal set; }

        protected internal Order() {}

        public Order(IEnumerable<BasketItem> basketItems, string deliveryAddress)
        {
            _orderItems.AddAll(basketItems.Select(x => new OrderItem(x.Product, x.Count)).ToList());
            DeliveryAddress = deliveryAddress;
        }
    }
}