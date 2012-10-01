using CoreDdd.Domain;

namespace Eshop.Domain
{
    public class BasketItem : Entity<BasketItem>
    {
        public BasketItem(Product product, int count)
        {
            Product = product;
            Count = count;
        }

        public Product Product { get; private set; }
        public int Count { get; private set; }
    }
}