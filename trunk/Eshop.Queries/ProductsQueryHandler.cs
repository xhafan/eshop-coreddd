using CoreDdd.Queries;
using Eshop.Dtos;
using NHibernate;

namespace Eshop.Queries
{
    public class ProductsQueryHandler : BaseQueryOverHandler<ProductsQuery>
    {
        public override IQueryOver GetQueryOver<TResult>(ProductsQuery query)
        {
            return Session.QueryOver<ProductDto>();
        }
    }
}