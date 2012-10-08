using System.Collections.Generic;
using System.Linq;
using CoreDdd.Domain;
using CoreDdd.Utilities;
using Iesi.Collections.Generic;

namespace Eshop.Domain
{
    public class Customer : Entity, IAggregateRoot
    {
        internal readonly Iesi.Collections.Generic.ISet<BasketItem> _basketItems = new HashedSet<BasketItem>();
        public IEnumerable<BasketItem> BasketItems { get { return _basketItems; } }
        
        public string DeliveryAddress { get; internal set; }

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

        public void RemoveFromBasket(BasketItem basketItem)
        {
            _basketItems.Remove(basketItem);
        }

        public void SetDeliveryAddress(string deliveryAddress)
        {
            DeliveryAddress = deliveryAddress;
        }

        internal const string MissingDeliveryAddressExceptionMessage = "Deliver address is not set";

        public Order PlaceOrder()
        {
            Guard.Hope(!string.IsNullOrWhiteSpace(DeliveryAddress), MissingDeliveryAddressExceptionMessage);

            var order = new Order(_basketItems, DeliveryAddress);
            _basketItems.Clear();
            return order;
        }
    }
}
