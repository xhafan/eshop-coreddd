using Eshop.Domain;

namespace Eshop.IntegrationTests.Database.ObjectMothers
{
    public class ProductObjectMother
    {
        public const string Name = "product name";
        public const string Description = "product description";
        public const decimal Price = 23.4m;

        public Product NewEntity(string productName = null, string productDescription = null, decimal price = 0m)
        {
            if (productName == null) productName = Name;
            if (productDescription == null) productDescription = Description;
            if (price == 0m) price = Price;
            return new Product(productName, productDescription, price);
        }
    }
}