using Eshop.Domain;

namespace Eshop.IntegrationTests.Database.ObjectMothers
{
    public class ProductObjectMother
    {
        public const string ProductName = "product name";

        public Product NewEntity(string productName = null)
        {
            if (productName == null)
            {
                productName = ProductName;
            }
            return new Product(productName);
        }
    }
}