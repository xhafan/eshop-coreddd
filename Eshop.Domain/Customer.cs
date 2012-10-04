using System.Collections.Generic;
using System.Linq;
using CoreDdd.Domain;
using Iesi.Collections.Generic;

namespace Eshop.Domain
{
    public class Customer : Entity, IAggregateRoot
    {
        internal readonly Iesi.Collections.Generic.ISet<BasketItem> _basketItems = new HashedSet<BasketItem>();
        public IEnumerable<BasketItem> BasketItems { get { return _basketItems; } }

        public void AddProductToBasket(Product product, int count)
        {
            var basketItemWithTheProduct = _basketItems.FirstOrDefault(x => x.Product == product);
            if (basketItemWithTheProduct != null)
            {
                basketItemWithTheProduct.AddCount(count);
            }
            else
            {
                _basketItems.Add(new BasketItem(product, count));
            }
        }
    }
}
