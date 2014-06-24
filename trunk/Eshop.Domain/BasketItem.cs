using CoreDdd.Domain;

namespace Eshop.Domain
{
    public class BasketItem : Entity
    {
        protected BasketItem() {}

        public BasketItem(Customer customer, Product product, int quantity)
        {
            Customer = customer;
            Product = product;
            Quantity = quantity;
        }

        public virtual Customer Customer { get; protected set; }
        public virtual Product Product { get; protected set; }
        public virtual int Quantity { get; protected set; }

        public virtual void AddQuantity(int quantity)
        {
            Quantity += quantity;
        }

        public virtual void UpdateQuantity(int quantity)
        {
            Quantity = quantity;
        }
    }
}