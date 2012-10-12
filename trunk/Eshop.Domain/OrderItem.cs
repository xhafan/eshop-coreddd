using CoreDdd.Domain;

namespace Eshop.Domain
{
    public class OrderItem : Entity
    {
        protected OrderItem() {}

        public OrderItem(Product product, int count)
        {
            Product = product;
            Count = count;
        }

        public virtual Product Product { get; protected set; }
        public virtual int Count { get; protected set; }
    }
}