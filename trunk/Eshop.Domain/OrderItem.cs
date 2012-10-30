using CoreDdd.Domain;

namespace Eshop.Domain
{
    public class OrderItem : Entity
    {
        protected OrderItem() {}

        public OrderItem(Order order, Product product, int count)
        {
            Order = order;
            Product = product;
            Count = count;
        }

        public virtual Order Order { get; protected set; }
        public virtual Product Product { get; protected set; }
        public virtual int Count { get; protected set; }
    }
}