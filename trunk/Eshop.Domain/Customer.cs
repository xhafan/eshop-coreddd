using System.Collections.Generic;
using CoreDdd.Domain;
using Iesi.Collections.Generic;

namespace Eshop.Domain
{
    public class Customer : Entity, IAggregateRoot
    {
        private readonly Iesi.Collections.Generic.ISet<BasketItem> _basketItems = new HashedSet<BasketItem>();
        public IEnumerable<BasketItem> BasketItems { get { return _basketItems; } }

        public void AddProductToBasket(Product product, int count)
        {
            _basketItems.Add(new BasketItem(product, count));
        }
    }
}
