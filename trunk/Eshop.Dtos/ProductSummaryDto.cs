using CoreDto;

namespace Eshop.Dtos
{
    public class ProductSummaryDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
