using CoreDto;

namespace Eshop.Dtos
{
    public class BasketItemDto : IDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
    }
}