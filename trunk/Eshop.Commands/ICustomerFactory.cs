using Eshop.Domain;

namespace Eshop.Commands
{
    public interface ICustomerFactory
    {
        Customer Create();
    }
}