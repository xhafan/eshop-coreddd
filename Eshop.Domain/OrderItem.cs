using CoreDdd.Domain;

namespace Eshop.Domain
{
    public class OrderItem : Entity
    {
        protected OrderItem() {}

        public OrderItem(Order order, Product product, int quantity)
        {
            Order = order;
            Product = product;
            Quantity = quantity;
        }

        public virtual Order Order { get; protected set; }
        public virtual Product Product { get; protected set; }
        public virtual int Quantity { get; protected set; }
    }
}