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

        public virtual Product Product { get; private set; }
        public virtual int Count { get; private set; }
    }
}