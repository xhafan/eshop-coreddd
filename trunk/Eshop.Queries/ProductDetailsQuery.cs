using CoreDdd.Queries;

namespace Eshop.Queries
{
    public class ProductDetailsQuery : IQuery
    {
        public int ProductId { get; set; }
    }
}