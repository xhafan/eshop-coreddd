using CoreDdd.Commands;

namespace Eshop.Commands
{
    public class UpdateProductCountInBasketCommand : ICommand
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int NewCount { get; set; }
    }
}