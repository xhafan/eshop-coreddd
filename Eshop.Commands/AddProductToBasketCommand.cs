using CoreDdd.Commands;

namespace Eshop.Commands
{
    public class AddProductToBasketCommand : ICommand
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
