using CoreDdd.Commands;

namespace Eshop.Commands
{
    public class UpdateProductQuantityInBasketCommand : ICommand
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int NewCount { get; set; }
    }
}