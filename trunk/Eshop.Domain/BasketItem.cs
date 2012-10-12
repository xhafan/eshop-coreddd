using CoreDdd.Domain;

namespace Eshop.Domain
{
    public class BasketItem : Entity
    {
        protected BasketItem() {}

        public BasketItem(Product product, int count)
        {
            Product = product;
            Count = count;
        }

        public virtual Product Product { get; protected set; }
        public virtual int Count { get; protected set; }

        public virtual void AddCount(int count)
        {
            Count += count;
        }
    }
}