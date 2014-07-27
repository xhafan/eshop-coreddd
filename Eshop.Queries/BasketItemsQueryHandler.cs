using CoreDdd.Nhibernate.Queries;
using Eshop.Dtos;
using NHibernate;

namespace Eshop.Queries
{
    public class BasketItemsQueryHandler : BaseQueryOverHandler<BasketItemsQuery>
    {
        public override IQueryOver GetQueryOver<TResult>(BasketItemsQuery query)
        {
            return Session.QueryOver<BasketItemDto>().Where(x => x.CustomerId == query.CustomerId);
        }
    }
}