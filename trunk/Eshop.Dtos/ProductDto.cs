using CoreDto;

namespace Eshop.Dtos
{
    public class ProductDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
