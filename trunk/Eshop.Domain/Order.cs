using System.Collections.Generic;
using System.Linq;
using CoreDdd.Domain;
using Iesi.Collections.Generic;

namespace Eshop.Domain
{
    public class Order : Entity, IAggregateRoot
    {
        private readonly Iesi.Collections.Generic.ISet<OrderItem> _orderItems = new HashedSet<OrderItem>();

        protected Order() {}

        public Order(IEnumerable<BasketItem> basketItems, string deliveryAddress)
        {
            _orderItems.AddAll(basketItems.Select(x => new OrderItem(this, x.Product, x.Count)).ToList());
            DeliveryAddress = deliveryAddress;

        }
        
        public virtual IEnumerable<OrderItem> OrderItems { get { return _orderItems; } }
        public virtual string DeliveryAddress { get; protected set; }
    }
}