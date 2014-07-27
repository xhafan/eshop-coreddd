using CoreDdd.Nhibernate;

namespace Eshop.Dtos
{
    public class BasketItemDto : IAutoMappedDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
    }
}