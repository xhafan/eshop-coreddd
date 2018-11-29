using Eshop.Tests.Common.Builders;
using NUnit.Framework;

namespace Eshop.Domain.UnitTests.Customers
{
    public abstract class CustomerSetup
    {
        protected Customer Customer;

        [SetUp]
        public virtual void Context()
        {
            Customer = new CustomerBuilder().Build();
        }
    }
}