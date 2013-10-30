using Eshop.Domain;

namespace Eshop.IntegrationTests.Database.ObjectMothers
{
    public class OrderObjectMother
    {
        public const string DeliveryAddress = "delivery address";

        public Order NewEntity(Customer customer, Product product)
        {
            var basketItem = new BasketItemObjectMother().NewEntity(customer, product);
            return new Order(new[]{ basketItem }, DeliveryAddress);
        }
    }
}
