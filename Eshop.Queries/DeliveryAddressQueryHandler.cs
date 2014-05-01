using CoreDdd.Queries;
using Eshop.Dtos;
using NHibernate;

namespace Eshop.Queries
{
    public class DeliveryAddressQueryHandler : BaseQueryOverHandler<DeliveryAddressQuery>
    {
        public override IQueryOver GetQueryOver<TResult>(DeliveryAddressQuery query)
        {
            return Session.QueryOver<DeliveryAddressDto>().Where(x => x.CustomerId == query.CustomerId);
        }
    }
}