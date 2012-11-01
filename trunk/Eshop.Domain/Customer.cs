using System.Collections.Generic;
using System.Linq;
using CoreDdd.Domain;
using CoreDdd.Utilities;
using Iesi.Collections.Generic;

namespace Eshop.Domain
{
    public class Customer : Entity, IAggregateRoot
    {
        private readonly Iesi.Collections.Generic.ISet<BasketItem> _basketItems = new HashedSet<BasketItem>();
        public virtual IEnumerable<BasketItem> BasketItems { get { return _basketItems; } }

        public virtual string DeliveryAddress { get; protected internal set; }

        public virtual void AddProductToBasket(Product product, int count)
        {
            var basketItemWithTheProduct = _basketItems.FirstOrDefault(x => x.Product == product);
            if (basketItemWithTheProduct != null)
            {
                basketItemWithTheProduct.AddCount(count);
            }
            else
            {
                _basketItems.Add(new BasketItem(this, product, count));
            }
        }

        public virtual void UpdateProductCountInBasket(Product product, int newCount)
        {
            var basketItem = _basketItems.First(x => x.Product == product);
            if (newCount == 0)
            {
                _basketItems.Remove(basketItem);
            }
            else
            {
                basketItem.UpdateCount(newCount);
            }
        }

        public virtual void SetDeliveryAddress(string deliveryAddress)
        {
            DeliveryAddress = deliveryAddress;
        }

        internal const string MissingDeliveryAddressExceptionMessage = "Deliver address is not set";

        public virtual Order PlaceOrder()
        {
            Guard.Hope(!string.IsNullOrWhiteSpace(DeliveryAddress), MissingDeliveryAddressExceptionMessage);

            var order = new Order(_basketItems, DeliveryAddress);
            _basketItems.Clear();
            return order;
        }
    }
}
