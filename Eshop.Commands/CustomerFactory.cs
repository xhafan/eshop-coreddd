using Eshop.Domain;

namespace Eshop.Commands
{
    public class CustomerFactory : ICustomerFactory // todo: test me
    {
        public Customer Create()
        {
            return new Customer();
        }
    }
}