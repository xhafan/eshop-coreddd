using Eshop.Domain;

namespace Eshop.IntegrationTests.Database.ObjectMothers
{
    public class CustomerObjectMother
    {
        public Customer NewEntity()
        {
            return new Customer();
        }
    }
}