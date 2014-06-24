using Eshop.Tests.Common.Builders;
using NUnit.Framework;

namespace Eshop.Domain.UnitTests.Customers
{
    public abstract class CustomerWithProductAddedToBasketSetup : CustomerSetup
    {
        protected const int Quantity = 23;
        protected Product Product;

        [SetUp]
        public override void Context()
        {
            base.Context();
            Product = new ProductBuilder().Build();
            Customer.AddProductToBasket(Product, Quantity);
        }
    }
}