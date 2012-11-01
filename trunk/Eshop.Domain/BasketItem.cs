using CoreDdd.Domain;

namespace Eshop.Domain
{
    public class BasketItem : Entity
    {
        protected BasketItem() {}

        public BasketItem(Customer customer, Product product, int count)
        {
            Customer = customer;
            Product = product;
            Count = count;
        }

        public virtual Customer Customer { get; protected set; }
        public virtual Product Product { get; protected set; }
        public virtual int Count { get; protected set; }

        public virtual void AddCount(int count)
        {
            Count += count;
        }

        public virtual void UpdateCount(int count)
        {
            Count = count;
        }
    }
}