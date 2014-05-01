using CoreDdd.Queries;

namespace Eshop.Queries
{
    public class DeliveryAddressQuery : IQuery
    {
        public int CustomerId { get; set; }
    }
}