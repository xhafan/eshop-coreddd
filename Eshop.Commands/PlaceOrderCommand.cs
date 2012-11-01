using CoreDdd.Commands;

namespace Eshop.Commands
{
    public class PlaceOrderCommand : ICommand
    {
        public int CustomerId { get; set; }
    }
}