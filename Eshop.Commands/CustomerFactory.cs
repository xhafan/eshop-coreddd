using Eshop.Domain;

namespace Eshop.Commands
{
    public class CustomerFactory : ICustomerFactory
    {
        public Customer Create()
        {
            return new Customer();
        }
    }
}