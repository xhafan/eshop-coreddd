using Eshop.Domain;

namespace Eshop.IntegrationTests.Database.ObjectMothers
{
    public class BasketItemObjectMother
    {
        public const int Count = 34;

        public BasketItem NewEntity(Customer customer, Product product, int? count = null)
        {
            return new BasketItem(customer, product, count.HasValue ? count.Value : Count);
        }
    }
}