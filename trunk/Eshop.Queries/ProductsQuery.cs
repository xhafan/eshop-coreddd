using CoreDdd.Queries;

namespace Eshop.Queries
{
    public class ProductsQuery : IQuery
    {
        public string SearchText { get; set; }
    }
}
