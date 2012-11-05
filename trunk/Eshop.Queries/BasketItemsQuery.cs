using CoreDdd.Queries;

namespace Eshop.Queries
{
    public class BasketItemsQuery : IQuery
    {
        public int CustomerId { get; set; }
    }
}