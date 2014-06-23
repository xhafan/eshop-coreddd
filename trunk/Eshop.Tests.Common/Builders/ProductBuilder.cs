using Eshop.Domain;

namespace Eshop.Tests.Common.Builders
{
    public class ProductBuilder
    {
        public const string Name = "product name";
        public const string Description = "product description";
        public const decimal Price = 23.4m;

        private string _name;
        private string _productDescription;
        private decimal? _price;

        public ProductBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public ProductBuilder WithDescription(string productDescription)
        {
            _productDescription = productDescription;
            return this;
        }

        public ProductBuilder WithPrice(decimal price)
        {
            _price = price;
            return this;
        }

        public Product Build()
        { 
            return new Product(
                _name ?? Name,
                _productDescription ?? Description,
                _price ?? Price
                );
        }
    }
}