using CoreDdd.Commands;

namespace Eshop.Commands
{
    public class SetDeliveryAddressCommand : ICommand
    {
        public int CustomerId { get; set; }
        public string Address { get; set; }
    }
}