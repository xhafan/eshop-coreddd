using CoreDdd.Commands;

namespace Eshop.Commands
{
    public class AddProductCommand : ICommand
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
}
