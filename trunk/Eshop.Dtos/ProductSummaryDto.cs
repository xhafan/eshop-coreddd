using CoreDdd.Nhibernate;

namespace Eshop.Dtos
{
    public class ProductSummaryDto : IAutoMappedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
