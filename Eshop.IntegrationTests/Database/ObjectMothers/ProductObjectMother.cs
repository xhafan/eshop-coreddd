using Eshop.Domain;

namespace Eshop.IntegrationTests.Database.ObjectMothers
{
    public class ProductObjectMother
    {
        public const string ProductName = "product name";
        public const string ProductDescription = "product description";

        public Product NewEntity(string productName = null, string productDescription = null)
        {
            if (productName == null) productName = ProductName;
            if (productDescription == null) productDescription = ProductDescription;
            return new Product(productName, productDescription);
        }
    }
}